using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPetVaccinationService : IDisposable
    {
        Task AddPetVaccination(PetVaccinationDTO petVaccinationDto);
        Task UpdatePetVaccination(PetVaccinationDTO petVaccinationDto);
        Task RemovePetVaccination(int petVaccinationId);
        Task<PetVaccinationDTO> GetPetVaccinationById(int petVaccinationId);
        Task<IEnumerable<PetVaccinationDTO>> GetAllPetVaccinationsAsync();
    }

}
