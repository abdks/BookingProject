using BookingProject.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Settings;

namespace BookingProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly IMongoCollection<Abouts> _Aboutcollection;

        public AboutController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _Aboutcollection = database.GetCollection<Abouts>(_databaseSettings.AboutCollectionName);
        }
        public async Task<ActionResult> Index()
        {
            var values = await _Aboutcollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateAbouts()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbouts(Abouts Abouts)
        {
            await _Aboutcollection.InsertOneAsync(Abouts);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteAbouts(string id)
        {
            await _Aboutcollection.DeleteManyAsync(x => x.AboutID == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAbouts(string id)
        {
            var values = await _Aboutcollection.Find<Abouts>(x => x.AboutID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbouts(Abouts Abouts)
        {
            await _Aboutcollection.FindOneAndReplaceAsync(x => x.AboutID == Abouts.AboutID, Abouts);
            return RedirectToAction("Index");
        }

    }
}
