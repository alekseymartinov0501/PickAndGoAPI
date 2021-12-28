using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickAndGoAPI.Models;
using PickAndGoAPI.PurchasesDetails.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.PurchasesDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesDetailsController : Controller
    {
        private readonly PurchasesDetailsMasterAppService _purchasesDetailMasterAppService;

        public PurchasesDetailsController(PurchasesDetailsMasterAppService purchasesDetailsMasterAppService)
        {
            _purchasesDetailMasterAppService = purchasesDetailsMasterAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<PurchasesDetail>> GetPurchasesDetails()
        {
            var response = await _purchasesDetailMasterAppService.GetPurchasesDetails();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<PurchasesDetail> GetPurchaseDetails(int id)
        {
            var res = await _purchasesDetailMasterAppService.GetPurchaseDetail(id);
            return res;
        }

        [HttpPost]
        public ActionResult<PurchasesDetail> PostPurchaseDetail(PurchasesDetail purchasesDetail)
        {
            _purchasesDetailMasterAppService.AddPurchasesDetail(purchasesDetail);
            return CreatedAtAction("GetPurchaseDetail", new { id = purchasesDetail.Id }, purchasesDetail);
        }
    }
}
