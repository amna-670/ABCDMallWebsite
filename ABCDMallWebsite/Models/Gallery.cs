using System.ComponentModel.DataAnnotations;

namespace ABCDMallWebsite.Models
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [StringLength(50)]
        public string Category { get; set; }
    }
}
