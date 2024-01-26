using Microsoft.AspNetCore.Mvc;

namespace BookingProject.ViewComponents
{
    public class HotelFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
