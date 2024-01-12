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

    public int GenerateID(Category category) 
    {
        return category.Id = _categoryRepository.MaxId() + 1;   
    }

    public void CreateCategory(Category newCategory)
    {  
        newCategory.Id = GenerateID(newCategory);
        _categoryRepository.Create(newCategory);
    }

    public void UpdateCategory(Category category)
    {
        _categoryRepository.UpdateCategory(category);
    }

    public Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return _categoryRepository.GetCategoriesAsync();
    }

    public Task<Category> GetCategoryByIdAsync(int id)
    {
        return _categoryRepository.GetCategoryByIdAsync(id);
    }

    public void DeleteCategory(int id)
    {
        _categoryRepository.DeleteCategory(id);
    }
}
