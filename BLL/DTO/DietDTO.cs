using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class DietDTO
{
    public int DietId { get; set; }

    public DateTime DietDate { get; set; }

    public string Description { get; set; } = null!;

    public int PetId { get; set; }

    public virtual Pet Pet { get; set; } = null!;
}
