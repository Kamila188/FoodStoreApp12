using FoodStoreApp.Data;
using FoodStoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodStoreApp.Controllers
{
    public class ManufacturersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ManufacturersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Manufacturers> manufacturerList = _db.Manufacturers;
            return View(manufacturerList);
        }
       

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }


        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manufacturers cat)
        {

            _db.Manufacturers.Add(cat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            return View();
        }
        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            return View();
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var cat = _db.Manufacturers.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            _db.Manufacturers.Remove(cat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
