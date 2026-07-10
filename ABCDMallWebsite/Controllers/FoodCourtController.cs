using Microsoft.AspNetCore.Mvc;
using ABCDMallWebsite.Data;
using ABCDMallWebsite.Models;

namespace ABCDMallWebsite.Controllers
{
    public class FoodCourtController : Controller
    {
        private readonly ApplicationDbContext _db;
        public FoodCourtController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<FoodCourt> foodCourtList = _db.FoodCourts.ToList();
            return View(foodCourtList);
        }

        public IActionResult Details(int id)
        {
            FoodCourt foodCourt = _db.FoodCourts.Find(id);
            if (foodCourt == null)
            {
                return NotFound();
            }
            return View(foodCourt);
        }

        public IActionResult Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return RedirectToAction("Index");
            }

            List<FoodCourt> results = _db.FoodCourts
                .Where(f => f.CounterName.Contains(query) || f.MenuItems.Contains(query))
                .ToList();

            ViewBag.Query = query; 
            return View("Index", results);
        }
    }
}
