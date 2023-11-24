using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class Behavior
{
    public int BehaviorId { get; set; }

    public DateTime BehaviorDate { get; set; }

    public string Description { get; set; } = null!;

    public int PetId { get; set; }

    public virtual Pet Pet { get; set; } = null!;
}
