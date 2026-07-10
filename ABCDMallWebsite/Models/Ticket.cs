using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCDMallWebsite.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }

        public Movie? Movie { get; set; }

        [Required(ErrorMessage = "Your name is required")]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Card number is required")]
        public string CardNumber { get; set; }

        [Required]
        [Range(1, 50, ErrorMessage = "You can book between 1 and 50 seats")]
        public int NumberOfSeats { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.Now;
    }
}