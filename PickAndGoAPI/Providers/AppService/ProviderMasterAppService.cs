using Microsoft.EntityFrameworkCore;
using PickAndGoAPI.Data;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Providers.AppService
{
    public class ProviderMasterAppService
    {
        private readonly DataContext _context;

        public ProviderMasterAppService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Provider>> GetProviders()
        {
            List<Provider> providers = await _context.Providers.ToListAsync();
            return providers;
        }

        public async Task<Provider> GetProviders(int id)
        {
            Provider provider = await _context.Providers.FirstOrDefaultAsync(x => x.Id == id);
            return provider;
        }

        public void AddProvider(Provider provider)
        {
            _context.AddAsync(provider);
        }

        public void UpdateProvider(Provider provider)
        {
            _context.Entry(provider).State = EntityState.Modified;
        }

        public async Task<string> DeleteProvider(int id)
        {
            Provider provider = await _context.Providers.FirstOrDefaultAsync(x => x.Id == id);
            if (provider == null )
            {
                return "El proveedor no existe";
            }
            _context.Providers.Remove(provider);
                return "El proveedor se ha eliminado";
        }
    }
}
