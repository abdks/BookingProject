using BookingProject.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Settings;

namespace BookingProject.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IMongoCollection<Testimonials> _Testimonialcollection;

        public TestimonialController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _Testimonialcollection = database.GetCollection<Testimonials>(_databaseSettings.TestimonialCollectionName);
        }
        public async Task<ActionResult> Index()
        {
            var values = await _Testimonialcollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateTestimonials()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonials(Testimonials Testimonials)
        {
            await _Testimonialcollection.InsertOneAsync(Testimonials);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteTestimonials(string id)
        {
            await _Testimonialcollection.DeleteManyAsync(x => x.TestimonalsID == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonials(string id)
        {
            var values = await _Testimonialcollection.Find<Testimonials>(x => x.TestimonalsID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonials(Testimonials Testimonials)
        {
            await _Testimonialcollection.FindOneAndReplaceAsync(x => x.TestimonalsID == Testimonials.TestimonalsID, Testimonials);
            return RedirectToAction("Index");
        }

    }
}
