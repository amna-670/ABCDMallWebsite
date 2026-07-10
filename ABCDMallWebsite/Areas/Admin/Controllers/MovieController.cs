using Microsoft.AspNetCore.Mvc;
using ABCDMallWebsite.Data;
using ABCDMallWebsite.Models;

namespace ABCDMallWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
         public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Show all movies
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminName") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var movies = _db.Movies.ToList();
            return View(movies);
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

        // Save new movie
        [HttpPost]
        public IActionResult Create(Movie movie, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            movie.BookedSeats = 0;

            if (imageFile != null)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/movies");
                Directory.CreateDirectory(folder);

                string fileName = imageFile.FileName;
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                movie.ImagePath = "/images/movies/" + fileName;
            }

            _db.Movies.Add(movie);
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

            var movie = _db.Movies.Find(id);
            return View(movie);
        }

        // Save edited movie
        [HttpPost]
        public IActionResult Edit(Movie movie, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            if (imageFile != null)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/movies");
                Directory.CreateDirectory(folder);

                string fileName = imageFile.FileName;
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                movie.ImagePath = "/images/movies/" + fileName;
            }

            _db.Movies.Update(movie);
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

            var movie = _db.Movies.Find(id);
            return View(movie);
        }

        // Delete movie
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _db.Movies.Find(id);
            if (movie != null)
            {
                _db.Movies.Remove(movie);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
