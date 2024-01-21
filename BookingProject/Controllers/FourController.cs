using BookingProject.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Settings;

namespace BookingProject.Controllers
{
    public class FourController : Controller
    {
        private readonly IMongoCollection<Fours> _Fourcollection;

        public FourController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _Fourcollection = database.GetCollection<Fours>(_databaseSettings.FourImagesCollectionName);
        }
        public async Task<ActionResult> Index()
        {
            var values = await _Fourcollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateFours()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFours(Fours Four)
        {
            await _Fourcollection.InsertOneAsync(Four);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteFours(string id)
        {
            await _Fourcollection.DeleteManyAsync(x => x.FoursID == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFours(string id)
        {
            var values = await _Fourcollection.Find<Fours>(x => x.FoursID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFours(Fours Four)
        {
            await _Fourcollection.FindOneAndReplaceAsync(x => x.FoursID == Four.FoursID, Four);
            return RedirectToAction("Index");
        }

    }
}
