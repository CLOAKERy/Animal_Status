using Animal_Status;
using AnimalRepair.BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class VaccinationService : IVaccinationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VaccinationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddVaccination(VaccinationDTO vaccinationDto)
        {
            if (string.IsNullOrEmpty(vaccinationDto.Name))
                throw new ValidationException("Название вакцины не может быть пустым", "");

            var vaccination = _mapper.Map<VaccinationDTO, Vaccination>(vaccinationDto);
            await _unitOfWork.Vaccinations.CreateAsync(vaccination);
            _unitOfWork.Save();
        }

        public async Task UpdateVaccination(VaccinationDTO vaccinationDto)
        {
            Vaccination updatedVaccination = _mapper.Map<VaccinationDTO, Vaccination>(vaccinationDto);
            await _unitOfWork.Vaccinations.UpdateAsync(updatedVaccination);
            _unitOfWork.Save();
        }

        public async Task RemoveVaccination(int vaccinationId)
        {
            Vaccination vaccination = await _unitOfWork.Vaccinations.GetAsync(vaccinationId);
            if (vaccination == null)
                throw new ValidationException("Вакцина не найдена", "");

            await _unitOfWork.Vaccinations.DeleteAsync(vaccinationId);
            _unitOfWork.Save();
        }

        public async Task<VaccinationDTO> GetVaccinationById(int vaccinationId)
        {
            Vaccination vaccination = await _unitOfWork.Vaccinations.GetAsync(vaccinationId);
            if (vaccination == null)
                throw new ValidationException("Вакцина не найдена", "");

            VaccinationDTO vaccinationDto = _mapper.Map<Vaccination, VaccinationDTO>(vaccination);
            return vaccinationDto;
        }

        public async Task<IEnumerable<VaccinationDTO>> GetAllVaccinationsAsync()
        {
            IEnumerable<Vaccination> vaccinations = await _unitOfWork.Vaccinations.GetAllAsync();
            return _mapper.Map<IEnumerable<Vaccination>, IEnumerable<VaccinationDTO>>(vaccinations);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
