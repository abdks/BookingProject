using Microsoft.AspNetCore.Mvc;

namespace BookingProject.Controllers
{
    public class UIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
