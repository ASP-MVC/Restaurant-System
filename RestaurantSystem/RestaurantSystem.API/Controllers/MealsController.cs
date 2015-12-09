using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using RestaurantSystem.Data.UoW;
using RestaurantSystem.Models;
using RestaurantSystem.Models.BindingModel;
using RestaurantSystem.Models.ViewModels;

namespace RestaurantSystem.API.Controllers
{
    public class MealsController : BaseApiController
    {
        public MealsController(IRestaurantData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var meals =
                this.Data.Meals.All()
                .OrderBy(x => x.Id)
                .ProjectTo<MealViewModel>()
                .ToList();

            return this.Ok(meals);
        }

        [HttpGet]
        public IHttpActionResult GetMealById(int id)
        {
            var dbMeal = this.FindMealById(id);
            if (dbMeal == null)
            {
                return this.NotFound();
            }
            var mealVM = Mapper.Map<Meal, MealViewModel>(dbMeal);
            return this.Ok(mealVM);
        }

        //[Authorize]
        [HttpPost]
        public IHttpActionResult CreateMeal(MealBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            var dbMeal = Mapper.Map<MealBindingModel, Meal>(model);
            this.Data.Meals.Add(dbMeal);
            this.Data.SaveChanges();
            return this.Ok();
        }
        

        //[Authorize]
        [HttpPut]
        public IHttpActionResult UpdateMeal(int id, MealUpdateBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            var dbMeal = this.FindMealById(id);
            if (dbMeal == null)
            {
                return this.NotFound();
            }

            if (model.Title != null)
            {
                dbMeal.Title = model.Title;
            }
            if (model.Description != null)
            {
                dbMeal.Description = model.Description;
            }
            if (model.SubCategoryId != null)
            {
                var subCatId = Convert.ToInt32(model.SubCategoryId);
                var subCategoryExists = this.Data.SubCategories.All().Any(c => c.Id == subCatId);
                if (subCategoryExists)
                {
                    dbMeal.SubCategoryId = subCatId;
                }
            }
            if (model.Price != null)
            {
                var price = Convert.ToDecimal(model.Price);
                dbMeal.Price = price;
            }
            
            this.Data.Meals.Update(dbMeal);
            this.Data.SaveChanges();
            return this.Ok();
        }

        //[Authorize]
        [HttpDelete]
        public IHttpActionResult DeleteMealById(int id)
        {
            var dbMeal = this.FindMealById(id);
            if (dbMeal == null)
            {
                return this.NotFound();
            }
            this.Data.Meals.Delete(dbMeal);
            this.Data.SaveChanges();
            return this.Ok();
        }

        [NonAction]
        private Meal FindMealById(int id)
        {
            var meal = this.Data.Meals.All().FirstOrDefault(c => c.Id == id);
            return meal;
        }
    }
}
