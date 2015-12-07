namespace RestaurantSystem.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;
    using RestaurantSystem.Models;

    public class RestaurantDbContext : IdentityDbContext<User>, IRestaurantDbContext
    {
        public RestaurantDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Category> Categories { get; set; }
       
        public IDbSet<SubCategory> SubCategories { get; set; }

        public IDbSet<Meal> Meals { get; set; }
        
        public IDbSet<Cart> Carts { get; set; }

        public static RestaurantDbContext Create()
        {
            return new RestaurantDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOptional(x => x.Cart)
                .WithRequired(x => x.Owner)
                .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }
    }
}
