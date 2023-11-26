using Animal_Status;
using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class PetDTO
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

    public virtual UserDTO Owner { get; set; } = null!;

    public virtual ICollection<PetVaccinationDTO> PetVaccinations { get; set; } = new List<PetVaccinationDTO>();

    public virtual ICollection<PetVeterinaryRecordDTO> PetVeterinaryRecords { get; set; } = new List<PetVeterinaryRecordDTO>();

    public virtual ICollection<SleepAndRestDTO> SleepAndRests { get; set; } = new List<SleepAndRestDTO>();

    public virtual ICollection<StressLevelDTO> StressLevels { get; set; } = new List<StressLevelDTO>();

    public virtual AnimalTypeDTO? Type { get; set; }

    public virtual ICollection<VeterinaryRecordDTO> VeterinaryRecords { get; set; } = new List<VeterinaryRecordDTO>();

    public virtual ICollection<WeightAndHeightDTO> WeightAndHeights { get; set; } = new List<WeightAndHeightDTO>();
}
