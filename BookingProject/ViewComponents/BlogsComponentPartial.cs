using BookingProject.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Settings;

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
