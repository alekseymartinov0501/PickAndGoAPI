using Microsoft.EntityFrameworkCore;
using PickAndGoAPI.Data;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Categories.AppService
{
    public class CategoryMasterAppService
    {
        private readonly DataContext _context;

        public CategoryMasterAppService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategory(int id)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return category;
        }

        public void AddCategory(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<string>DeleteCategory(int id)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return "La categoria no existe";
            }
            _context.Categories.Remove(category);
            return "La categoria se ah eliminado";
        }

    }
}
