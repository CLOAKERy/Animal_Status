﻿using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class WeightAndHeight
{
    public int MeasurementId { get; set; }

    public DateTime MeasurementDate { get; set; }

    public decimal Weight { get; set; }

    public decimal Height { get; set; }

    public int PetId { get; set; }

    public virtual Pet Pet { get; set; } = null!;
}
