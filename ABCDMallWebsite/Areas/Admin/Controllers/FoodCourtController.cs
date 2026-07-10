using Microsoft.AspNetCore.Mvc;
using ABCDMallWebsite.Data;
using ABCDMallWebsite.Models;

namespace ABCDMallWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FoodCourtController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FoodCourtController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminName") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var foodCourts = _db.FoodCourts.ToList();
            return View(foodCourts);
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

        // Save new food court
        [HttpPost]
        public IActionResult Create(FoodCourt foodCourt, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(foodCourt);
            }

            if (imageFile != null)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/foodcourts");
                Directory.CreateDirectory(folder);
                string fileName = imageFile.FileName;
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
                foodCourt.ImagePath = "/images/foodcourts/" + fileName;
            }

            _db.FoodCourts.Add(foodCourt);
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

            var foodCourt = _db.FoodCourts.Find(id);
            return View(foodCourt);
        }

        // Save edited food court
        [HttpPost]
        public IActionResult Edit(FoodCourt foodCourt, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(foodCourt);
            }

            if (imageFile != null)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/foodcourts");
                Directory.CreateDirectory(folder);

                string fileName = imageFile.FileName;
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                foodCourt.ImagePath = "/images/foodcourts/" + fileName;
            }

            _db.FoodCourts.Update(foodCourt);
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

            var foodCourt = _db.FoodCourts.Find(id);
            return View(foodCourt);
        }

        // Delete food court
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var foodCourt = _db.FoodCourts.Find(id);
            if (foodCourt != null)
            {
                _db.FoodCourts.Remove(foodCourt);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
