using Microsoft.EntityFrameworkCore;
using PickAndGoAPI.Data;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.SequencesAisles.AppService
{
    public class SequencesAislesMasterAppService
    {
        private readonly DataContext _context;

        public SequencesAislesMasterAppService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SequenceAisle>> GetSequenceAisles()
        {
            List<SequenceAisle> sequenceAisles = await _context.SequenceAisles.ToListAsync();
            return sequenceAisles;
        }

        public async Task<SequenceAisle> GetSequenceAisle(int id)
        {
            SequenceAisle sequenceAisle = await _context.SequenceAisles.FirstOrDefaultAsync(x => x.Id == id);
            return sequenceAisle;
        }

        public void AddSequenceAisle(SequenceAisle sequenceAisle)
        {
            _context.AddRangeAsync(sequenceAisle);
            _context.SaveChanges();
        }


        public async Task<string> DeleteSequenceAisle(int id)
        {
            SequenceAisle sequenceAisle = await _context.SequenceAisles.FirstOrDefaultAsync(x => x.Id == id);
            if(sequenceAisle == null)
            {
                return "La secuencia del pasillo no existe";
            }
            _context.SequenceAisles.Remove(sequenceAisle);
            return "La secuencia del pasillo ha sido eliminada";
        }
    }
}
