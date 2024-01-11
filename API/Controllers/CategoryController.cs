using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TimeSheet.Data.Entities;
using API.DTO;
using TimeSheet.Domain.Model;
using AutoMapper;
using TimeSheet.Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.OpenApi.Models;

namespace API.Controllers
{
    [Route("api/category")]
    public class CategoryController
    {

        private readonly ICategoryService _categoryService;
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;

         public CategoryController(IMapper mapper, ICategoryService categoryService, ICategoryRepository categoryRepository)
         {
            _mapper = mapper;
            _categoryService = categoryService;
            _categoryRepository = categoryRepository;
         }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        [HttpGet("{id}")]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<CategoryDTO> GetCategoryByIdAsync(int id) 
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            //if (category == null) return null;
            return _mapper.Map<CategoryDTO>(category);
        }
    }
}