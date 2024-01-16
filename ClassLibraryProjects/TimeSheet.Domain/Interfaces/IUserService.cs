using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Model;

namespace TimeSheet.Domain.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User newUser);
        void UpdateUser(User user);
        Task<IEnumerable<User>> GetUsersAsync(SearchParams searchParams);
        void DeleteUser(int id);
    }
}
