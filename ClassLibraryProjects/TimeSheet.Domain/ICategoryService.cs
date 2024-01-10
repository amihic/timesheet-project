using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Domain.Model;

namespace TimeSheet.Domain
{
    public interface ICategoryService {
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}