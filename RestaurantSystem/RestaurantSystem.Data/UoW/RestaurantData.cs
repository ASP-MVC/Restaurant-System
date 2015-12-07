using RestaurantSystem.Data.Repositories;
using RestaurantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Data.UoW
{
    public class RestaurantData : IRestaurantData
    {
        private IRestaurantDbContext context;
        private IDictionary<Type, object> repositories;

        public RestaurantData(IRestaurantDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }

        public IRepository<SubCategory> SubCategories
        {
            get { return this.GetRepository<SubCategory>(); }
        }

        public IRepository<Meal> Meals
        {
            get { return this.GetRepository<Meal>(); }
        }

        public IRepository<Cart> Carts
        {
            get { return this.GetRepository<Cart>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericEFRepository<T>);

                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
