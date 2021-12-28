using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickAndGoAPI.Distributions.AppService;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Distributions
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributionController : ControllerBase
    {
        private readonly DistributionMasterAppService _distributionMasterAppService;

        public DistributionController(DistributionMasterAppService distributionMasterAppService)
        {
            _distributionMasterAppService = distributionMasterAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<Distribution>> GetDistributions()
        {
            var response = await _distributionMasterAppService.GetDistributions();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<Distribution> GetDistribution(int id)
        {
            var res = await _distributionMasterAppService.GetDistribution(id);
            return res;
        }
         [HttpPost]
        public ActionResult<Distribution> PostDistribution(Distribution distribution)
        {
            _distributionMasterAppService.AddDistribution(distribution);
            return CreatedAtAction("GetDistribution", new { id = distribution.id }, distribution);
        }

    }
}
