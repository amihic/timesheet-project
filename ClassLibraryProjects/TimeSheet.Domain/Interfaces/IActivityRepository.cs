using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Model;

namespace TimeSheet.Domain.Interfaces
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetActivitiesAsync(SearchParams searchParams);
        void DeleteActivity(int id);
        void CreateActivity(Activity activity, int LoggedInUserId);
        void UpdateActivity(Activity activity);
        void SaveChanges();
    }
}
