using TimeSheet.Domain;

namespace TimeSheet.Service;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;


    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IReadOnlyList<CategoryEntity>> GetCategoriesAsync()
    {
        return (IReadOnlyList<CategoryEntity>) await _categoryRepository.GetCategoriesAsync();

    }
}
