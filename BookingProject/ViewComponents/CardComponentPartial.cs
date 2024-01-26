using Microsoft.AspNetCore.Mvc;

namespace BookingProject.ViewComponents
{
    public class CardComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
