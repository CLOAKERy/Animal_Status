using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class StressLevelDTO
{
    public int StressLevelId { get; set; }

    public DateTime StressDate { get; set; }

    public string Description { get; set; } = null!;

    public int PetId { get; set; }

    public virtual PetDTO Pet { get; set; } = null!;
}
