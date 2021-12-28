using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickAndGoAPI.Models;
using PickAndGoAPI.Providers.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Providers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : Controller
    {
        private readonly ProviderMasterAppService _providerMasterAppService;

        public ProviderController(ProviderMasterAppService providerMasterAppService)
        {
            _providerMasterAppService = providerMasterAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<Provider>> GetProviders()
        {
            var response = await _providerMasterAppService.GetProviders();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<Provider> GetProvider(int id)
        {
            var res = await _providerMasterAppService.GetProviders(id);
            return res;
        }

        [HttpPost]
        public ActionResult<Provider> PostProvider(Provider provider)
        {
            _providerMasterAppService.AddProvider(provider);
            return CreatedAtAction("GetProvider", new { id = provider.Id }, provider);
        }
    }
}
