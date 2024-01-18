using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Data.Entities;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Interfaces;
using TimeSheet.Domain.Model;

namespace TimeSheet.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly TimeSheetDbContext _timeSheetDbContext;

        private readonly IMapper _mapper;

        public UserRepository(IMapper mapper, TimeSheetDbContext timeSheetDbContext)
        {
            _mapper = mapper;
            _timeSheetDbContext = timeSheetDbContext;
        }
        public void CreateUser(User user)
        {
            var passwordHasher = new PasswordHasher<User>();
            user.Password = passwordHasher.HashPassword(user, user.Password);

            var userToAdd = _mapper.Map<User, UserEntity>(user);
            _timeSheetDbContext.Users.Add(userToAdd);
            SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var userToDelete = _timeSheetDbContext.Users.Find(id);

            if (userToDelete == null)
            {
                throw new DirectoryNotFoundException();
            }

            userToDelete.IsDeleted = true;
            _timeSheetDbContext.Users.Update(userToDelete);
            SaveChanges();
        }

        public async Task<IEnumerable<User>> GetUsersAsync(SearchParams searchParams)
        {
            var query = _timeSheetDbContext.Users.AsQueryable();

            if (searchParams.FirstLetter.HasValue)
            {
                query = query.Where(user => EF.Functions.Like(user.Name, $"{searchParams.FirstLetter}%"));
            }
            if (!string.IsNullOrEmpty(searchParams.SearchText))
            {
                query = query.Where(user => EF.Functions.Like(user.Name, $"%{searchParams.SearchText}%"));
            }

            var totalUsers = await query.CountAsync();

            var paginatedUsers = await query
                .Skip((searchParams.PageIndex - 1) * searchParams.PageSize)
                .Take(searchParams.PageSize)
                .ToListAsync();

            var pagination = new Pagination<UserEntity>(searchParams.PageIndex, searchParams.PageSize, totalUsers, paginatedUsers);

            var usersToReturn = _mapper.Map<IEnumerable<UserEntity>, IEnumerable<User>>(pagination.Data);

            return usersToReturn;
        }

        public void SaveChanges()
        {
            _timeSheetDbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var userToUpdate = _timeSheetDbContext.Users.Find(user.Id);

            if (userToUpdate == null)
            {
                throw new DirectoryNotFoundException();
            }

            var userChanges = _mapper.Map<User, UserEntity>(user);

            var passwordHasher = new PasswordHasher<UserEntity>();
            var hashedPassword = passwordHasher.HashPassword(userChanges, userChanges.Password);

            userToUpdate.Name = userChanges.Name;
            userToUpdate.Password = hashedPassword;

            _timeSheetDbContext.Users.Update(userToUpdate);
            SaveChanges();
        }
    }
}
