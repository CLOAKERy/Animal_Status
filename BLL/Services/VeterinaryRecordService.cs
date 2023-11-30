using Animal_Status;
using AnimalRepair.BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class VeterinaryRecordService : IVeterinaryRecordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VeterinaryRecordService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddVeterinaryRecord(VeterinaryRecordDTO veterinaryRecordDto)
        {
            if (string.IsNullOrEmpty(veterinaryRecordDto.Description))
                throw new ValidationException("Описание ветеринарной записи не может быть пустым", "");

            var veterinaryRecord = _mapper.Map<VeterinaryRecordDTO, VeterinaryRecord>(veterinaryRecordDto);
            await _unitOfWork.VeterinaryRecord.CreateAsync(veterinaryRecord);
            _unitOfWork.Save();
        }

        public async Task UpdateVeterinaryRecord(VeterinaryRecordDTO veterinaryRecordDto)
        {
            VeterinaryRecord updatedVeterinaryRecord = _mapper.Map<VeterinaryRecordDTO, VeterinaryRecord>(veterinaryRecordDto);
            await _unitOfWork.VeterinaryRecord.UpdateAsync(updatedVeterinaryRecord);
            _unitOfWork.Save();
        }

        public async Task RemoveVeterinaryRecord(int veterinaryRecordId)
        {
            VeterinaryRecord veterinaryRecord = await _unitOfWork.VeterinaryRecord.GetAsync(veterinaryRecordId);
            if (veterinaryRecord == null)
                throw new ValidationException("Ветеринарная запись не найдена", "");

            await _unitOfWork.VeterinaryRecord.DeleteAsync(veterinaryRecordId);
            _unitOfWork.Save();
        }

        public async Task<VeterinaryRecordDTO> GetVeterinaryRecordById(int veterinaryRecordId)
        {
            VeterinaryRecord veterinaryRecord = await _unitOfWork.VeterinaryRecord.GetAsync(veterinaryRecordId);
            if (veterinaryRecord == null)
                throw new ValidationException("Ветеринарная запись не найдена", "");

            VeterinaryRecordDTO veterinaryRecordDto = _mapper.Map<VeterinaryRecord, VeterinaryRecordDTO>(veterinaryRecord);
            return veterinaryRecordDto;
        }

        public async Task<IEnumerable<VeterinaryRecordDTO>> GetAllVeterinaryRecordsAsync()
        {
            IEnumerable<VeterinaryRecord> veterinaryRecords = await _unitOfWork.VeterinaryRecord.GetAllAsync();
            return _mapper.Map<IEnumerable<VeterinaryRecord>, IEnumerable<VeterinaryRecordDTO>>(veterinaryRecords);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
