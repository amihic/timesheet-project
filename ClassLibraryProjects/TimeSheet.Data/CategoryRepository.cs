using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TimeSheet.Data.Entities;
using TimeSheet.Domain.Interfaces;
using TimeSheet.Domain.Model;

namespace TimeSheet.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TimeSheetDbContext _timeSheetDbContext;

        private readonly IMapper _mapper;  

        public CategoryRepository(IMapper mapper, TimeSheetDbContext timeSheetDbContext)
        {
            _mapper = mapper;
            _timeSheetDbContext = timeSheetDbContext;
        }

        

        public void DeleteCategoryAsync(int id)//logicko brisanje
        {
            var categoryToDelete = _timeSheetDbContext.Categories.Find(id);
            if (categoryToDelete != null)
            {
                _timeSheetDbContext.Categories.Remove(categoryToDelete);
                _timeSheetDbContext.SaveChanges();
            }
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync() 
        {
            var categories = await _timeSheetDbContext.Categories.ToListAsync();
            var categoriesToReturn = _mapper.Map<List<CategoryEntity>, IEnumerable<Category>>(categories);
            return categoriesToReturn;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category =  await _timeSheetDbContext.Categories.FindAsync(id);
            var categoryToReturn = _mapper.Map<Category>(category);
            return categoryToReturn;
        }

        public void Create(Category category)
        {
            var categoryToAdd = _mapper.Map<Category, CategoryEntity>(category);
            _timeSheetDbContext.Categories.Add(categoryToAdd);
            SaveChanges();
            
        }

        public int MaxId() 
        {
            var maxId = _timeSheetDbContext.Categories.Max(c => (int?)c.Id) ?? 0;
            return maxId;
        }

        public void SaveChanges()
        {
            _timeSheetDbContext.SaveChanges();
        }

        public void Update(Category category)
        {
            var categoryToUpdate = _timeSheetDbContext.Categories.Find(category.Id);
            var categoryChanges = _mapper.Map<Category, CategoryEntity>(category);

            categoryToUpdate.Name = categoryChanges.Name;

            _timeSheetDbContext.Categories.Update(categoryToUpdate);

            SaveChanges();
            
        }

    }
}