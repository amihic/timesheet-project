using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Model;

namespace TimeSheet.Domain.Interfaces
{
    public interface IActivityService
    {
        void CreateActivity(Activity newActivity);
        void UpdateActivity(Activity activity);
        Task<IEnumerable<Activity>> GetActivitiesAsync(SearchParams searchParams);
        void DeleteActivity(int id);
        Task<WorkingDay> GetWorkingDayAsync(SearchParams searchParams);
        Task<WorkingCalendar> GetWorkingCalendarAsync(SearchParams searchParams);
    }
}
