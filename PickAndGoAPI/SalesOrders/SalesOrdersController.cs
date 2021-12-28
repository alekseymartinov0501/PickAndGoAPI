using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickAndGoAPI.Data;
using PickAndGoAPI.Models;
using PickAndGoAPI.SalesOrders.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.SalesOrders
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrdersController : Controller
    {
        private readonly SalesOrdersMasterAppService _salesOrdersMasterApppService;

        public SalesOrdersController(SalesOrdersMasterAppService salesOrdersMasterAppService)
        {
            _salesOrdersMasterApppService = salesOrdersMasterAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<SaleOrder>> GetSaleOrders()
        {
            var response = await _salesOrdersMasterApppService.GetSaleOrders();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<SaleOrder> GetSaleOrder(int id)
        {
            var res = await _salesOrdersMasterApppService.GetSaleOrder(id);
            return res;
        }

        [HttpPost]
        public ActionResult<SaleOrder> PostSaleOrder(SaleOrder saleOrder)
        {
            _salesOrdersMasterApppService.AddSaleOrder(saleOrder);
            return CreatedAtAction("GetSaleOrder", new { id = saleOrder.Id }, saleOrder);
        }

    }
}
