using Microsoft.EntityFrameworkCore;
using PickAndGoAPI.Data;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Aisles.AppService
{
    public class AisleMasterAppService
    {
        private readonly DataContext _context;

        public AisleMasterAppService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Aisle>> GetAisles()
        {
            List<Aisle> aisles = await _context.Aisles.ToListAsync();
            return aisles;
        }

        public async Task<Aisle> GetAisle(int id)
        {
            Aisle aisle = await _context.Aisles.FirstOrDefaultAsync(x => x.Id == id);
            return aisle;
        }

        public void AddAisle(Aisle aisle)
        {
            _context.AddAsync(aisle);
            _context.SaveChanges();
        }

        public void UpdateAisle(Aisle aisle)
        {
            _context.Entry(aisle).State = EntityState.Modified;
        }

        public async Task<string>DeleteAisle(int id)
        {
            Aisle aisle = await _context.Aisles.FirstOrDefaultAsync(x => x.Id == id);
            if (aisle == null)
            {
                return "El pasillo no existe"; 
            }
            _context.Aisles.Remove(aisle);
            return "El pasillo se ha eliminado";

        }
           
    }
}
