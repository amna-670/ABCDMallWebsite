using Microsoft.AspNetCore.Mvc;
using ABCDMallWebsite.Data;
using Microsoft.EntityFrameworkCore;

namespace ABCDMallWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _db;
         public TicketController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminName") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var tickets = _db.Tickets.Include(t => t.Movie).ToList();
            return View(tickets);
        }
    }
}
