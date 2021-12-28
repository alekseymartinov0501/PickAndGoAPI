using Microsoft.EntityFrameworkCore;
using PickAndGoAPI.Data;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.SalesDetails.AppService
{
    public class SalesDetailsMasterAppService
    {
        private readonly DataContext _context;

        public SalesDetailsMasterAppService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SaleDetail>> GetSaleDetails()
        {
            List<SaleDetail> saleDetails = await _context.SaleDetails.ToListAsync();
            return saleDetails;

        }

        public async Task<SaleDetail> GetSaleDetail(int id)
        {
            SaleDetail saleDetail = await _context.SaleDetails.FirstOrDefaultAsync(x => x.Id == id);
            return saleDetail;
        }

        public void AddSaleDetail(SaleDetail saleDetails)
        {
            _context.AddAsync(saleDetails);
            _context.SaveChanges();
        }

        public async Task<string> DeleteSaleDetail(int id)
        {
            SaleDetail saleDetails = await _context.SaleDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (saleDetails == null)
            {
                return "El detalle de la compra no existe";
            }
            _context.SaleDetails.Remove(saleDetails);
            return "El detalle de la venta se ha eliminado";
        }
    }
}
