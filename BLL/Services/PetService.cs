using Animal_Status;
using AnimalRepair.BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PetService : IPetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddPet(PetDTO petDto)
        {
            if (string.IsNullOrEmpty(petDto.Name))
                throw new ValidationException("Имя питомца не может быть пустым", "");

            var pet = _mapper.Map<PetDTO, Pet>(petDto);
            await _unitOfWork.Pets.CreateAsync(pet);
            _unitOfWork.Save();
        }

        public async Task UpdatePet(PetDTO petDto)
        {
            Pet updatedPet = _mapper.Map<PetDTO, Pet>(petDto);
            await _unitOfWork.Pets.UpdateAsync(updatedPet);
            _unitOfWork.Save();
        }

        public async Task RemovePet(int petId)
        {
            Pet pet = await _unitOfWork.Pets.GetAsync(petId);
            if (pet == null)
                throw new ValidationException("Питомец не найден", "");

            await _unitOfWork.Pets.DeleteAsync(petId);
            _unitOfWork.Save();
        }

        public async Task<PetDTO> GetPetById(int petId)
        {
            Pet pet = await _unitOfWork.Pets.GetAsync(petId);
            if (pet == null)
                throw new ValidationException("Питомец не найден", "");

            PetDTO petDto = _mapper.Map<Pet, PetDTO>(pet);
            return petDto;
        }

        public async Task<IEnumerable<PetDTO>> GetAllPetsAsync()
        {
            IEnumerable<Pet> pets = await _unitOfWork.Pets.GetAllAsync();
            return _mapper.Map<IEnumerable<Pet>, IEnumerable<PetDTO>>(pets);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
