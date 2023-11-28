using Animal_Status;
using AnimalRepair.BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace BLL.Services
{
    public class PetVaccinationService : IPetVaccinationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PetVaccinationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddPetVaccination(PetVaccinationDTO petVaccinationDto)
        {
            

            var petVaccination = _mapper.Map<PetVaccinationDTO, PetVaccination>(petVaccinationDto);
            await _unitOfWork.PetVaccination.CreateAsync(petVaccination);
            _unitOfWork.Save();
        }

        public async Task UpdatePetVaccination(PetVaccinationDTO petVaccinationDto)
        {
            PetVaccination updatedPetVaccination = _mapper.Map<PetVaccinationDTO, PetVaccination>(petVaccinationDto);
            await _unitOfWork.PetVaccination.UpdateAsync(updatedPetVaccination);
            _unitOfWork.Save();
        }

        public async Task RemovePetVaccination(int petVaccinationId)
        {
            PetVaccination petVaccination = await _unitOfWork.PetVaccination.GetAsync(petVaccinationId);
            if (petVaccination == null)
                throw new ValidationException("Вакцина не найдена", "");

            await _unitOfWork.PetVaccination.DeleteAsync(petVaccinationId);
            _unitOfWork.Save();
        }

        public async Task<PetVaccinationDTO> GetPetVaccinationById(int petVaccinationId)
        {
            PetVaccination petVaccination = await _unitOfWork.PetVaccination.GetAsync(petVaccinationId);
            if (petVaccination == null)
                throw new ValidationException("Вакцина не найдена", "");

            PetVaccinationDTO petVaccinationDto = _mapper.Map<PetVaccination, PetVaccinationDTO>(petVaccination);
            return petVaccinationDto;
        }

        public async Task<IEnumerable<PetVaccinationDTO>> GetAllPetVaccinationsAsync()
        {
            IEnumerable<PetVaccination> petVaccinations = await _unitOfWork.PetVaccination.GetAllAsync();
            return _mapper.Map<IEnumerable<PetVaccination>, IEnumerable<PetVaccinationDTO>>(petVaccinations);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
