using RestaurantSystem.Data.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using RestaurantSystem.Models;
using RestaurantSystem.Models.BindingModel;
using RestaurantSystem.Models.ViewModels;

namespace RestaurantSystem.API.Controllers
{
    public class SubCategoriesController : BaseApiController
    {
        public SubCategoriesController(IRestaurantData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var subCategories =
                this.Data.SubCategories.All()
                .OrderBy(x => x.Id)
                .ProjectTo<SubCategoryViewModel>()
                .ToList();

            return this.Ok(subCategories);
        }

        [HttpGet]
        public IHttpActionResult GetSubCategoryById(int id)
        {
            var dbSubCategory = this.FindSubCategoryById(id);
            if (dbSubCategory == null)
            {
                return this.NotFound();
            }
            var subCategoryVM = Mapper.Map<SubCategory, SubCategoryViewModel>(dbSubCategory);
            return this.Ok(subCategoryVM);
        }

        [HttpGet]
        public IHttpActionResult GetSubCategoryMeals(int id)
        {
            var dbSubCategory = this.FindSubCategoryById(id);
            if (dbSubCategory == null)
            {
                return this.NotFound();
            }
            var meals =
                this.Data.Meals.All()
                .Where(m => m.SubCategoryId == id)
                .ProjectTo<MealViewModel>()
                .ToList();
            return this.Ok(meals);
        }

        //[Authorize]
        [HttpPost]
        public IHttpActionResult CreateSubCategory(SubCategoryBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            var dbSubCategory = Mapper.Map<SubCategoryBindingModel, SubCategory>(model);
            this.Data.SubCategories.Add(dbSubCategory);
            this.Data.SaveChanges();
            return this.Ok();
        }
        
        //[Authorize]
        [HttpPut]
        public IHttpActionResult UpdateSubCategory(int id, SubCategoryUpdateBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            var dbSubCategory = this.FindSubCategoryById(id);
            if (dbSubCategory == null)
            {
                return this.NotFound();
            }
            if (model.Title != null)
            {
                dbSubCategory.Title = model.Title;
            }
            if (model.CategoryId != null)
            {
                var catId = Convert.ToInt32(model.CategoryId);
                var categoryExists = this.Data.Categories.All().Any(c => c.Id == catId);
                if (categoryExists)
                {
                    dbSubCategory.CategoryId = catId;
                }
            }
            this.Data.SubCategories.Update(dbSubCategory);
            this.Data.SaveChanges();
            return this.Ok();
        }

        //[Authorize]
        [HttpDelete]
        public IHttpActionResult DeleteSubCategoryById(int id)
        {
            var dbSubCategory = this.FindSubCategoryById(id);
            if (dbSubCategory == null)
            {
                return this.NotFound();
            }
            this.Data.SubCategories.Delete(dbSubCategory);
            this.Data.SaveChanges();
            return this.Ok();
        }

        [NonAction]
        private SubCategory FindSubCategoryById(int id)
        {
            var subcategory = this.Data.SubCategories.All().FirstOrDefault(c => c.Id == id);
            return subcategory;
        }
    }
}
