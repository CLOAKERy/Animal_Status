using Animal_Status;
using AnimalRepair.BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExerciseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddExercise(ExerciseDTO exerciseDto)
        {
            if (string.IsNullOrEmpty(exerciseDto.Description))
                throw new ValidationException("Описание упражнения не может быть пустым", "");

            var exercise = _mapper.Map<ExerciseDTO, Exercise>(exerciseDto);
            await _unitOfWork.Exercises.CreateAsync(exercise);
            _unitOfWork.Save();
        }

        public async Task UpdateExercise(ExerciseDTO exerciseDto)
        {
            Exercise updatedExercise = _mapper.Map<ExerciseDTO, Exercise>(exerciseDto);
            await _unitOfWork.Exercises.UpdateAsync(updatedExercise);
            _unitOfWork.Save();
        }

        public async Task RemoveExercise(int exerciseId)
        {
            Exercise exercise = await _unitOfWork.Exercises.GetAsync(exerciseId);
            if (exercise == null)
                throw new ValidationException("Упражнение не найдено", "");

            await _unitOfWork.Exercises.DeleteAsync(exerciseId);
            _unitOfWork.Save();
        }

        public async Task<ExerciseDTO> GetExerciseById(int exerciseId)
        {
            Exercise exercise = await _unitOfWork.Exercises.GetAsync(exerciseId);
            if (exercise == null)
                throw new ValidationException("Упражнение не найдено", "");

            ExerciseDTO exerciseDto = _mapper.Map<Exercise, ExerciseDTO>(exercise);
            return exerciseDto;
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllExercisesAsync()
        {
            IEnumerable<Exercise> exercises = await _unitOfWork.Exercises.GetAllAsync();
            return _mapper.Map<IEnumerable<Exercise>, IEnumerable<ExerciseDTO>>(exercises);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
