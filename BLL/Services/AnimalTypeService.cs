using Animal_Status;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalRepair.BLL.Infrastructure;  

namespace BLL.Services
{
    public class AnimalTypeService : IAnimalTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnimalTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAnimalType(AnimalTypeDTO animalTypeDto)
        {
            if (string.IsNullOrEmpty(animalTypeDto.TypeName))
                throw new ValidationException("Название типа животного не может быть пустым", "");

            var animalType = _mapper.Map<AnimalTypeDTO, AnimalType>(animalTypeDto);
            await _unitOfWork.AnimalTypes.CreateAsync(animalType);
            _unitOfWork.Save();
        }

        public async Task UpdateAnimalType(AnimalTypeDTO animalTypeDto)
        {
            AnimalType updatedAnimalType = _mapper.Map<AnimalTypeDTO, AnimalType>(animalTypeDto);
            await _unitOfWork.AnimalTypes.UpdateAsync(updatedAnimalType);
            _unitOfWork.Save();
        }

        public async Task RemoveAnimalType(int animalTypeId)
        {
            AnimalType animalType = await _unitOfWork.AnimalTypes.GetAsync(animalTypeId);
            if (animalType == null)
                throw new ValidationException("Тип животного не найден", "");

            await _unitOfWork.AnimalTypes.DeleteAsync(animalTypeId);
            _unitOfWork.Save();
        }

        public async Task<AnimalTypeDTO> GetAnimalTypeById(int animalTypeId)
        {
            AnimalType animalType = await _unitOfWork.AnimalTypes.GetAsync(animalTypeId);
            if (animalType == null)
                throw new ValidationException("Тип животного не найден", "");

            AnimalTypeDTO animalTypeDto = _mapper.Map<AnimalType, AnimalTypeDTO>(animalType);
            return animalTypeDto;
        }

        public async Task<IEnumerable<AnimalTypeDTO>> GetAllAnimalTypesAsync()
        {
            IEnumerable<AnimalType> animalTypes = await _unitOfWork.AnimalTypes.GetAllAsync();
            return _mapper.Map<IEnumerable<AnimalType>, IEnumerable<AnimalTypeDTO>>(animalTypes);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
