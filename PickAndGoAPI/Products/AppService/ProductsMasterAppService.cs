using Microsoft.EntityFrameworkCore;
using PickAndGoAPI.Data;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Products.AppService
{
    public class ProductsMasterAppService
    {
        private readonly DataContext _context;
        
        public ProductsMasterAppService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int id)
        {
            List<Product> products = await _context.Products.Where(x => x.CategoryId == id && x.Active == true).Include(x => x.Category).Include(x => x.Brand).ToListAsync();

            return products;
        }

        public async Task<Product> GetProduct(int id)
        {
            Product product = await _context.Products.Include(x => x.Brand).Include(x => x.Category).Include(x => x.Distribution).Include(x => x.QualityRegistry).FirstOrDefaultAsync(x => x.id == id);
            return product;
        }

        public void AddProduct( Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<string> DeleteProduct(int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.id == id);

            if (product == null)
            {
                return "El producto no existe";
            }
            _context.Products.Remove(product);
            return "Producto Eliminado";
        }

    }

}
