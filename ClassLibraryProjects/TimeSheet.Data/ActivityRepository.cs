using AutoMapper;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Data.Entities;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Interfaces;
using TimeSheet.Domain.Model;

namespace TimeSheet.Data
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly TimeSheetDbContext _timeSheetDbContext;

        private readonly IMapper _mapper;

        public ActivityRepository(IMapper mapper, TimeSheetDbContext timeSheetDbContext)
        {
            _mapper = mapper;
            _timeSheetDbContext = timeSheetDbContext;
        }
        public void CreateActivity(Activity activity, int LoggedInUserId)
        {
            var project = _timeSheetDbContext.Projects.Find(activity.Project.Id);
            var client = _timeSheetDbContext.Clients.Find(activity.Client.Id);
            var category = _timeSheetDbContext.Categories.Find(activity.Category.Id);

            if (project == null || client == null ||category == null)
            {
                throw new DirectoryNotFoundException();
            }

            var activityToAdd = _mapper.Map<Activity, ActivityEntity>(activity);
            activityToAdd.User.Id = LoggedInUserId;
            activityToAdd.Project = project;
            activityToAdd.Client = client;
            activityToAdd.Category = category;
            activityToAdd.Date = activity.Date.Date;// date without time

            _timeSheetDbContext.Activities.Add(activityToAdd);
            SaveChanges();
        }

        public void DeleteActivity(int id)
        {
            var activityToDelete = _timeSheetDbContext.Activities.Find(id);

            if (activityToDelete == null)
            {
                throw new DirectoryNotFoundException();
            }

            activityToDelete.IsDeleted = true;
            _timeSheetDbContext.Activities.Update(activityToDelete);
            SaveChanges();
        }

        public async Task<IEnumerable<Activity>> GetActivitiesAsync(SearchParams searchParams)
        {
            var query = _timeSheetDbContext.Activities.AsQueryable().Where(activity => activity.User.Id == searchParams.UserId.Value);

            if (searchParams.ClientId.HasValue)
            {
                query = query.Where(activity => activity.Client.Id == searchParams.ClientId.Value);
            }

            if (searchParams.UserId.HasValue)
            {
                query = query.Where(activity => activity.User.Id == searchParams.UserId.Value);
            }

            if (searchParams.CategoryId.HasValue)
            {
                query = query.Where(activity => activity.Category.Id == searchParams.CategoryId.Value);
            }

            if (searchParams.ProjectId.HasValue)
            {
                query = query.Where(activity => activity.Project.Id == searchParams.ProjectId.Value);
            }

            if (searchParams.Date.HasValue)
            {
                DateTimeOffset searchDate = new DateTimeOffset(searchParams.Date.Value.Date, TimeSpan.Zero);
                query = query.Where(activity => activity.Date.Date == searchDate);
            }

            if (searchParams.StartTime.HasValue && searchParams.EndTime.HasValue)
            {
                DateTimeOffset start = new DateTimeOffset(searchParams.StartTime.Value.Date, TimeSpan.Zero);
                DateTimeOffset end = new DateTimeOffset(searchParams.EndTime.Value.Date, TimeSpan.Zero);

                if (end < start)
                {
                    throw new Exception("startno vreme mora biti manje od krajnjeg");
                }

                query = query.Where(activity => activity.Date.Date >= start && activity.Date.Date <= end);
            }

            var totalActivities = await query.CountAsync();

            var paginatedActivities = await query
                .Include(c => c.Client.Country)
                .Include(c => c.Project.Client)
                .Include(c => c.Category)
                .ToListAsync();

            var pagination = new Pagination<ActivityEntity>(searchParams.PageIndex, searchParams.PageSize, totalActivities, paginatedActivities);

            var activitiesToReturn = _mapper.Map<IEnumerable<ActivityEntity>, IEnumerable<Activity>>(pagination.Data);

            return activitiesToReturn;
        }

        public void SaveChanges()
        {
            _timeSheetDbContext.SaveChanges();
        }

        public void UpdateActivity(Activity activity)
        {
            var activityToUpdate = _timeSheetDbContext.Activities.Find(activity.Id);

            if (activityToUpdate == null)
            {
                throw new DirectoryNotFoundException();
            }

            var activityChanges = _mapper.Map<Activity, ActivityEntity>(activity);

            activityToUpdate.Description = activityChanges.Description;

            _timeSheetDbContext.Activities.Update(activityToUpdate);
            SaveChanges();
        }
    }
}
