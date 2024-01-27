using BookingProject.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingProject.ViewComponents
{
    public class HotelFilterComponentPartial : ViewComponent
    {
        private readonly IMongoCollection<Sliders> _sliderCollection;

        public HotelFilterComponentPartial(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _sliderCollection = database.GetCollection<Sliders>(databaseSettings.SliderCollectionName);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Sliders> sliderItems = await _sliderCollection.Find(_ => true).ToListAsync();
            return View(sliderItems);
        }
    }
}
