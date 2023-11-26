using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class BehaviorDTO
{
    public int BehaviorId { get; set; }

    public DateTime BehaviorDate { get; set; }

    public string Description { get; set; } = null!;

    public int PetId { get; set; }

    public virtual PetDTO Pet { get; set; } = null!;
}
