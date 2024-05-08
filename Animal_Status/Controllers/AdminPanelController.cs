using BLL.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using Animal_Status.Models;

namespace Animal_Status.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IMapper mapper;

        IUserService userService;
        IAnimalTypeService animalTypeService;
        IVaccinationService vaccinationService;

        public AdminPanelController(IUserService userService, IMapper mapper, IAnimalTypeService animalTypeService, IVaccinationService vaccinationService)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.animalTypeService = animalTypeService;
            this.vaccinationService = vaccinationService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Users()
        {
            IEnumerable<UserDTO> usersDtos = await userService.GetAllUsersAsync();

            UserIndexViewModel model = new();
            model.userViewModel = mapper.Map<IEnumerable<UserDTO>, IEnumerable<UserViewModel>>(usersDtos);
            return View(model);
        }

        public async Task<ActionResult> Types()
        {
            IEnumerable<AnimalTypeDTO> typesDtos = await animalTypeService.GetAllAnimalTypesAsync();

            IEnumerable<AnimalTypeViewModel> model = mapper.Map<IEnumerable<AnimalTypeDTO>, IEnumerable<AnimalTypeViewModel>>(typesDtos);

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> CreateType()
        {
           
 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateType(AnimalTypeViewModel model)
        {    
            AnimalTypeDTO typeCreate = mapper.Map<AnimalTypeViewModel, AnimalTypeDTO>(model);

            await animalTypeService.AddAnimalType(typeCreate);
            return RedirectToAction("Types", "AdminPanel");
        }

        [HttpGet]
        public async Task<ActionResult> RedactTypeView(int id)
        {
            AnimalTypeDTO typeDto = await animalTypeService.GetAnimalTypeById(id);

            AnimalTypeViewModel model = mapper.Map<AnimalTypeDTO,AnimalTypeViewModel>(typeDto);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RedactType(AnimalTypeViewModel model, int id)
        {
            AnimalTypeDTO typeRedact = mapper.Map<AnimalTypeViewModel, AnimalTypeDTO>(model);
            typeRedact.TypeId = id;

            await animalTypeService.UpdateAnimalType(typeRedact);
            return RedirectToAction("Types", "AdminPanel");
        }

        public async Task<IActionResult> DeleteType(int id)
        {
            await animalTypeService.RemoveAnimalType(id);
            return RedirectToAction("Types", "AdminPanel");
        }

        public async Task<ActionResult> Vaccines()
        {
            IEnumerable<VaccinationDTO> vaccinesDtos = await vaccinationService.GetAllVaccinationsAsync();

            IEnumerable<VaccinationViewModel> model = mapper.Map<IEnumerable<VaccinationDTO>, IEnumerable<VaccinationViewModel>>(vaccinesDtos);

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> CreateVaccine()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVaccine(VaccinationViewModel model)
        {
            VaccinationDTO vaccineCreate = mapper.Map<VaccinationViewModel, VaccinationDTO>(model);

            await vaccinationService.AddVaccination(vaccineCreate);
            return RedirectToAction("Vaccines", "AdminPanel");
        }

        [HttpGet]
        public async Task<ActionResult> RedactVaccineView(int id)
        {
            VaccinationDTO vaccineDto = await vaccinationService.GetVaccinationById(id);

            VaccinationViewModel model = mapper.Map<VaccinationDTO, VaccinationViewModel>(vaccineDto);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RedactVaccine(VaccinationViewModel model, int id)
        {
            VaccinationDTO vaccineRedact = mapper.Map<VaccinationViewModel, VaccinationDTO>(model);
            vaccineRedact.VaccinationId = id;

            await vaccinationService.UpdateVaccination(vaccineRedact);
            return RedirectToAction("Vaccines", "AdminPanel");
        }

        public async Task<IActionResult> DeleteVaccine(int id)
        {
            await vaccinationService.RemoveVaccination(id);
            return RedirectToAction("Vaccines", "AdminPanel");
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            await userService.RemoveUser(id);
            return RedirectToAction("Users", "AdminPanel");
        }
    }
}
