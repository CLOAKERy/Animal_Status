using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetLastAsync();
        public Task<User> GetByEmailAsync(string email);
    }
}
