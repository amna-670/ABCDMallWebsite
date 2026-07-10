using Microsoft.AspNetCore.Mvc;
using ABCDMallWebsite.Data;

namespace ABCDMallWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var admin = _db.Admins
                .FirstOrDefault(a => a.Username == username && a.Password == password);

            if (admin != null)
            {
                HttpContext.Session.SetString("AdminName", admin.Username);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
