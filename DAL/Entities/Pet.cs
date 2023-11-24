using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class Pet
{
    public int PetId { get; set; }

    public string Name { get; set; } = null!;

    public string Species { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; } = null!;

    public int OwnerId { get; set; }

    public int? TypeId { get; set; }

    public string? Picture { get; set; }

    public virtual ICollection<Behavior> Behaviors { get; set; } = new List<Behavior>();

    public virtual ICollection<Diet> Diets { get; set; } = new List<Diet>();

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual User Owner { get; set; } = null!;

    public virtual ICollection<PetVaccination> PetVaccinations { get; set; } = new List<PetVaccination>();

    public virtual ICollection<PetVeterinaryRecord> PetVeterinaryRecords { get; set; } = new List<PetVeterinaryRecord>();

    public virtual ICollection<SleepAndRest> SleepAndRests { get; set; } = new List<SleepAndRest>();

    public virtual ICollection<StressLevel> StressLevels { get; set; } = new List<StressLevel>();

    public virtual AnimalType? Type { get; set; }

    public virtual ICollection<VeterinaryRecord> VeterinaryRecords { get; set; } = new List<VeterinaryRecord>();

    public virtual ICollection<WeightAndHeight> WeightAndHeights { get; set; } = new List<WeightAndHeight>();
}
