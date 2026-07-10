using System.ComponentModel.DataAnnotations;

namespace ABCDMallWebsite.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(150)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [StringLength(50)]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Show time is required")]
        public DateTime ShowTime { get; set; }

        [Required]
        [Range(1, 500, ErrorMessage = "Total seats must be between 1 and 500")]
        public int TotalSeats { get; set; }

        public int BookedSeats { get; set; } = 0;

        public string? ImagePath { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
