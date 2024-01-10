using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TimeSheet.Data.Entities;
using TimeSheet.Domain;
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

        public async Task<IEnumerable<Category>> GetCategoriesAsync() 
        {
            return await _timeSheetDbContext.Categories.ToListAsync();
        }
        
        
    }
}