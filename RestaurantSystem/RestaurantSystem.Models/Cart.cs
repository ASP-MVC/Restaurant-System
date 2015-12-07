using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace RestaurantSystem.Models
{
    public class Cart
    {
        public Cart()
        {
            this.ProductsInCart = new HashSet<Meal>();
        }

        [Key]
        public int Id { get; set; }

        public bool HasItems { get; set; }

        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<Meal> ProductsInCart { get; set; }
    }
}
