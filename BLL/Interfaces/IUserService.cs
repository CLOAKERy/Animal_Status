using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task AddUser(UserDTO userDto);
        Task UpdateUser(UserDTO userDto);
        Task RemoveUser(int userId);
        Task<UserDTO> GetUserById(int userId);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
    }

}
