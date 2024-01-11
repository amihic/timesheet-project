using Microsoft.AspNetCore.Mvc;
using API.DTO;
using AutoMapper;
using TimeSheet.Domain.Interfaces;
using API.Errors;
using Microsoft.AspNetCore.Http.HttpResults;
using TimeSheet.Data.Entities;
using TimeSheet.Domain.Model;

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
            var categories = await _categoryService.GetCategoriesAsync();
            var categoriesToReturn = _mapper.Map<IEnumerable<Category> ,IEnumerable<CategoryDTO>>(categories);
            return categoriesToReturn;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDTO>> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            /*if (category == null) 
            {
                return NotFound(new ApiResponse(404));
            }*/
            var categoryToReturn = _mapper.Map<CategoryDTO>(category);
            
            return categoryToReturn;
        }

        
    }
}