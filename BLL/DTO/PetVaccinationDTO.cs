using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class PetVaccinationDTO
{
    public int PetVaccinationId { get; set; }

    public int PetId { get; set; }

    public int VaccinationId { get; set; }

    public virtual PetDTO Pet { get; set; } = null!;

    public virtual VaccinationDTO Vaccination { get; set; } = null!;
}
