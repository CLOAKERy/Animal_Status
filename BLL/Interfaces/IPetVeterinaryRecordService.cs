
using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPetVeterinaryRecordService : IDisposable
    {
        Task AddPetVeterinaryRecord(PetVeterinaryRecordDTO petVeterinaryRecordDto);
        Task UpdatePetVeterinaryRecord(PetVeterinaryRecordDTO petVeterinaryRecordDto);
        Task RemovePetVeterinaryRecord(int petVeterinaryRecordId);
        Task<PetVeterinaryRecordDTO> GetPetVeterinaryRecordById(int petVeterinaryRecordId);
        Task<IEnumerable<PetVeterinaryRecordDTO>> GetAllPetVeterinaryRecordsAsync();
    }

}
