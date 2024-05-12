using Animal_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<AnimalType> AnimalTypes { get; }
        IRepository<Behavior> Behaviors { get; }
        IRepository<Diet> Diets { get; }
        IRepository<Exercise> Exercises { get; }
        IRepository<Note> Notes { get; }
        IPetRepository Pets { get; }
        IRepository<PetVaccination> PetVaccination { get; }
        IRepository<PetVeterinaryRecord> PetVeterinaryRecords { get; }
        IRepository<Role> Roles { get; }
        IRepository<SleepAndRest> SleepAndRests { get; }
        IRepository<StressLevel> StressLevel { get; }
        IUserRepository Users { get; }
        IRepository<Vaccination> Vaccinations { get; }
        IRepository<VeterinaryRecord> VeterinaryRecord { get; }
        IWeightAndHeightRepository WeightAndHeights { get; }
        void Save();
    }
}
