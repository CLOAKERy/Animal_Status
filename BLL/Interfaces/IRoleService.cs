using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRoleService : IDisposable
    {
        Task AddRole(RoleDTO roleDto);
        Task UpdateRole(RoleDTO roleDto);
        Task RemoveRole(int roleId);
        Task<RoleDTO> GetRoleById(int roleId);
        Task<IEnumerable<RoleDTO>> GetAllRolesAsync();
    }

}
