using Microsoft.AspNetCore.Mvc;

namespace BookingProject.ViewComponents
{
    public class HeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
