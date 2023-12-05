using Animal_Status;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class PetRepository : BaseRepository<Pet>, IPetRepository
    {
        public PetRepository(DbContext dbContext) : base(dbContext)
        {
            
        }
        public async Task<IEnumerable<Pet>> GetAllWithTypeAsync()
        {
            return await _dbContext.Set<Pet>().Include(p => p.Type).ToListAsync();
        }

        public async Task<Pet> GetPetDetailsAsync(int petId)
        {
            return await _dbContext.Set<Pet>()
            .Include(p => p.Owner)
            .Include(p => p.PetVaccinations)
                .ThenInclude(v => v.Vaccination)
            .Include(p => p.VeterinaryRecords)
            .Include(p => p.WeightAndHeights)
            .Include(p => p.Diets)
            .Include(p => p.Exercises)
            .Include(p => p.Notes)
            .Include(p => p.SleepAndRests)
            .Include(p => p.StressLevels)
            .Include(p => p.Behaviors)
            .FirstOrDefaultAsync(p => p.PetId == petId);
        }
    }
}
