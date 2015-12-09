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
            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<Category, CategoryBindingModel>().ReverseMap();
        }
    }
}