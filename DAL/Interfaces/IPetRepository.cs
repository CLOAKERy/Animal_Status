using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPetRepository : IRepository<Pet>
    {
        public Task<IEnumerable<Pet>> GetAllWithTypeAsync();
    }
}
