using Microsoft.EntityFrameworkCore;
using PickAndGoAPI.Data;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Distributions.AppService
{
    public class DistributionMasterAppService
    {
        private readonly DataContext _context;

        public DistributionMasterAppService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Distribution>> GetDistributions()
        {
            List<Distribution> distributions = await _context.Distributions.ToListAsync();
            return distributions;
        }

        public async Task <Distribution> GetDistribution(int id)
        {
            Distribution distribution = await _context.Distributions.FirstOrDefaultAsync(x => x.id == id);
            return distribution;
        }

        public void AddDistribution(Distribution distribution )
        {
            _context.AddAsync(distribution);
            _context.SaveChanges();
        }

        public void UpdateDistribution(Distribution distribution)
        {
            _context.Entry(distribution).State = EntityState.Modified;
        }

        public async Task<string> DeleteDistribution(int id)
        {
            Distribution distribution = await _context.Distributions.FirstOrDefaultAsync(x => x.id == id);
            if (distribution == null)
            {
                return "La distribucion no existe";
            }
            _context.Distributions.Remove(distribution);
            return "La distribucion se ah eliminado";
        }

    }
}
