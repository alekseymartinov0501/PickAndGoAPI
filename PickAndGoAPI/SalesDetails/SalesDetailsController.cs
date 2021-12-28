using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickAndGoAPI.Models;
using PickAndGoAPI.SalesDetails.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.SalesDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesDetailsController : Controller
    {

        private readonly SalesDetailsMasterAppService _salesDetailsMasterAppService;

        public SalesDetailsController(SalesDetailsMasterAppService salesDetailsMasterAppService)
        {
            _salesDetailsMasterAppService = salesDetailsMasterAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<SaleDetail>> GetSalesDetails()
        {
            var response = await _salesDetailsMasterAppService.GetSaleDetails();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<SaleDetail> GetSalesDetail(int id)
        {
            var res = await _salesDetailsMasterAppService.GetSaleDetail(id);
            return res;
        }

        [HttpPost]
        public ActionResult<SaleDetail> PostSaleDetail(SaleDetail saleDetail)
        {
            {
                _salesDetailsMasterAppService.AddSaleDetail(saleDetail);
                return CreatedAtAction("GetSaleDetail", new { id = saleDetail.Id }, saleDetail);
            }
        }
    }
}
