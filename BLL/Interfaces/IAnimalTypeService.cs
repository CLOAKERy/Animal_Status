using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAnimalTypeService : IDisposable
    {
        Task AddAnimalType(AnimalTypeDTO animalTypeDto);
        Task UpdateAnimalType(AnimalTypeDTO animalTypeDto);
        Task RemoveAnimalType(int animalTypeId);
        Task<AnimalTypeDTO> GetAnimalTypeById(int animalTypeId);
        Task<IEnumerable<AnimalTypeDTO>> GetAllAnimalTypesAsync();
    }

}
