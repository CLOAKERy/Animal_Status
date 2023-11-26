using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private AnimalServiceContext db;
        private AnimalTypeRepository animalTypeRepository;
        private BehaviorRepository behaviorRepository;
        private DietRepository dietRepository;
        private ExerciseRepository exerciseRepository;
        private NoteRepository noteRepository;
        private PetRepository petRepository;
        private PetVaccinationRepository petVaccinationRepository;
        private PetVeterinaryRecordRepository petVeterinaryRecordRepository;
        private RoleRepository roleRepository;
        private SleepAndRestRepository sleepAndRestRepository;
        private StressLevelRepository stressLevelRepository;
        private UserRepository userRepository;
        private VaccinationRepository vaccinationRepository;
        private VeterinaryRecordRepository veterinaryRecordRepository;
        private WeightAndHeightRepository weightAndHeightRepository;

    }
}
