using AutoMapper;
using RestaurantSystem.Models;
using RestaurantSystem.Models.BindingModel;
using RestaurantSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantSystem.API.Infrastructure.Mappings
{
    public sealed class AutoMapperHelper
    {
        private static AutoMapperHelper instance;
        private static object obj = new Object();
        private AutoMapperHelper()
        {
            this.CreateCustomMappings();
        }

        public static AutoMapperHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new AutoMapperHelper();
                        }
                    }
                }
                return instance;
            }
        }

        private void CreateCustomMappings()
        {
            // Category
            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<Category, CategoryBindingModel>().ReverseMap();

            //Subcategory
            Mapper.CreateMap<SubCategory, SubCategoryBindingModel>().ReverseMap();
            Mapper.CreateMap<SubCategory, SubCategoryUpdateBindingModel>().ReverseMap();
            Mapper.CreateMap<SubCategory, SubCategoryViewModel>()
                .ForMember(s => s.CategoryId, opt => opt.MapFrom(s => s.CategoryId))
                .ForMember(s => s.CategoryTitle, opt => opt.MapFrom(s => s.Category.Title))
                .ForMember(s => s.Meals, opt => opt.MapFrom(s => s.Meals));

            //Meal
            Mapper.CreateMap<Meal, MealBindingModel>().ReverseMap();
            Mapper.CreateMap<Meal, MealUpdateBindingModel>().ReverseMap();
            Mapper.CreateMap<Meal, MealViewModel>()
                .ForMember(m => m.SubCategoryName, opt => opt.MapFrom(m => m.SubCategory.Title));
        }
    }
}