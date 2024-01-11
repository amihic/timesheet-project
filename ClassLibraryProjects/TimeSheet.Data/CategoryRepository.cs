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
            //return _mapper.Map<CategoryEntity, Category>(categories);
            return categoriesToReturn;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await _timeSheetDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            var categoryToReturn = _mapper.Map<Category>(category);
            return categoryToReturn;
        }

  
    }
}