using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TimeSheet.Domain;

namespace API.Controllers
{
    [Route("[controller]")]
    public class CategoryController
    {

         private readonly ICategoryService _categoryService;

         public CategoryController(ICategoryService categoryService)
         {
             _categoryService = categoryService;
         }

        [HttpGet]
        public string GetCategory()
        {
            return  _categoryService.GetCategory();
        }
    }
}