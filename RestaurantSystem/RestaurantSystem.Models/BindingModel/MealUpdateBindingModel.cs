using System.ComponentModel.DataAnnotations;
using RestaurantSystem.Infrastructure.Mappings;

namespace RestaurantSystem.Models.BindingModel
{
    public class MealUpdateBindingModel : IMapTo<Meal>
    {
        [StringLength(255, MinimumLength = 1)]
        public string Title { get; set; }

        public string Description { get; set; }

        public FoodType FoodType { get; set; }

        public decimal? Price { get; set; }

        public int? SubCategoryId { get; set; }
    }
}