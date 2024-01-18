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

        public void UpdateActivity(Activity activity)
        {
            _activityRepository.UpdateActivity(activity);
        }
    }
}
