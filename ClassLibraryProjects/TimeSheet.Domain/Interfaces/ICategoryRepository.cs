using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Model;

namespace TimeSheet.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync(SearchParams searchParams);
        void DeleteCategory(int id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void SaveChanges();
    }
}