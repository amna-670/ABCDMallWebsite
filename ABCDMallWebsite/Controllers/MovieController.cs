using Microsoft.AspNetCore.Mvc;
using ABCDMallWebsite.Data;
using ABCDMallWebsite.Models;

namespace ABCDMallWebsite.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Movie> movieList = _db.Movies.ToList();
            return View(movieList);
        }

        public IActionResult Details(int id)
        {
            Movie movie = _db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        public IActionResult Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return RedirectToAction("Index");
            }

            List<Movie> results = _db.Movies
                .Where(m => m.Title.Contains(query) || m.Genre.Contains(query))
                .ToList();

            ViewBag.Query = query; 
            return View("Index", results);
        }
    }
}
