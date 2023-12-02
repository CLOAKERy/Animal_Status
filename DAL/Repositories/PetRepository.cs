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
    }
}
