using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Domain.Model;

namespace TimeSheet.Domain.Interfaces
{
    public interface ICategoryService
    {
        void CreateCategory(Category newCategory);
        void UpdateCategory(Category category);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        void DeleteCategory(int id);
    }
}