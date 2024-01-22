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

        public async Task<WorkingCalendar> GetWorkingCalendarAsync(SearchParams parameters) 
        {//trebace id za ulogovanog korisnika
            List<WorkingDay> workingDays = new List<WorkingDay>();
            WorkingCalendar workingCalendar = new WorkingCalendar();
            var activities = await _activityRepository.GetActivitiesAsync(parameters);

            var totalHours = 0.0;           

            var groupedActivitiesByDate = activities.GroupBy(a => a.Date.Date)/*.Select(x => MapActivity(x)).ToList()*/;// u map activity ubaci foreach ceo prvi, vraca workingday
            var groupedActivitiesByDateToReturn = groupedActivitiesByDate.ToDictionary(group => group.Key, group => group.ToList());

            foreach (var key in groupedActivitiesByDateToReturn) 
            {
                DateTime datum = key.Key;              
                List<Activity> listaAktivnosti = key.Value;
                WorkingDay workingDay = new WorkingDay();

                foreach (var activity in listaAktivnosti)
                {
                    workingDay.NumberOfHours += activity.Time;
                    workingDay.Date = activity.Date;
                    totalHours += activity.Time;
                }
                if (workingDay.NumberOfHours > 0 && workingDay.NumberOfHours < 7.5)// ne 7.5 nego neka konstanta, imam hours per week, to se deli sa 5 i proverava
                    workingDay.WorkStatus = WorkStatus.UNFINISHED;
                else if (workingDay.NumberOfHours == 0)
                    workingDay.WorkStatus = WorkStatus.IDLE;
                else if (workingDay.NumberOfHours == 7.5)
                    workingDay.WorkStatus = WorkStatus.FINISHED;
                else if (workingDay.NumberOfHours > 7.5)
                    workingDay.WorkStatus = WorkStatus.FINISHED_AND_OVERTIME;

                workingDays.Add(workingDay);
            }
            workingCalendar.WorkingDays = workingDays;
            workingCalendar.TotalHours = totalHours;



            return workingCalendar;
        }

        public void UpdateActivity(Activity activity)
        {
            _activityRepository.UpdateActivity(activity);
        }
    }
}
