using BLL.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BLL.Services;

namespace Animal_Status.Controllers
{
    public class CabinetController : Controller
    {
        private readonly IMapper mapper;

        IPetService petService;

        public CabinetController(IPetService petService, IMapper mapper)
        {
            this.mapper = mapper;
            this.petService = petService;
        }
        public async Task<ActionResult> Pets()
        {
            IEnumerable<PetDTO> petsDtos = await petService.GetAllPetsWithTypesAsync();
            PetIndexViewModel model = new();
            model.petViewModel = mapper.Map<IEnumerable<PetDTO>, IEnumerable<PetViewModel>>(petsDtos);
            return View("Pets", model);
        }
    }
}
