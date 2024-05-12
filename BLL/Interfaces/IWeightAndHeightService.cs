using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IWeightAndHeightService : IDisposable
    {
        Task AddWeightAndHeight(WeightAndHeightDTO weightAndHeightDto);
        Task UpdateWeightAndHeight(WeightAndHeightDTO weightAndHeightDto);
        Task RemoveWeightAndHeight(int weightAndHeightId);
        Task<WeightAndHeightDTO> GetWeightAndHeightById(int weightAndHeightId);
        Task<IEnumerable<WeightAndHeightDTO>> GetAllWeightAndHeightsAsync();
        Task<IEnumerable<WeightAndHeightDTO>> GetAllSortedAsync(int petId);
    }

}
