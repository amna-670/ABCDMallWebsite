using ABCDMallWebsite.Data;
using ABCDMallWebsite.Models;
using Microsoft.AspNetCore.Mvc;

public class GalleryController : Controller
{
    private readonly ApplicationDbContext _db;
    public GalleryController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        List<Gallery> galleryList = _db.Galleries.ToList();
        return View(galleryList);
    }
}
