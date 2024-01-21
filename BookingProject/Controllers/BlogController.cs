using BookingProject.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Settings;

namespace BookingProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly IMongoCollection<Blogs> _Blogcollection;

        public BlogController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _Blogcollection = database.GetCollection<Blogs>(_databaseSettings.BlogCollectionName);
        }
        public async Task<ActionResult> Index()
        {
            var values = await _Blogcollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateBlogs()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlogs(Blogs Blogs)
        {
            await _Blogcollection.InsertOneAsync(Blogs);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteBlogs(string id)
        {
            await _Blogcollection.DeleteManyAsync(x => x.BlogsID == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBlogs(string id)
        {
            var values = await _Blogcollection.Find<Blogs>(x => x.BlogsID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlogs(Blogs Blogs)
        {
            await _Blogcollection.FindOneAndReplaceAsync(x => x.BlogsID == Blogs.BlogsID, Blogs);
            return RedirectToAction("Index");
        }

    }
}
