using ABCDMallWebsite.Data;
using ABCDMallWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABCDMallWebsite.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ShopController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Shop> shopList = _db.Shops.ToList();
            return View(shopList);
        }

        public IActionResult Details(int id)
        {
            Shop shop = _db.Shops.Find(id);
            if (shop == null)
            {
                return NotFound();
            }
            return View(shop);
        }

        public IActionResult Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return RedirectToAction("Index");
            }

            List<Shop> results = _db.Shops
                .Where(s => s.Name.Contains(query))
                .ToList();

            ViewBag.Query = query; 
            return View("Index", results);
        }
    }
}
