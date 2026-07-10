using Microsoft.AspNetCore.Mvc;
using ABCDMallWebsite.Data;
using ABCDMallWebsite.Models;

namespace ABCDMallWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GalleryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GalleryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminName") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var galleryList = _db.Galleries.ToList();
            return View(galleryList);
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

        // Save new gallery image
        [HttpPost]
        public IActionResult Create(Gallery gallery, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(gallery);
            }

            if (imageFile != null)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/gallery");
                Directory.CreateDirectory(folder);
                string fileName = imageFile.FileName;
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                gallery.ImagePath = "/images/gallery/" + fileName;
            }

            _db.Galleries.Add(gallery);
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

            var gallery = _db.Galleries.Find(id);
            return View(gallery);
        }

        // Save edited gallery image
        [HttpPost]
        public IActionResult Edit(Gallery gallery, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(gallery);
            }

            if (imageFile != null)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/gallery");
                Directory.CreateDirectory(folder);

                string fileName = imageFile.FileName;
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                gallery.ImagePath = "/images/gallery/" + fileName;
            }

            _db.Galleries.Update(gallery);
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

            var gallery = _db.Galleries.Find(id);
            return View(gallery);
        }

        // Delete gallery image
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var gallery = _db.Galleries.Find(id);
            if (gallery != null)
            {
                _db.Galleries.Remove(gallery);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
