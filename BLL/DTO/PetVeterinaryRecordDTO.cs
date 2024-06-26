﻿using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class PetVeterinaryRecordDTO
{
    public int PetVeterinaryRecordId { get; set; }

    public int PetId { get; set; }

    public int RecordId { get; set; }

    public virtual PetDTO Pet { get; set; } = null!;

    public virtual VeterinaryRecordDTO Record { get; set; } = null!;
}
