using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;

namespace Animal_Status
{



    public partial class VaccinationViewModel
    {
        public int VaccinationId { get; set; }

        public string Name { get; set; } = null!;

        public DateTime VaccinationDate { get; set; }

        public virtual ICollection<PetVaccinationDTO> PetVaccinations { get; set; } = new List<PetVaccinationDTO>();


    }
    public class VaccinationViewModelIndex
    {
        public IEnumerable<VaccinationViewModel> vaccinationViewModels { get; set; }
        public int animalId { get; set; }
        public int vaccineId { get; set; }
    }
}