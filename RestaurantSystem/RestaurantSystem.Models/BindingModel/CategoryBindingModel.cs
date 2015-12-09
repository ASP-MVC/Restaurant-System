using RestaurantSystem.Infrastructure.Mappings;
using System.ComponentModel.DataAnnotations;
namespace RestaurantSystem.Models.BindingModel
{
    public class CategoryBindingModel : IMapTo<Category>
    {
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Title { get; set; }
    }
}
