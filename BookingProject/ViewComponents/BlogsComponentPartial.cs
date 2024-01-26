using Microsoft.AspNetCore.Mvc;

namespace BookingProject.ViewComponents
{
    public class BlogsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
