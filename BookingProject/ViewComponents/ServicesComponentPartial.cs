using Microsoft.AspNetCore.Mvc;

namespace BookingProject.ViewComponents
{
    public class ServicesComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
