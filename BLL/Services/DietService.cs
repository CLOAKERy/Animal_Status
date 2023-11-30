using Animal_Status;
using AnimalRepair.BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DietService : IDietService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DietService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddDiet(DietDTO dietDto)
        {
            if (string.IsNullOrEmpty(dietDto.Description))
                throw new ValidationException("Описание диеты не может быть пустым", "");

            var diet = _mapper.Map<DietDTO, Diet>(dietDto);
            await _unitOfWork.Diets.CreateAsync(diet);
            _unitOfWork.Save();
        }

        public async Task UpdateDiet(DietDTO dietDto)
        {
            Diet updatedDiet = _mapper.Map<DietDTO, Diet>(dietDto);
            await _unitOfWork.Diets.UpdateAsync(updatedDiet);
            _unitOfWork.Save();
        }

        public async Task RemoveDiet(int dietId)
        {
            Diet diet = await _unitOfWork.Diets.GetAsync(dietId);
            if (diet == null)
                throw new ValidationException("Диета не найдена", "");

            await _unitOfWork.Diets.DeleteAsync(dietId);
            _unitOfWork.Save();
        }

        public async Task<DietDTO> GetDietById(int dietId)
        {
            Diet diet = await _unitOfWork.Diets.GetAsync(dietId);
            if (diet == null)
                throw new ValidationException("Диета не найдена", "");

            DietDTO dietDto = _mapper.Map<Diet, DietDTO>(diet);
            return dietDto;
        }

        public async Task<IEnumerable<DietDTO>> GetAllDietsAsync()
        {
            IEnumerable<Diet> diets = await _unitOfWork.Diets.GetAllAsync();
            return _mapper.Map<IEnumerable<Diet>, IEnumerable<DietDTO>>(diets);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
