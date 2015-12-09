namespace RestaurantSystem.API.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper.QueryableExtensions;

    using RestaurantSystem.Data.UoW;
    using RestaurantSystem.Models.ViewModels;
    using RestaurantSystem.Models.BindingModel;
    using AutoMapper;
    using RestaurantSystem.Models;

    public class CategoriesController : BaseApiController
    {
        public CategoriesController(IRestaurantData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var categories =
                this.Data.Categories.All()
                .OrderBy(x => x.Id)
                .ProjectTo<CategoryViewModel>()
                .ToList();

            return this.Ok(categories);
        }

        [HttpGet]
        public IHttpActionResult GetAllSubCategories(int id)
        {
            var dbCategory = this.FindCategoryById(id);
            if (dbCategory == null)
            {
                return this.NotFound();
            }
            var subCategories =
                this.Data.SubCategories.All()
                .Where(s => s.CategoryId == id)
                .ProjectTo<SubCategoryViewModel>()
                .ToList();
            return this.Ok(subCategories);
        }

        //[Authorize]
        [HttpPost]
        public IHttpActionResult CreateCategory(CategoryBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            var dbCategory = Mapper.Map<CategoryBindingModel, Category>(model);
            this.Data.Categories.Add(dbCategory);
            this.Data.SaveChanges();
            return this.Ok();
        }

        [HttpGet]
        public IHttpActionResult GetCategoryById(int id)
        {
            var dbCategory = this.FindCategoryById(id);
            if (dbCategory == null)
            {
                return this.NotFound();
            }
            var categoryVM = Mapper.Map<Category, CategoryViewModel>(dbCategory);
            return this.Ok(categoryVM);
        }

        //[Authorize]
        [HttpPut]
        public IHttpActionResult UpdateCategory(int id, CategoryBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            var dbCategory = this.FindCategoryById(id);
            if (dbCategory == null)
            {
                return this.NotFound();
            }
            dbCategory.Title = model.Title;
            this.Data.Categories.Update(dbCategory);
            this.Data.SaveChanges();
            return this.Ok();
        }

        //[Authorize]
        [HttpDelete]
        public IHttpActionResult DeleteCategoryById(int id)
        {
            var dbCategory = this.FindCategoryById(id);
            if (dbCategory == null)
            {
                return this.NotFound();
            }
            this.Data.Categories.Delete(dbCategory);
            this.Data.SaveChanges();
            return this.Ok();
        }

        [NonAction]
        private Category FindCategoryById(int id)
        {
            var category = this.Data.Categories.All().FirstOrDefault(c => c.Id == id);
            return category;
        }
    }
}
