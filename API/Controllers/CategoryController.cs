using Microsoft.AspNetCore.Mvc;
using API.DTO;
using AutoMapper;
using TimeSheet.Domain.Interfaces;
using API.Errors;
using Microsoft.AspNetCore.Http.HttpResults;
using TimeSheet.Data.Entities;
using TimeSheet.Domain.Model;
using TimeSheet.Domain.Helpers;

namespace API.Controllers
{
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryDTO newCategoryDto)
        {
            var newCategory = _mapper.Map<CreateCategoryDTO, Category>(newCategoryDto);
            _categoryService.CreateCategory(newCategory);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCategory([FromBody] CategoryDTO categoryDto)
        {
            var categoryFromFront = _mapper.Map<CategoryDTO, Category>(categoryDto);
            _categoryService.UpdateCategory(categoryFromFront);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            _categoryService.DeleteCategory(id);

            return Ok();
        }

        [HttpGet("/all")]
        public async Task<IActionResult> GetCategoriesAsync([FromQuery] SearchParams searchParams)
        {

            var categories = await _categoryService.GetCategoriesAsync(searchParams);

            if (categories == null) return NotFound();

            var categoriesToReturn = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);

            return Ok(categoriesToReturn);
        }


    }
}