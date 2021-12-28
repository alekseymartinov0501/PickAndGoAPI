using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickAndGoAPI.Data;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Categories.AppService
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly CategoryMasterAppService _categoryMasterAppService;

        public CategoriesController(CategoryMasterAppService categoryMasterAppService, DataContext context)
        {
            _categoryMasterAppService = categoryMasterAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var response = await _categoryMasterAppService.GetCategories();
            return response;
        }
        
       [HttpGet("{id}")]
       public async Task<Category> GetCategory(int id)
       {
            var res = await _categoryMasterAppService.GetCategory(id);
            return res;
       }


       [HttpPost]
       public ActionResult<Category> PostCategory(Category category)
        {
            _categoryMasterAppService.AddCategory(category);

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        [HttpPut]
        public IActionResult PutCategory(Category category)
        {
            _categoryMasterAppService.UpdateCategory(category);
            return NoContent();
        }
    }
}
