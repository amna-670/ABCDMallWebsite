using System.ComponentModel.DataAnnotations;

namespace ABCDMallWebsite.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "*Name is required")]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(1000)]
        public string Message { get; set; }

        public DateTime SubmittedOn { get; set; } = DateTime.Now;
    }
}
