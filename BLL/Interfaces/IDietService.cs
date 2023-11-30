using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDietService : IDisposable
    {
        Task AddDiet(DietDTO dietDto);
        Task UpdateDiet(DietDTO dietDto);
        Task RemoveDiet(int dietId);
        Task<DietDTO> GetDietById(int dietId);
        Task<IEnumerable<DietDTO>> GetAllDietsAsync();
    }

}
