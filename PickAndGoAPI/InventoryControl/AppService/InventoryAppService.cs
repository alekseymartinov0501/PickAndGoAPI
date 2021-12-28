using PickAndGoAPI.Data;
using PickAndGoAPI.InventoryControl.Request;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.InventoryControl.AppService
{
    public class InventoryAppService
    {
        private readonly DataContext _context;

        public InventoryAppService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Inventory> GetInventories()
        {
            var data = _context.Inventories.GroupBy(x => x.ProductoId).Select(f => new Inventory
            {
                ProductoId = f.Key,
                Quantity = f.Sum(x => x.Quantity)
            });

            return data;
        }

        public void AddInventory(InventoryRequest request)
        {
            var existingInventory = GetInventoryByProduct(request.PurchaseDetail.IdProduct);

            if(existingInventory == null)
            {
                var newInventory = new Inventory
                {
                    ProductoId = request.PurchaseDetail.IdProduct,
                    Quantity = request.PurchaseDetail.Quantity,
                    CurrentCost = request.PurchaseDetail.Price,
                    CurrentPrice = GetSalePrice(request.ProfitPercentage, request.PurchaseDetail.Price)
                };

                _context.Inventories.Add(newInventory);
            }

            if(existingInventory != null)
            {
                existingInventory.Quantity = existingInventory.Quantity + request.PurchaseDetail.Quantity;
                existingInventory.ProfitPercentage = request.ProfitPercentage;
                existingInventory.CurrentCost = GetAverageCost(existingInventory.CurrentCost, request.PurchaseDetail.Price);
                existingInventory.CurrentPrice = GetSalePrice(request.ProfitPercentage, existingInventory.CurrentCost);
            }

            _context.SaveChanges();

        }

        public Inventory GetInventoryByProduct(int productId)
        {
            var inventory = _context.Inventories.FirstOrDefault(x => x.ProductoId == productId);

            return inventory;
        }

        public double GetSalePrice(int profitPercentage, double cost)
        {
            var profit = GetPercentageValue(profitPercentage);
            var salePrice = cost * profit;

            if(salePrice <= 0)
            {
                return 0;
            }

            return salePrice;
        }

        public double GetPercentageValue(int percentage)
        {
            var value = (double)percentage / 100;
            return value;
        }

        public double GetAverageCost(double currentCost, double requestCost)
        {
            var averageCost = (currentCost + requestCost) / 2;

            return averageCost;
        }
    }
}
