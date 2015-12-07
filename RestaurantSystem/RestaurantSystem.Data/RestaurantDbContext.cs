namespace RestaurantSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using RestaurantSystem.Models;

    public class RestaurantDbContext : IdentityDbContext<User>
    {
        public RestaurantDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static RestaurantDbContext Create()
        {
            return new RestaurantDbContext();
        }
    }
}
