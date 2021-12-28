using Microsoft.EntityFrameworkCore;
using PickAndGoAPI.Data;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.QualityRegistries.AppService
{
    public class QualityRegistryMasterAppService
    {
        private readonly DataContext _context;

        public QualityRegistryMasterAppService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QualityRegistry>> GetQualityRegistries()
        {
            List<QualityRegistry> qualityRegistries = await _context.QualityRegistries.ToListAsync();
            return qualityRegistries;
        }

        public async Task<QualityRegistry> GetQualityById(int id)
        {
            QualityRegistry qualityRegistry = await _context.QualityRegistries.FirstOrDefaultAsync(x => x.Id == id);
            return qualityRegistry;
        }

        public void AddQualityRegistry(QualityRegistry qualityRegistry)
        {
            _context.Add(qualityRegistry);
            _context.SaveChanges();
        }

        public void UpdateQualityRegistry(QualityRegistry qualityRegistry)
        {
            _context.Entry(qualityRegistry).State = EntityState.Modified;
        }

        public async Task<string>DeleteQualityRegistry(int id)
        {
            QualityRegistry qualityRegistry = await _context.QualityRegistries.FirstOrDefaultAsync(x => x.Id == id);
            if (qualityRegistry == null)
            {
                return "El Registro sanitario no existe";

            }
            _context.QualityRegistries.Remove(qualityRegistry);
            return "Registro de calidad eliminado";
        }

    }
}
