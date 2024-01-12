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

    public void UpdateCategory(Category categoryFromFront)
    {
        _categoryRepository.Update(categoryFromFront);
    }

    public Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return _categoryRepository.GetCategoriesAsync();
    }

    public Task<Category> GetCategoryByIdAsync(int id)
    {
        return _categoryRepository.GetCategoryByIdAsync(id);
    }

   
}
