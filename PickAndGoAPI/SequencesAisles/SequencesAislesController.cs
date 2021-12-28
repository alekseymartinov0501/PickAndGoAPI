using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickAndGoAPI.Models;
using PickAndGoAPI.SequencesAisles.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.SequencesAisles
{
    [Route("api/[controller]")]
    [ApiController]
    public class SequencesAislesController : Controller
    {
        private readonly SequencesAislesMasterAppService _sequencesAisleMasterAppService;

        public SequencesAislesController(SequencesAislesMasterAppService sequencesAislesMasterAppService)
        {
            _sequencesAisleMasterAppService = sequencesAislesMasterAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<SequenceAisle>> GetSequenceAisles()
        {
            var response = await _sequencesAisleMasterAppService.GetSequenceAisles();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<SequenceAisle> GetSequenceAisle(int id)
        {
            var res = await _sequencesAisleMasterAppService.GetSequenceAisle(id);
            return res;
        }

        [HttpPost]
        public ActionResult<SequenceAisle> PostSequenceAisle(SequenceAisle sequenceAisle)
        {
            _sequencesAisleMasterAppService.AddSequenceAisle(sequenceAisle);
            return CreatedAtAction("GetSequenceAisle", new { id = sequenceAisle.Id }, sequenceAisle);
        }

    }
}
