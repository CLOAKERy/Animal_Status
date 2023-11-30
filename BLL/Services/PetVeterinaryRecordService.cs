using Animal_Status;
using AnimalRepair.BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PetVeterinaryRecordService : IPetVeterinaryRecordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PetVeterinaryRecordService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddPetVeterinaryRecord(PetVeterinaryRecordDTO petVeterinaryRecordDto)
        {


            var petVeterinaryRecord = _mapper.Map<PetVeterinaryRecordDTO, PetVeterinaryRecord>(petVeterinaryRecordDto);
            await _unitOfWork.PetVeterinaryRecords.CreateAsync(petVeterinaryRecord);
            _unitOfWork.Save();
        }

        public async Task UpdatePetVeterinaryRecord(PetVeterinaryRecordDTO petVeterinaryRecordDto)
        {
            PetVeterinaryRecord updatedPetVeterinaryRecord = _mapper.Map<PetVeterinaryRecordDTO, PetVeterinaryRecord>(petVeterinaryRecordDto);
            await _unitOfWork.PetVeterinaryRecords.UpdateAsync(updatedPetVeterinaryRecord);
            _unitOfWork.Save();
        }

        public async Task RemovePetVeterinaryRecord(int petVeterinaryRecordId)
        {
            PetVeterinaryRecord petVeterinaryRecord = await _unitOfWork.PetVeterinaryRecords.GetAsync(petVeterinaryRecordId);
            if (petVeterinaryRecord == null)
                throw new ValidationException("Запись ветеринара не найдена", "");

            await _unitOfWork.PetVeterinaryRecords.DeleteAsync(petVeterinaryRecordId);
            _unitOfWork.Save();
        }

        public async Task<PetVeterinaryRecordDTO> GetPetVeterinaryRecordById(int petVeterinaryRecordId)
        {
            PetVeterinaryRecord petVeterinaryRecord = await _unitOfWork.PetVeterinaryRecords.GetAsync(petVeterinaryRecordId);
            if (petVeterinaryRecord == null)
                throw new ValidationException("Запись ветеринара не найдена", "");

            PetVeterinaryRecordDTO petVeterinaryRecordDto = _mapper.Map<PetVeterinaryRecord, PetVeterinaryRecordDTO>(petVeterinaryRecord);
            return petVeterinaryRecordDto;
        }

        public async Task<IEnumerable<PetVeterinaryRecordDTO>> GetAllPetVeterinaryRecordsAsync()
        {
            IEnumerable<PetVeterinaryRecord> petVeterinaryRecords = await _unitOfWork.PetVeterinaryRecords.GetAllAsync();
            return _mapper.Map<IEnumerable<PetVeterinaryRecord>, IEnumerable<PetVeterinaryRecordDTO>>(petVeterinaryRecords);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
