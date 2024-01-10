using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Domain
{
    public interface ICategoryRepository
    {
        Task<IReadOnlyList<CategoryEntity>> GetCategoriesAsync();        
    }
}