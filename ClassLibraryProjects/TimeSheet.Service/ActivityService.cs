using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Interfaces;
using TimeSheet.Domain.Model;

namespace TimeSheet.Service
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;

        private const double FullTime = 7.5;
        private const double DaysPerWeek = 5.0;
        private const double PartTime = 4.0;


        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }
        public void CreateActivity(Activity newActivity, int LoggedInUserId)
        {
            _activityRepository.CreateActivity(newActivity, LoggedInUserId);
        }

        public void DeleteActivity(int id)
        {
            _activityRepository.DeleteActivity(id);
        }

        public Task<IEnumerable<Activity>> GetActivitiesAsync(SearchParams parameters)
        {
            return _activityRepository.GetActivitiesAsync(parameters);
        }

        public async Task<WorkingCalendar> GetWorkingCalendarAsync(SearchParams parameters)
        {
            var activities = await _activityRepository.GetActivitiesAsync(parameters);

            var groupedActivitiesByDate = activities
                .GroupBy(a => a.Date.Date)
                .Select(MapActivitiesToWorkingDay)
                .ToList();

            WorkingCalendar workingCalendar = new WorkingCalendar();
            workingCalendar.WorkingDays = groupedActivitiesByDate;
            workingCalendar.TotalHours = activities.Sum(x => x.Time);


            return workingCalendar;
        }

        private WorkingDay MapActivitiesToWorkingDay(IEnumerable<Activity> activities)
        {
            WorkingDay workingDay = new WorkingDay();
            
            workingDay.NumberOfHours = activities.Sum(x => x.Time);
            workingDay.Date = activities.FirstOrDefault().Date;

            //var hpw = activities.Select(user => user.User.HoursPerWeek).FirstOrDefault();


            SetWokringDayStatus(workingDay);

            return workingDay;
        }

        private WorkingDay SetWokringDayStatus(WorkingDay workingDay)
        {
            /*var workingHoursPerDay = hpw / DaysPerWeek;

            if (workingHoursPerDay == PartTime)
                workingDay.WorkStatus = WorkStatus.PartTime;
            else if (workingHoursPerDay == 0)
                workingDay.WorkStatus = WorkStatus.Idle;
            else if (workingHoursPerDay >= FullTime)
                workingDay.WorkStatus = WorkStatus.FullTime;*/
            workingDay.WorkStatus = WorkStatus.FullTime;
            return workingDay;
        }


        public void UpdateActivity(Activity activity)
        {
            _activityRepository.UpdateActivity(activity);
        }
    }
}
