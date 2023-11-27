using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IExerciseService : IDisposable
    {
        Task AddExercise(ExerciseDTO exerciseDto);
        Task UpdateExercise(ExerciseDTO exerciseDto);
        Task RemoveExercise(int exerciseId);
        Task<ExerciseDTO> GetExerciseById(int exerciseId);
        Task<IEnumerable<ExerciseDTO>> GetAllExercisesAsync();
    }

}
