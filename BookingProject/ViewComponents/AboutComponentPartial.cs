using Microsoft.AspNetCore.Mvc;

namespace BookingProject.ViewComponents
{
    public class AboutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
