using RestaurantSystem.Models;
using System.Data.Entity;
namespace RestaurantSystem.Data
{
    public interface IRestaurantDbContext
    {
        IDbSet<Category> Categories { get; set; }

        IDbSet<SubCategory> SubCategories { get; set; }

        IDbSet<Meal> Meals { get; set; }

        IDbSet<Cart> Carts { get; set; }

        int SaveChanges();
    }
}
