using Animal_Status;
using AnimalRepair.BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BehaviorService : IBehaviorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BehaviorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddBehavior(BehaviorDTO behaviorDto)
        {
            if (string.IsNullOrEmpty(behaviorDto.Description))
                throw new ValidationException("Описание поведения не может быть пустым", "");

            var behavior = _mapper.Map<BehaviorDTO, Behavior>(behaviorDto);
            await _unitOfWork.Behaviors.CreateAsync(behavior);
            _unitOfWork.Save();
        }

        public async Task UpdateBehavior(BehaviorDTO behaviorDto)
        {
            Behavior updatedBehavior = _mapper.Map<BehaviorDTO, Behavior>(behaviorDto);
            await _unitOfWork.Behaviors.UpdateAsync(updatedBehavior);
            _unitOfWork.Save();
        }

        public async Task RemoveBehavior(int behaviorId)
        {
            Behavior behavior = await _unitOfWork.Behaviors.GetAsync(behaviorId);
            if (behavior == null)
                throw new ValidationException("Поведение не найдено", "");

            await _unitOfWork.Behaviors.DeleteAsync(behaviorId);
            _unitOfWork.Save();
        }

        public async Task<BehaviorDTO> GetBehaviorById(int behaviorId)
        {
            Behavior behavior = await _unitOfWork.Behaviors.GetAsync(behaviorId);
            if (behavior == null)
                throw new ValidationException("Поведение не найдено", "");

            BehaviorDTO behaviorDto = _mapper.Map<Behavior, BehaviorDTO>(behavior);
            return behaviorDto;
        }

        public async Task<IEnumerable<BehaviorDTO>> GetAllBehaviorsAsync()
        {
            IEnumerable<Behavior> behaviors = await _unitOfWork.Behaviors.GetAllAsync();
            return _mapper.Map<IEnumerable<Behavior>, IEnumerable<BehaviorDTO>>(behaviors);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
