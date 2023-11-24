using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class AnimalType
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
