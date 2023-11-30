using Animal_Status;
using AnimalRepair.BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StressLevelService : IStressLevelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StressLevelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddStressLevel(StressLevelDTO stressLevelDto)
        {
            if (string.IsNullOrEmpty(stressLevelDto.Description))
                throw new ValidationException("Описание уровня стресса не может быть пустым", "");

            var stressLevel = _mapper.Map<StressLevelDTO, StressLevel>(stressLevelDto);
            await _unitOfWork.StressLevel.CreateAsync(stressLevel);
            _unitOfWork.Save();
        }

        public async Task UpdateStressLevel(StressLevelDTO stressLevelDto)
        {
            StressLevel updatedStressLevel = _mapper.Map<StressLevelDTO, StressLevel>(stressLevelDto);
            await _unitOfWork.StressLevel.UpdateAsync(updatedStressLevel);
            _unitOfWork.Save();
        }

        public async Task RemoveStressLevel(int stressLevelId)
        {
            StressLevel stressLevel = await _unitOfWork.StressLevel.GetAsync(stressLevelId);
            if (stressLevel == null)
                throw new ValidationException("Уровень стресса не найден", "");

            await _unitOfWork.StressLevel.DeleteAsync(stressLevelId);
            _unitOfWork.Save();
        }

        public async Task<StressLevelDTO> GetStressLevelById(int stressLevelId)
        {
            StressLevel stressLevel = await _unitOfWork.StressLevel.GetAsync(stressLevelId);
            if (stressLevel == null)
                throw new ValidationException("Уровень стресса не найден", "");

            StressLevelDTO stressLevelDto = _mapper.Map<StressLevel, StressLevelDTO>(stressLevel);
            return stressLevelDto;
        }

        public async Task<IEnumerable<StressLevelDTO>> GetAllStressLevelsAsync()
        {
            IEnumerable<StressLevel> stressLevels = await _unitOfWork.StressLevel.GetAllAsync();
            return _mapper.Map<IEnumerable<StressLevel>, IEnumerable<StressLevelDTO>>(stressLevels);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
