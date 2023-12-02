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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<User> GetLastAsync()
        {
            var entity = await _dbContext.Set<User>().OrderByDescending(x => x.UserId).FirstOrDefaultAsync();
            return entity;
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            var customers = await FindAsync(c => c.Email == email);
            return customers.FirstOrDefault();
        }
    }
}
