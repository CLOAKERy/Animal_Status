using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class VeterinaryRecordDTO
{
    public int RecordId { get; set; }

    public DateTime VisitDate { get; set; }

    public string Description { get; set; } = null!;

    public string Recommendations { get; set; } = null!;

    public string Veterinarian { get; set; } = null!;

    public int PetId { get; set; }

    public virtual PetDTO Pet { get; set; } = null!;

    public virtual ICollection<PetVeterinaryRecord> PetVeterinaryRecords { get; set; } = new List<PetVeterinaryRecord>();
}
