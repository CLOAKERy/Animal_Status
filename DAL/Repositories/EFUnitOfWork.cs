using DAL.Interfaces;
using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

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

        public EFUnitOfWork(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            db = new AnimalServiceContext(connectionString);
        }

        public IRepository<AnimalType> AnimalTypes
        {
            get
            {
                if (animalTypeRepository == null)
                    animalTypeRepository = new AnimalTypeRepository(db);
                return animalTypeRepository;
            }
        }

        public IRepository<Behavior> Behaviors
        {
            get
            {
                if (behaviorRepository == null)
                    behaviorRepository = new BehaviorRepository(db);
                return behaviorRepository;
            }
        }

        public IRepository<Diet> Diets
        {
            get
            {
                if (dietRepository == null)
                    dietRepository = new DietRepository(db);
                return dietRepository;
            }
        }

        public IRepository<Exercise> Exercises
        {
            get
            {
                if (exerciseRepository == null)
                    exerciseRepository = new ExerciseRepository(db);
                return exerciseRepository;
            }
        }

        public IRepository<Note> Notes
        {
            get
            {
                if (noteRepository == null)
                    noteRepository = new NoteRepository(db);
                return noteRepository;
            }
        }

        public IPetRepository Pets
        {
            get
            {
                if (petRepository == null)
                    petRepository = new PetRepository(db);
                return petRepository;
            }
        }

        public IRepository<PetVaccination> PetVaccination
        {
            get
            {
                if (petVaccinationRepository == null)
                    petVaccinationRepository = new PetVaccinationRepository(db);
                return petVaccinationRepository;
            }
        }

        public IRepository<PetVeterinaryRecord> PetVeterinaryRecords
        {
            get
            {
                if (petVeterinaryRecordRepository == null)
                    petVeterinaryRecordRepository = new PetVeterinaryRecordRepository(db);
                return petVeterinaryRecordRepository;
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;
            }
        }

        public IRepository<SleepAndRest> SleepAndRests
        {
            get
            {
                if (sleepAndRestRepository == null)
                    sleepAndRestRepository = new SleepAndRestRepository(db);
                return sleepAndRestRepository;
            }
        }

        public IRepository<StressLevel> StressLevel
        {
            get
            {
                if (stressLevelRepository == null)
                    stressLevelRepository = new StressLevelRepository(db);
                return stressLevelRepository;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Vaccination> Vaccinations
        {
            get
            {
                if (vaccinationRepository == null)
                    vaccinationRepository = new VaccinationRepository(db);
                return vaccinationRepository;
            }
        }

        public IRepository<VeterinaryRecord> VeterinaryRecord
        {
            get
            {
                if (veterinaryRecordRepository == null)
                    veterinaryRecordRepository = new VeterinaryRecordRepository(db);
                return veterinaryRecordRepository;
            }
        }

        public IWeightAndHeightRepository WeightAndHeights
        {
            get
            {
                if (weightAndHeightRepository == null)
                    weightAndHeightRepository = new WeightAndHeightRepository(db);
                return weightAndHeightRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}



