using Animal_Status;
using AnimalRepair.BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SleepAndRestService : ISleepAndRestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SleepAndRestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddSleepAndRest(SleepAndRestDTO sleepAndRestDto)
        {
            if (string.IsNullOrEmpty(sleepAndRestDto.Description))
                throw new ValidationException("Описание сна и отдыха не может быть пустым", "");

            var sleepAndRest = _mapper.Map<SleepAndRestDTO, SleepAndRest>(sleepAndRestDto);
            await _unitOfWork.SleepAndRests.CreateAsync(sleepAndRest);
            _unitOfWork.Save();
        }

        public async Task UpdateSleepAndRest(SleepAndRestDTO sleepAndRestDto)
        {
            SleepAndRest updatedSleepAndRest = _mapper.Map<SleepAndRestDTO, SleepAndRest>(sleepAndRestDto);
            await _unitOfWork.SleepAndRests.UpdateAsync(updatedSleepAndRest);
            _unitOfWork.Save();
        }

        public async Task RemoveSleepAndRest(int sleepAndRestId)
        {
            SleepAndRest sleepAndRest = await _unitOfWork.SleepAndRests.GetAsync(sleepAndRestId);
            if (sleepAndRest == null)
                throw new ValidationException("Описание сна и отдыха не найдено", "");

            await _unitOfWork.SleepAndRests.DeleteAsync(sleepAndRestId);
            _unitOfWork.Save();
        }

        public async Task<SleepAndRestDTO> GetSleepAndRestById(int sleepAndRestId)
        {
            SleepAndRest sleepAndRest = await _unitOfWork.SleepAndRests.GetAsync(sleepAndRestId);
            if (sleepAndRest == null)
                throw new ValidationException("Описание сна и отдыха не найдено", "");

            SleepAndRestDTO sleepAndRestDto = _mapper.Map<SleepAndRest, SleepAndRestDTO>(sleepAndRest);
            return sleepAndRestDto;
        }

        public async Task<IEnumerable<SleepAndRestDTO>> GetAllSleepAndRestsAsync()
        {
            IEnumerable<SleepAndRest> sleepAndRests = await _unitOfWork.SleepAndRests.GetAllAsync();
            return _mapper.Map<IEnumerable<SleepAndRest>, IEnumerable<SleepAndRestDTO>>(sleepAndRests);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
