using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickAndGoAPI.Models;
using PickAndGoAPI.Products.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsMasterAppService _productsMasterAppService;

        public ProductsController(ProductsMasterAppService productsMasterAppService)
        {
            _productsMasterAppService = productsMasterAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var response = await _productsMasterAppService.GetProducts();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            var res = await _productsMasterAppService.GetProduct(id);
            return res;
        }

        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            _productsMasterAppService.AddProduct(product);
            return CreatedAtAction("GetProduct", new { id = product.id }, product);
        }

        [HttpPut]
        public IActionResult PutProduct(Product product)
        {
            _productsMasterAppService.UpdateProduct(product);
            return NoContent();
        }

        [HttpGet]
        [Route("get-by-category-id/{id}")]
        public async Task<IEnumerable<Product>> GetProductsbyCategory(int id)
        {
            var response = await _productsMasterAppService.GetProductsByCategory(id);
            return response;
        }


    }
}
