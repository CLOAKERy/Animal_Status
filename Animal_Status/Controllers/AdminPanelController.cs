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

        public AdminPanelController(IUserService userService, IMapper mapper, IAnimalTypeService animalTypeService)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.animalTypeService = animalTypeService;
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
    }
}
