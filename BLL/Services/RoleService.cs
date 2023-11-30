using Animal_Status;
using AnimalRepair.BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddRole(RoleDTO roleDto)
        {
            if (string.IsNullOrEmpty(roleDto.RoleName))
                throw new ValidationException("Название роли не может быть пустым", "");

            var role = _mapper.Map<RoleDTO, Role>(roleDto);
            await _unitOfWork.Roles.CreateAsync(role);
            _unitOfWork.Save();
        }

        public async Task UpdateRole(RoleDTO roleDto)
        {
            Role updatedRole = _mapper.Map<RoleDTO, Role>(roleDto);
            await _unitOfWork.Roles.UpdateAsync(updatedRole);
            _unitOfWork.Save();
        }

        public async Task RemoveRole(int roleId)
        {
            Role role = await _unitOfWork.Roles.GetAsync(roleId);
            if (role == null)
                throw new ValidationException("Роль не найдена", "");

            await _unitOfWork.Roles.DeleteAsync(roleId);
            _unitOfWork.Save();
        }

        public async Task<RoleDTO> GetRoleById(int roleId)
        {
            Role role = await _unitOfWork.Roles.GetAsync(roleId);
            if (role == null)
                throw new ValidationException("Роль не найдена", "");

            RoleDTO roleDto = _mapper.Map<Role, RoleDTO>(role);
            return roleDto;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync()
        {
            IEnumerable<Role> roles = await _unitOfWork.Roles.GetAllAsync();
            return _mapper.Map<IEnumerable<Role>, IEnumerable<RoleDTO>>(roles);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
