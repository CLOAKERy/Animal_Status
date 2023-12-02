using Microsoft.AspNetCore.Mvc;

namespace Animal_Status.Controllers
{
    public class CabinetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
