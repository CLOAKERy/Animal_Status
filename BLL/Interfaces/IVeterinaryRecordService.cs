using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IVeterinaryRecordService : IDisposable
    {
        Task AddVeterinaryRecord(VeterinaryRecordDTO veterinaryRecordDto);
        Task UpdateVeterinaryRecord(VeterinaryRecordDTO veterinaryRecordDto);
        Task RemoveVeterinaryRecord(int veterinaryRecordId);
        Task<VeterinaryRecordDTO> GetVeterinaryRecordById(int veterinaryRecordId);
        Task<IEnumerable<VeterinaryRecordDTO>> GetAllVeterinaryRecordsAsync();
    }

}
