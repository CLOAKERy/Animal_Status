﻿using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class SleepAndRestViewModel
{
    public int SleepAndRestId { get; set; }

    public DateTime RestDate { get; set; }

    public string Description { get; set; } = null!;

    public int PetId { get; set; }

    public virtual PetDTO Pet { get; set; } = null!;
}
