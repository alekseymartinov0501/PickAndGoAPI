using Microsoft.EntityFrameworkCore;
using PickAndGoAPI.Data;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.SalesOrders.AppService
{
    public class SalesOrdersMasterAppService
    {

        private readonly DataContext _context;

        public SalesOrdersMasterAppService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SaleOrder>> GetSaleOrders()
        {
            List<SaleOrder> saleOrders = await _context.SaleOrders.ToListAsync();
            return saleOrders;
        }

        public async Task<SaleOrder> GetSaleOrder(int id)
        {
            SaleOrder saleOrder = await _context.SaleOrders.FirstOrDefaultAsync(x => x.Id == id);
            return saleOrder;
        }

        public void AddSaleOrder(SaleOrder saleOrder)
        {
            _context.AddAsync(saleOrder);
            _context.SaveChanges();
        }

        public async Task<string> DeleteSaleOrder(int id)
        {
            SaleOrder saleOrder = await _context.SaleOrders.FirstOrDefaultAsync(x => x.Id == id);
            if(saleOrder == null)
            {
                return "La orden de compra no existe";
            }
            _context.SaleOrders.Remove(saleOrder);
            return "La orden de compra se ha eliminado";
        }
    }
}
