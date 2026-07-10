using System.ComponentModel.DataAnnotations;

namespace ABCDMallWebsite.Models
{
    public class FoodCourt
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Counter name is required")]
        [StringLength(100)]
        public string CounterName { get; set; }

        [Required(ErrorMessage = "Menu items are required")]
        [StringLength(1000)]
        public string MenuItems { get; set; }

        public string? ImagePath { get; set; }
    }
}
