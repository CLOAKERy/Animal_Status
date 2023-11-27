using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBehaviorService : IDisposable
    {
        Task AddBehavior(BehaviorDTO behaviorDto);
        Task UpdateBehavior(BehaviorDTO behaviorDto);
        Task RemoveBehavior(int behaviorId);
        Task<BehaviorDTO> GetBehaviorById(int behaviorId);
        Task<IEnumerable<BehaviorDTO>> GetAllBehaviorsAsync();
    }

}
