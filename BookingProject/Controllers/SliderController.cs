using BookingProject.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Settings;

namespace BookingProject.Controllers
{
    public class SliderController : Controller
    {
        private readonly IMongoCollection<Sliders> _slidercollection;

        public SliderController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _slidercollection = database.GetCollection<Sliders>(_databaseSettings.SliderCollectionName);
        }
        public async Task<ActionResult> Index()
        {
            var values = await _slidercollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateSliders()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSliders(Sliders Sliders)
        {
            await _slidercollection.InsertOneAsync(Sliders);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteSliders(string id)
        {
            await _slidercollection.DeleteManyAsync(x => x.SlidersID == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateSliders(string id)
        {
            var values = await _slidercollection.Find<Sliders>(x => x.SlidersID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSliders(Sliders Sliders)
        {
            await _slidercollection.FindOneAndReplaceAsync(x => x.SlidersID == Sliders.SlidersID, Sliders);
            return RedirectToAction("Index");
        }

    }
}
