using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class PetVaccination
{
    public int PetVaccinationId { get; set; }

    public int PetId { get; set; }

    public int VaccinationId { get; set; }

    public virtual Pet Pet { get; set; } = null!;

    public virtual Vaccination Vaccination { get; set; } = null!;
}
