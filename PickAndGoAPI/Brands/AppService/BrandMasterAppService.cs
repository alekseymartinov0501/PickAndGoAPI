using Microsoft.EntityFrameworkCore;
using PickAndGoAPI.Data;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Brands.AppService
{
    public class BrandMasterAppService
    {
        private readonly DataContext _contex;

        public BrandMasterAppService(DataContext context)
        {
            _contex = context;
        }

        public async Task<IEnumerable<Brand>> GetBrands()
        {
            List<Brand> brands = await _contex.Brands.ToListAsync();
            return brands;
        }

        public async Task<Brand> GetBrand(int id)
        {
            Brand brand = await _contex.Brands.FirstOrDefaultAsync(x => x.Id == id);
            return brand;
        }

        public void AddBrand( Brand brand)
        {
            _contex.AddAsync(brand);
            _contex.SaveChanges();
        }

        public void UpdateBrand(Brand brand)
        {
            _contex.Entry(brand).State = EntityState.Modified;
        }

        public async Task<string>DeleteBrand(int id)
        {
            Brand brand = await _contex.Brands.FirstOrDefaultAsync(x => x.Id == id);
            if(brand == null)
            {
                return "La marca no esxiste";
            }
            _contex.Brands.Remove(brand);
            return "La Marca se ha eliminado";
        }
    }
}
