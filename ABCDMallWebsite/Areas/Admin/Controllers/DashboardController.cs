using Microsoft.AspNetCore.Mvc;
using ABCDMallWebsite.Data;

namespace ABCDMallWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DashboardController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminName") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.TotalShops = _db.Shops.Count();
            ViewBag.TotalMovies = _db.Movies.Count();
            ViewBag.TotalFeedbacks = _db.Feedbacks.Count();
            ViewBag.TotalTickets = _db.Tickets.Count();


            return View();
        }
    }
}
