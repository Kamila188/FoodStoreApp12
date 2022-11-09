using FoodStoreApp.Data;
using FoodStoreApp.Models;
using FoodStoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodStoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            IEnumerable<Product> productList = _db.Product;
            foreach (var product in productList)
            {
                product.Category = _db.Category.FirstOrDefault(u => u.Id == product.CategoryId);
            };
            return View(productList);
        }
        // GET - UPSERT
        public IActionResult Upsert(int? id)
        {
            ProductViewModel viewModel = new ProductViewModel()
            {
                Product = new(),
                CategorySelectList = _db.Category.Select(item => new SelectListItem
                {
                    Text = item.Title,
                    Value = item.Id.ToString()
                })
            };
            if (id == null)
            {
                return View(viewModel);
            }
            else
            {
                // Обновляем выбранную позицию товара
                viewModel.Product = _db.Product.Find(id);
                if (viewModel.Product == null)
                    return NotFound();

                return View(viewModel);
            }
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod)
        {
                _db.Product.Add(prod);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
