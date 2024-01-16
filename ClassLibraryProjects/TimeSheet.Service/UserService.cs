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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository categoryRepository)
        {
            _userRepository = categoryRepository;
        }
        public void CreateUser(User newUser)
        {
            _userRepository.CreateUser(newUser);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public Task<IEnumerable<User>> GetUsersAsync(SearchParams searchParams)
        {
            return _userRepository.GetUsersAsync(searchParams);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }
    }
}
