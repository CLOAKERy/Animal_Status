using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class AnimalTypeDTO
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<PetDTO> Pets { get; set; } = new List<PetDTO>();
}
