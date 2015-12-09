using RestaurantSystem.Infrastructure.Mappings;

namespace RestaurantSystem.Models.ViewModels
{
    public class MealViewModel : IMapFrom<Meal>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public FoodType FoodType { get; set; }

        public decimal Price { get; set; }

        public string SubCategoryName { get; set; }
    }
}
