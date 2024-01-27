using BookingProject.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Settings;

namespace BookingProject.ViewComponents
{
    public class TestimonialComponentPartial : ViewComponent
    {
        private readonly IMongoCollection<Testimonials> _TestimonialCollection;

        public TestimonialComponentPartial(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _TestimonialCollection = database.GetCollection<Testimonials>(databaseSettings.TestimonialCollectionName);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Testimonials> TestimonialItems = await _TestimonialCollection.Find(_ => true).ToListAsync();
            return View(TestimonialItems);
        }
    }
}
