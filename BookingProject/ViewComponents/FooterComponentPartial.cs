using Microsoft.AspNetCore.Mvc;

namespace BookingProject.ViewComponents
{
    public class FooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
