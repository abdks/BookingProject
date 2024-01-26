using Microsoft.AspNetCore.Mvc;

namespace BookingProject.ViewComponents
{
    public class TestimonialComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
