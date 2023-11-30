using BLL.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BLL.Services;

namespace Animal_Status.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IMapper mapper;

        IUserService userService;

        public AdminPanelController(IUserService userService, IMapper mapper)
        {
            this.mapper = mapper;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Users()
        {
            IEnumerable<UserDTO> adoptionStatusDtos = await userService.GetAllUsersAsync();

            UserIndexViewModel model = new();
            model.userViewModel = mapper.Map<IEnumerable<UserDTO>, IEnumerable<UserViewModel>>(adoptionStatusDtos);
            return View(model);
        }
    }
}
