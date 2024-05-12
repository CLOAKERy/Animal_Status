using Animal_Status;
using AnimalRepair.BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class WeightAndHeightService : IWeightAndHeightService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WeightAndHeightService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddWeightAndHeight(WeightAndHeightDTO weightAndHeightDto)
        {
            if (weightAndHeightDto.Weight <= 0 || weightAndHeightDto.Height <= 0)
                throw new ValidationException("Вес и рост должны быть больше нуля", "");

            var weightAndHeight = _mapper.Map<WeightAndHeightDTO, WeightAndHeight>(weightAndHeightDto);
            await _unitOfWork.WeightAndHeights.CreateAsync(weightAndHeight);
            _unitOfWork.Save();
        }

        public async Task UpdateWeightAndHeight(WeightAndHeightDTO weightAndHeightDto)
        {
            WeightAndHeight updatedWeightAndHeight = _mapper.Map<WeightAndHeightDTO, WeightAndHeight>(weightAndHeightDto);
            await _unitOfWork.WeightAndHeights.UpdateAsync(updatedWeightAndHeight);
            _unitOfWork.Save();
        }

        public async Task RemoveWeightAndHeight(int weightAndHeightId)
        {
            WeightAndHeight weightAndHeight = await _unitOfWork.WeightAndHeights.GetAsync(weightAndHeightId);
            if (weightAndHeight == null)
                throw new ValidationException("Данные о весе и росте не найдены", "");

            await _unitOfWork.WeightAndHeights.DeleteAsync(weightAndHeightId);
            _unitOfWork.Save();
        }

        public async Task<WeightAndHeightDTO> GetWeightAndHeightById(int weightAndHeightId)
        {
            WeightAndHeight weightAndHeight = await _unitOfWork.WeightAndHeights.GetAsync(weightAndHeightId);
            if (weightAndHeight == null)
                throw new ValidationException("Данные о весе и росте не найдены", "");

            WeightAndHeightDTO weightAndHeightDto = _mapper.Map<WeightAndHeight, WeightAndHeightDTO>(weightAndHeight);
            return weightAndHeightDto;
        }

        public async Task<IEnumerable<WeightAndHeightDTO>> GetAllWeightAndHeightsAsync()
        {
            IEnumerable<WeightAndHeight> weightAndHeights = await _unitOfWork.WeightAndHeights.GetAllAsync();
            return _mapper.Map<IEnumerable<WeightAndHeight>, IEnumerable<WeightAndHeightDTO>>(weightAndHeights);
        }

        public async Task<IEnumerable<WeightAndHeightDTO>> GetAllSortedAsync(int petId)
        {
            IEnumerable<WeightAndHeight> weightAndHeights = await _unitOfWork.WeightAndHeights.GetAllSortedAsync(petId);
            return _mapper.Map<IEnumerable<WeightAndHeight>, IEnumerable<WeightAndHeightDTO>>(weightAndHeights);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
