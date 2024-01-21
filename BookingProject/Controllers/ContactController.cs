using BookingProject.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Settings;

namespace BookingProject.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IMongoCollection<Contacts> _Contactscollection;

        public ContactsController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _Contactscollection = database.GetCollection<Contacts>(_databaseSettings.ContactCollectionName);
        }
        public async Task<ActionResult> Index()
        {
            var values = await _Contactscollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateContacts()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContacts(Contacts Contacts)
        {
            await _Contactscollection.InsertOneAsync(Contacts);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteContacts(string id)
        {
            await _Contactscollection.DeleteManyAsync(x => x.ContactsID == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateContacts(string id)
        {
            var values = await _Contactscollection.Find<Contacts>(x => x.ContactsID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContacts(Contacts Contacts)
        {
            await _Contactscollection.FindOneAndReplaceAsync(x => x.ContactsID == Contacts.ContactsID, Contacts);
            return RedirectToAction("Index");
        }

    }
}
