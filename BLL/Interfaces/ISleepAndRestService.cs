using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ISleepAndRestService : IDisposable
    {
        Task AddSleepAndRest(SleepAndRestDTO sleepAndRestDto);
        Task UpdateSleepAndRest(SleepAndRestDTO sleepAndRestDto);
        Task RemoveSleepAndRest(int sleepAndRestId);
        Task<SleepAndRestDTO> GetSleepAndRestById(int sleepAndRestId);
        Task<IEnumerable<SleepAndRestDTO>> GetAllSleepAndRestsAsync();
    }

}
