using System.ComponentModel.DataAnnotations;

namespace ABCDMallWebsite.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Shop name is required")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500)]
        public string Description { get; set; }

        public string? ImagePath { get; set; }

        [Required(ErrorMessage = "Floor is required")]
        [StringLength(50)]
        public string Floor { get; set; }
    }
}
