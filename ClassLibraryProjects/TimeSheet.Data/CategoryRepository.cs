using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TimeSheet.Domain;

namespace TimeSheet.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TimeSheetDbContext _timeSheetDbContext;

        public CategoryRepository( TimeSheetDbContext timeSheetDbContext)
        {
            _timeSheetDbContext = timeSheetDbContext;
        }

        public async Task<IReadOnlyList<Domain.CategoryEntity>> GetCategoriesAsync() 
        {
            return await _timeSheetDbContext.Categories.ToListAsync();
        }
        
        
    }
}