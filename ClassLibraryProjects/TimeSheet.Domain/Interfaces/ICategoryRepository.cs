using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Domain.Model;

namespace TimeSheet.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        void DeleteCategory(int id);
        void Create(Category category);
        int MaxId();
        void UpdateCategory(Category category);
        void SaveChanges();
    }
}