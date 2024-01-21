using BookingProject.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Settings;

namespace BookingProject.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IMongoCollection<Services> _Servicescollection;

        public ServicesController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _Servicescollection = database.GetCollection<Services>(_databaseSettings.ServicesCollectionName);
        }
        public async Task<ActionResult> Index()
        {
            var values = await _Servicescollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateServices()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateServices(Services Services)
        {
            await _Servicescollection.InsertOneAsync(Services);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteServices(string id)
        {
            await _Servicescollection.DeleteManyAsync(x => x.ServicesID == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateServices(string id)
        {
            var values = await _Servicescollection.Find<Services>(x => x.ServicesID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateServices(Services Services)
        {
            await _Servicescollection.FindOneAndReplaceAsync(x => x.ServicesID == Services.ServicesID, Services);
            return RedirectToAction("Index");
        }

    }
}
