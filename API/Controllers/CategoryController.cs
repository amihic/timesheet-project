using Microsoft.AspNetCore.Mvc;
using API.DTO;
using AutoMapper;
using TimeSheet.Domain.Interfaces;
using API.Errors;
using Microsoft.AspNetCore.Http.HttpResults;
using TimeSheet.Data.Entities;
using TimeSheet.Domain.Model;
using TimeSheet.Domain.Helpers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    //[Authorize]
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

        [Authorize(Roles = "Admin")]
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
            var categoryToUpdate = _mapper.Map<CategoryDTO, Category>(categoryDto);
            _categoryService.UpdateCategory(categoryToUpdate);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            _categoryService.DeleteCategory(id);

            return Ok();
        }

        [Authorize(Roles="Worker")]
        [HttpGet("/allCategories")]
        //[API.CustomAuthorizationFilter.CustomAuthorizationFilter]
        public async Task<IActionResult> GetCategoriesAsync([FromQuery] SearchParamsForCliCatProUseDTO searchParams)
        {
            var parameters = _mapper.Map<SearchParamsForCliCatProUseDTO, SearchParams>(searchParams);
            
            var categories = await _categoryService.GetCategoriesAsync(parameters);

            var categoriesToReturn = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);

            return Ok(categoriesToReturn);
        }
    }
}