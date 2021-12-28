using Microsoft.AspNetCore.Mvc;
using PickAndGoAPI.Models;
using PickAndGoAPI.QualityRegistries.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.QualityRegistries
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualityRegistryController : Controller
    {
       
        
        private readonly QualityRegistryMasterAppService _qualityMasterAppService;

        
        
        public QualityRegistryController(QualityRegistryMasterAppService qualityRegistriesMasterAppService)
        {
            _qualityMasterAppService = qualityRegistriesMasterAppService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<QualityRegistry>> GetQualityRegistries()
       
        {
            var response = await _qualityMasterAppService.GetQualityRegistries();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<QualityRegistry> GetQualityRegistry(int id)
        {
            var res = await _qualityMasterAppService.GetQualityById(id);
            return res;
        }

        [HttpPost]
        public ActionResult<QualityRegistry> PostQualityRegistry(QualityRegistry qualityRegistry)
        {
            _qualityMasterAppService.AddQualityRegistry(qualityRegistry);
            return CreatedAtAction("GetQualityRegistry", new { id = qualityRegistry.Id }, qualityRegistry);
        }

    }
}
