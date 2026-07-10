using Microsoft.AspNetCore.Mvc;
using ABCDMallWebsite.Data;
using ABCDMallWebsite.Models;

namespace ABCDMallWebsite.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly ApplicationDbContext _db;
         public FeedbackController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.SubmittedOn = DateTime.Now;

                _db.Feedbacks.Add(feedback);
                _db.SaveChanges();

                TempData["Success"] = "Thank you for your feedback!";
                return RedirectToAction("Index");
            }
            return View(feedback);
        }
    }
}
