
using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccountService : IDisposable
    {
        Task<ClaimsIdentity> Register(UserDTO userDTO);

        Task<ClaimsIdentity> Login(UserDTO userDTO);


    }
}
