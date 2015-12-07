namespace RestaurantSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.SubCategories = new HashSet<SubCategory>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength=1)]
        public string Title { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
