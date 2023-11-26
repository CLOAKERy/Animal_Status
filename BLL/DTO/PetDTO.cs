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

    public virtual ICollection<BehaviorDTO> Behaviors { get; set; } = new List<BehaviorDTO>();

    public virtual ICollection<DietDTO> Diets { get; set; } = new List<DietDTO>();

    public virtual ICollection<ExerciseDTO> Exercises { get; set; } = new List<ExerciseDTO>();

    public virtual ICollection<NoteDTO> Notes { get; set; } = new List<NoteDTO>();

    public virtual User Owner { get; set; } = null!;

    public virtual ICollection<PetVaccination> PetVaccinations { get; set; } = new List<PetVaccination>();

    public virtual ICollection<PetVeterinaryRecord> PetVeterinaryRecords { get; set; } = new List<PetVeterinaryRecord>();

    public virtual ICollection<SleepAndRest> SleepAndRests { get; set; } = new List<SleepAndRest>();

    public virtual ICollection<StressLevelDTO> StressLevels { get; set; } = new List<StressLevelDTO>();

    public virtual AnimalTypeDTO? Type { get; set; }

    public virtual ICollection<VeterinaryRecord> VeterinaryRecords { get; set; } = new List<VeterinaryRecord>();

    public virtual ICollection<WeightAndHeightDTO> WeightAndHeights { get; set; } = new List<WeightAndHeightDTO>();
}
