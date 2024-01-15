using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Interfaces;
using TimeSheet.Domain.Model;

namespace TimeSheet.Service;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;


    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public void CreateCategory(Category newCategory)
    {  
        _categoryRepository.Create(newCategory);
    }

    public void UpdateCategory(Category category)
    {
        _categoryRepository.UpdateCategory(category);
    }

    public Task<IEnumerable<Category>> GetCategoriesAsync(SearchParams searchParams)
    {
        return _categoryRepository.GetCategoriesAsync(searchParams);
    }

    public void DeleteCategory(int id)
    {
        _categoryRepository.DeleteCategory(id);
    }
}
