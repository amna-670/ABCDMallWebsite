using ABCDMallWebsite.Data;
using ABCDMallWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABCDMallWebsite.Controllers
{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TicketController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        public IActionResult Book(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null) return NotFound();

            if (movie.TotalSeats <= movie.BookedSeats)
            {
                TempData["Error"] = "Sorry, no seats available!";
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        [HttpPost]
        public IActionResult Book(Ticket ticket)
        {
            ModelState.Remove("BookingDate");
            ModelState.Remove("Movie");

            if (!ModelState.IsValid)
            {
                var movieInvalid = _context.Movies.Find(ticket.MovieId);
                return View(movieInvalid);
            }

            var movie = _context.Movies.Find(ticket.MovieId);
            if (movie == null) return NotFound();

            int availableSeats = movie.TotalSeats - movie.BookedSeats;

            if (ticket.NumberOfSeats > availableSeats)
            {
                ViewBag.Error = "Only " + availableSeats + " seats left!"
;
                return View(movie);
            }

            if (ticket.NumberOfSeats > 50)
            {
                ViewBag.Error = "You can book maximum 50 seats!";
                return View(movie);
            }

            // Save booking
            ticket.Id = 0;
            ticket.BookingDate = DateTime.Now;
            movie.BookedSeats += ticket.NumberOfSeats;

            _context.Tickets.Add(ticket);
            _context.Movies.Update(movie);
            _context.SaveChanges();

            ViewBag.Success = "Ticket booked successfully!";
            return View(movie);
        }
    }
}
