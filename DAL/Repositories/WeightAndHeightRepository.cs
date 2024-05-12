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
    internal class WeightAndHeightRepository : BaseRepository<WeightAndHeight>, IWeightAndHeightRepository
    {
        public WeightAndHeightRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<WeightAndHeight>> GetAllSortedAsync(int petId)
        {
            return await _dbContext.Set<WeightAndHeight>()
                .Where(m => m.PetId == petId) // Фильтрация по PetId
                .OrderBy(m => m.MeasurementDate)
                .ToListAsync();
        }
    }
}
