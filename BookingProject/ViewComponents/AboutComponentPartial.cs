using BookingProject.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Settings;

namespace BookingProject.ViewComponents
{
    public class AboutComponentPartial : ViewComponent
    {
        private readonly IMongoCollection<Abouts> _AboutCollection;

        public AboutComponentPartial(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _AboutCollection = database.GetCollection<Abouts>(databaseSettings.AboutCollectionName);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Abouts> AboutItems = await _AboutCollection.Find(_ => true).ToListAsync();
            return View(AboutItems);
        }
    }
}
