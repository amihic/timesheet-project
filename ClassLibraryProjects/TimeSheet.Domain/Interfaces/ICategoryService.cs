using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Model;

namespace TimeSheet.Domain.Interfaces
{
    public interface ICategoryService
    {
        void CreateCategory(Category newCategory);
        void UpdateCategory(Category category);
        Task<IEnumerable<Category>> GetCategoriesAsync(SearchParams searchParams);
        void DeleteCategory(int id);
    }
}