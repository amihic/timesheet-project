using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TimeSheet.Data.Entities;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Interfaces;
using TimeSheet.Domain.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public void DeleteCategory(int id)//logicko brisanje
        {
            var categoryToDelete = _timeSheetDbContext.Categories.Find(id);
            categoryToDelete.IsDeleted = true;
            _timeSheetDbContext.Categories.Update(categoryToDelete);
            SaveChanges();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(SearchParams searchParams) 
        {
            var query = _timeSheetDbContext.Categories.AsQueryable();

            if (searchParams.FirstLetter.HasValue)
            {
                query = query.Where(category => EF.Functions.Like(category.Name, $"{searchParams.FirstLetter}%"));
            }
            if (!string.IsNullOrEmpty(searchParams.SearchText))
            {
                query = query.Where(category => EF.Functions.Like(category.Name, $"%{searchParams.SearchText}%"));
            }

            var totalCategories = await query.CountAsync();

            var paginatedCategories = await query
                .Skip((searchParams.PageIndex - 1) * searchParams.PageSize)
                .Take(searchParams.PageSize)
                .ToListAsync();

            var pagination = new Pagination<CategoryEntity>(searchParams.PageIndex, searchParams.PageSize, totalCategories, paginatedCategories);

            var categoriesToReturn = _mapper.Map<IEnumerable<CategoryEntity>, IEnumerable<Category>>(pagination.Data);

            return categoriesToReturn;
        }

        public void CreateCategory(Category category)
        {
            var categoryToAdd = _mapper.Map<Category, CategoryEntity>(category);
            _timeSheetDbContext.Categories.Add(categoryToAdd);
            SaveChanges();
            
        }

        public void SaveChanges()
        {
            _timeSheetDbContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = _timeSheetDbContext.Categories.Find(category.Id);
            var categoryChanges = _mapper.Map<Category, CategoryEntity>(category);

            categoryToUpdate.Name = categoryChanges.Name;

            _timeSheetDbContext.Categories.Update(categoryToUpdate);

            SaveChanges();
            
        }

    }
}