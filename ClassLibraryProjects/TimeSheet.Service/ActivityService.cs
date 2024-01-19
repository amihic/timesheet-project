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


        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }
        public void CreateActivity(Activity newActivity)
        {
            _activityRepository.CreateActivity(newActivity);
        }

        public void DeleteActivity(int id)
        {
            _activityRepository.DeleteActivity(id);
        }

        public Task<IEnumerable<Activity>> GetActivitiesAsync(SearchParams parameters)
        {
            return _activityRepository.GetActivitiesAsync(parameters);
        }

        public async Task<WorkingDay> GetWorkingDayAsync(SearchParams parameters)
        {
            WorkingDay workingDay = new WorkingDay();
            var activities = await _activityRepository.GetActivitiesAsync(parameters);

            foreach (var activity in activities) 
            {
                workingDay.NumberOfHours += activity.Time;
                workingDay.Date = activity.Date;
            }

            if (workingDay.NumberOfHours > 0 && workingDay.NumberOfHours < 7.5)
                workingDay.WorkStatus = WorkStatus.UNFINISHED;
            else if (workingDay.NumberOfHours == 0)
                workingDay.WorkStatus = WorkStatus.IDLE;
            else if (workingDay.NumberOfHours == 7.5)
                workingDay.WorkStatus = WorkStatus.FINISHED;
            else if (workingDay.NumberOfHours > 7.5)
                workingDay.WorkStatus = WorkStatus.FINISHED_AND_OVERTIME;

            return workingDay;
        }

        public void UpdateActivity(Activity activity)
        {
            _activityRepository.UpdateActivity(activity);
        }
    }
}
