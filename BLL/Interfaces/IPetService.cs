using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPetService : IDisposable
    {
        Task AddPet(PetDTO petDto);
        Task UpdatePet(PetDTO petDto);
        Task RemovePet(int petId);
        Task<PetDTO> GetPetById(int petId);
        Task<IEnumerable<PetDTO>> GetAllPetsAsync();
        Task<IEnumerable<PetDTO>> GetAllPetsWithTypesAsync();
    }

}
