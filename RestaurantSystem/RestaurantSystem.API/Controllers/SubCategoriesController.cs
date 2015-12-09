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
                this.Data.Categories.All()
                .OrderBy(x => x.Id)
                .ProjectTo<SubCategoryViewModel>()
                .ToList();

            return this.Ok(subCategories);
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

        //[Authorize]
        [HttpPut]
        public IHttpActionResult UpdateSubCategory(int id, SubCategoryBindingModel model)
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
            //dbSubCategory.Title = model.Title;
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
