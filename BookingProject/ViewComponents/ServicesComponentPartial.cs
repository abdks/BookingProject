using BookingProject.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Settings;

namespace BookingProject.ViewComponents
{
    public class ServicesComponentPartial : ViewComponent
    {
        private readonly IMongoCollection<Services> _ServicesCollection;

        public ServicesComponentPartial(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _ServicesCollection = database.GetCollection<Services>(databaseSettings.ServicesCollectionName);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Services> ServicesItems = await _ServicesCollection.Find(_ => true).ToListAsync();
            return View(ServicesItems);
        }
    }
}
