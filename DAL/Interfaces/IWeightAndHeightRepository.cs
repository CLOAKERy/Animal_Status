using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IWeightAndHeightRepository : IRepository<WeightAndHeight>
    {
        public Task<IEnumerable<WeightAndHeight>> GetAllSortedAsync(int petId);
    }
}
