using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class PetVeterinaryRecord
{
    public int PetVeterinaryRecordId { get; set; }

    public int PetId { get; set; }

    public int RecordId { get; set; }

    public virtual Pet Pet { get; set; } = null!;

    public virtual VeterinaryRecord Record { get; set; } = null!;
}
