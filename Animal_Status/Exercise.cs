using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class Exercise
{
    public int ExerciseId { get; set; }

    public DateTime ActivityDate { get; set; }

    public string Description { get; set; } = null!;

    public int PetId { get; set; }

    public virtual Pet Pet { get; set; } = null!;
}
