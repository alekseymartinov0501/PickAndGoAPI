using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickAndGoAPI.Models;
using PickAndGoAPI.PurchasesOrders.AppService;
using PickAndGoAPI.PurchasesOrders.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.PurchasesOrders
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesOrdersController : Controller
    {
        private readonly PurchasesOrdersMasterAppService _purchasesOrderMasterAppService;
        private readonly PurchaseOrdersAppService _purchaseOrdersAppService;

        public PurchasesOrdersController(PurchasesOrdersMasterAppService purchasesOrdersMasterAppService, PurchaseOrdersAppService purchaseOrdersAppService)
        {
            _purchasesOrderMasterAppService = purchasesOrdersMasterAppService;
            _purchaseOrdersAppService = purchaseOrdersAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<PurchasesOrder>> GetPurchasesOrders()
        {
            var response = await _purchasesOrderMasterAppService.GetPurchasesOrders();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<PurchasesOrder> GetPurchasesOrder(int id)
        {
            var res = await _purchasesOrderMasterAppService.GetPurchasesOrder(id);
            return res;
        }

        [HttpPost]
        public ActionResult<PurchasesOrder> PostPurchasesOrder(PurchasesOrder purchasesOrder)
        {
            _purchasesOrderMasterAppService.AddPurchasesOrder(purchasesOrder);
            return CreatedAtAction("GetPurchasesOrder", new { id = purchasesOrder.Id }, purchasesOrder);
        }

        [HttpPost("create-purchase-order")]
        public ActionResult<PurchasesOrder> CreatePurchaseOrder(PurchaseOrderRequest request)
        {
            var result = _purchaseOrdersAppService.CreateNewPurchaseOrder(request);
            return Ok(result);
        }
    }
}
