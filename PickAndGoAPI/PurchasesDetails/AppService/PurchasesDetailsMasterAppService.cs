using Microsoft.EntityFrameworkCore;
using PickAndGoAPI.Data;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.PurchasesDetails.AppService
{
    public class PurchasesDetailsMasterAppService
    {
        private readonly DataContext _context;

        public PurchasesDetailsMasterAppService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PurchasesDetail>> GetPurchasesDetails()
        {
            List<PurchasesDetail> purchasesDetails = await _context.PurchasesDetails.ToListAsync();
            return purchasesDetails;
        }

        public async Task<PurchasesDetail> GetPurchaseDetail(int id)
        {
            PurchasesDetail purchasesDetail = await _context.PurchasesDetails.FirstOrDefaultAsync(x => x.Id == id);
            return purchasesDetail;
        }

        public void AddPurchasesDetail(PurchasesDetail purchasesDetail)
        {
            _context.AddAsync(purchasesDetail);
        }

        public void UpdatePurchasesDetail(PurchasesDetail purchasesDetail)
        {
            _context.Entry(purchasesDetail).State = EntityState.Modified;
        }

        public async Task<string> DeletePurchasesDetail(int id)
        {
            PurchasesDetail purchasesDetail = await _context.PurchasesDetails.FirstOrDefaultAsync(x => x.Id == id);

            if (purchasesDetail == null)
            {
                return "La orden de compra no existe";
            }
            _context.PurchasesDetails.Remove(purchasesDetail);
            return "La orden de compra fue eliminada";
        }

    }
}
