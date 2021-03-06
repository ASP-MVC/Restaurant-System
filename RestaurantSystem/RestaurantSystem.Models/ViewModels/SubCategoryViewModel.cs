﻿using RestaurantSystem.Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Models.ViewModels
{
    public class SubCategoryViewModel : IMapFrom<SubCategory>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int CategoryId { get; set; }

        public string CategoryTitle { get; set; }

        public IEnumerable<MealViewModel> Meals { get; set; }
    }
}
