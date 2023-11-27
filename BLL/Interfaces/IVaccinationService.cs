using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IVaccinationService : IDisposable
    {
        Task AddVaccination(VaccinationDTO vaccinationDto);
        Task UpdateVaccination(VaccinationDTO vaccinationDto);
        Task RemoveVaccination(int vaccinationId);
        Task<VaccinationDTO> GetVaccinationById(int vaccinationId);
        Task<IEnumerable<VaccinationDTO>> GetAllVaccinationsAsync();
    }

}
