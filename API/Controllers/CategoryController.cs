using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TimeSheet.Domain;
using TimeSheet.Data.Entities;
using API.DTO;
using TimeSheet.Domain.Model;
using AutoMapper;

namespace API.Controllers
{
    [Route("api/category")]
    public class CategoryController
    {

         private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

         public CategoryController(IMapper mapper, ICategoryService categoryService)
         {
            _mapper = mapper;
             _categoryService = categoryService;
         }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }
    }
}