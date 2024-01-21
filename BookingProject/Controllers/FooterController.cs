using BookingProject.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Settings;

namespace BookingProject.Controllers
{
    public class FooterController : Controller
    {
        private readonly IMongoCollection<Footers> _Footercollection;

        public FooterController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _Footercollection = database.GetCollection<Footers>(_databaseSettings.FooterCollectionName);
        }
        public async Task<ActionResult> Index()
        {
            var values = await _Footercollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateFooters()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooters(Footers Footers)
        {
            await _Footercollection.InsertOneAsync(Footers);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteFooters(string id)
        {
            await _Footercollection.DeleteManyAsync(x => x.FootersID == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFooters(string id)
        {
            var values = await _Footercollection.Find<Footers>(x => x.FootersID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFooters(Footers Footers)
        {
            await _Footercollection.FindOneAndReplaceAsync(x => x.FootersID == Footers.FootersID, Footers);
            return RedirectToAction("Index");
        }

    }
}
