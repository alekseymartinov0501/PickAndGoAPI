
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickAndGoAPI.Brands.AppService;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Brands
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly BrandMasterAppService _brandMasterAppService;

        public BrandController(BrandMasterAppService brandMasterAppService)
        {
            _brandMasterAppService = brandMasterAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<Brand>> GetBrands()
        {
            var response = await _brandMasterAppService.GetBrands();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<Brand> GetBrand(int id)
        {
            var res = await _brandMasterAppService.GetBrand(id);
            return res;
        }

        [HttpPost]
        public ActionResult<Brand>  PostBrand(Brand brand)
        {
            _brandMasterAppService.AddBrand(brand);
            return CreatedAtAction("GetBrand", new { id = brand.Id }, brand);
        }

    }
}
