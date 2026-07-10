using Microsoft.AspNetCore.Mvc;
using ABCDMallWebsite.Data;

namespace ABCDMallWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeedbackController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FeedbackController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminName") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var feedbacks = _db.Feedbacks.ToList();
            return View(feedbacks);
        }
    }
}
