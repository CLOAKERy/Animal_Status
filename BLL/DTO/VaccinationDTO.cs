using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class VaccinationDTO
{
    public int VaccinationId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime VaccinationDate { get; set; }

    public virtual ICollection<PetVaccination> PetVaccinations { get; set; } = new List<PetVaccination>();
}
