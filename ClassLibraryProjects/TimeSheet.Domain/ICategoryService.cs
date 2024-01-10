using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Domain
{
    public interface ICategoryService {
        Task<IReadOnlyList<CategoryEntity>> GetCategoriesAsync();
    }
}