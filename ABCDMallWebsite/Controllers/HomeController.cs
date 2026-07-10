using ABCDMallWebsite.Data;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        ViewBag.Shops = _context.Shops.Take(4).ToList();
        ViewBag.Movies = _context.Movies.Take(3).ToList();
        ViewBag.FoodCourts = _context.FoodCourts.Take(4).ToList();
        ViewBag.Galleries = _context.Galleries.Take(3).ToList();

        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

}
