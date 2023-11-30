using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStressLevelService : IDisposable
    {
        Task AddStressLevel(StressLevelDTO stressLevelDto);
        Task UpdateStressLevel(StressLevelDTO stressLevelDto);
        Task RemoveStressLevel(int stressLevelId);
        Task<StressLevelDTO> GetStressLevelById(int stressLevelId);
        Task<IEnumerable<StressLevelDTO>> GetAllStressLevelsAsync();
    }

}
