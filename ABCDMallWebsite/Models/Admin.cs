using System.ComponentModel.DataAnnotations;

namespace ABCDMallWebsite.Models
{
    public class Admin
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100)]
        public string Password { get; set; }
    }
}
