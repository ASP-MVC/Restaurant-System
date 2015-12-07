using System.ComponentModel.DataAnnotations;
namespace RestaurantSystem.Models
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Title { get; set; }

        public string Description { get; set; }

        public FoodType FoodType { get; set; }

        public decimal Price { get; set; }

        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
