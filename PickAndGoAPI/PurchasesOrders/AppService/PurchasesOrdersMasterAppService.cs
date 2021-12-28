using Microsoft.EntityFrameworkCore;
using PickAndGoAPI.Data;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.PurchasesOrders.AppService
{
    public class PurchasesOrdersMasterAppService
    {
        private readonly DataContext _context;

        public PurchasesOrdersMasterAppService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PurchasesOrder>> GetPurchasesOrders()
        {
            List<PurchasesOrder> purchasesOrders = await _context.PurchasesOrders.ToListAsync();
            return purchasesOrders;
        }

        public async Task<PurchasesOrder> GetPurchasesOrder(int id)
        {
            PurchasesOrder purchasesOrder = await _context.PurchasesOrders.FirstOrDefaultAsync(x => x.Id == id);
            return purchasesOrder;
        }

        public void AddPurchasesOrder(PurchasesOrder purchasesOrder)
        {
            _context.AddAsync(purchasesOrder);
            _context.SaveChanges();
        }

        public void UpdatePurchasesOrder(PurchasesOrder purchasesOrder)
        {
            _context.Entry(purchasesOrder).State = EntityState.Modified;
        }

        public async Task<string> DeletePurchasesOrder(int id)
        {
            PurchasesOrder purchasesOrder = await _context.PurchasesOrders.FirstOrDefaultAsync(x => x.Id == id);
            if (purchasesOrder == null)
            {
                return "La orden de compra no existe";
            }
            _context.PurchasesOrders.Remove(purchasesOrder);
            return "La orden de compra ah sido eliminada";
        }
    }
}
