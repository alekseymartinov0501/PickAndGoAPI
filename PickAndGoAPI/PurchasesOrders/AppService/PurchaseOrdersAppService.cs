using PickAndGoAPI.Data;
using PickAndGoAPI.InventoryControl.AppService;
using PickAndGoAPI.InventoryControl.Request;
using PickAndGoAPI.Models;
using PickAndGoAPI.PurchasesOrders.Request;
using PickAndGoAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.PurchasesOrders.AppService
{
    public class PurchaseOrdersAppService
    {
        private readonly DataContext _context;
        private readonly InventoryAppService _inventoryAppService;

        public PurchaseOrdersAppService(DataContext context, InventoryAppService inventoryAppService)
        {
            _context = context;
            _inventoryAppService = inventoryAppService;
        }

        public PurchasesOrder CreateNewPurchaseOrder(PurchaseOrderRequest request)
        {
            PurchasesOrder order = new PurchasesOrder
            {
                Status = StatusStrings.Created,
                GrandTotal = request.PurchaseOrder.GrandTotal,
                Date = DateTime.Now,
                ProviderId = request.PurchaseOrder.ProviderId
            };

            _context.PurchasesOrders.Add(order);

            request.PurchaseOrder.PurchasesDetails.ForEach(x =>
            {
                PurchasesDetail detail = new PurchasesDetail
                {
                    IdProduct = x.IdProduct,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    OrderId = order.Id,
                    Total = x.Total
                };

                _context.PurchasesDetails.Add(detail);

                var inventory = new InventoryRequest
                {
                    ProfitPercentage = detail.ProfitPercentage,
                    PurchaseDetail = detail
                };

                _inventoryAppService.AddInventory(inventory);

            });

            _context.SaveChanges();

          
            return order;
        }
    }
}
