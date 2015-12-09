using RestaurantSystem.Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Models.BindingModel
{
    public class SubCategoryUpdateBindingModel : IMapTo<SubCategory>
    {
        [StringLength(255, MinimumLength = 1)]
        public string Title { get; set; }

        public int? CategoryId { get; set; }
    }
}
