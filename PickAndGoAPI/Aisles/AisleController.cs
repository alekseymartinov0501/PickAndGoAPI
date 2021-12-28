using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickAndGoAPI.Aisles.AppService;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Aisles
{
    [Route("api/[controller]")]
    [ApiController]
    public class AisleController : Controller
    {
        private readonly AisleMasterAppService _aisleMasterAppService;

        public AisleController(AisleMasterAppService aisleMasterAppService)
        {
            _aisleMasterAppService = aisleMasterAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<Aisle>> GetCategories()
        {
            var response = await _aisleMasterAppService.GetAisles();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<Aisle> GetAisle(int id)
        {
            var res = await _aisleMasterAppService.GetAisle(id);
            return res;
        }
        [HttpPost]
        public ActionResult<Aisle> PostAisle(Aisle aisle)
        {
            _aisleMasterAppService.AddAisle(aisle);
            return CreatedAtAction("GetAisle", new { id = aisle.Id }, aisle);
        }



    }

}
