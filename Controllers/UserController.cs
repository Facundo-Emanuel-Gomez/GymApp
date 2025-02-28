using Microsoft.AspNetCore.Mvc;

namespace Gym_Proyect.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
