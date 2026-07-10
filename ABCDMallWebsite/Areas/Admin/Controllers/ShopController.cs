using Microsoft.AspNetCore.Mvc;
using ABCDMallWebsite.Data;
using ABCDMallWebsite.Models;

namespace ABCDMallWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ShopController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminName") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var shops = _db.Shops.ToList();
            return View(shops);
        }

        // Show create form
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AdminName") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // Save new shop
        [HttpPost]
        public IActionResult Create(Shop shop, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(shop);
            }

            if (imageFile != null)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/shops");
                Directory.CreateDirectory(folder);

                string fileName = imageFile.FileName;
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                shop.ImagePath = "/images/shops/" + fileName;
            }

            _db.Shops.Add(shop);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Show edit form
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("AdminName") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var shop = _db.Shops.Find(id);
            return View(shop);
        }

        // Save edited shop
        [HttpPost]
        public IActionResult Edit(Shop shop, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(shop);
            }

            if (imageFile != null)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/shops");
                Directory.CreateDirectory(folder);

                string fileName = imageFile.FileName;
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                shop.ImagePath = "/images/shops/" + fileName;
            }

            _db.Shops.Update(shop);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Show delete confirmation
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("AdminName") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var shop = _db.Shops.Find(id);
            return View(shop);
        }

        // Delete shop
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var shop = _db.Shops.Find(id);
            if (shop != null)
            {
                _db.Shops.Remove(shop);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
