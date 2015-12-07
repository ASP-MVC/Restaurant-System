using RestaurantSystem.Data.Repositories;
using RestaurantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Data.UoW
{
    public interface IRestaurantData
    {
        IRepository<User> Users { get; }

        IRepository<Category> Categories { get; }

        IRepository<SubCategory> SubCategories { get; }

        IRepository<Cart> Carts { get; }

        IRepository<Meal> Meals { get; }

        int SaveChanges();
    }
}
