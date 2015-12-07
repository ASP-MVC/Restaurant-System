namespace RestaurantSystem.API.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using RestaurantSystem.Data.UoW;

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
                this.Data.Categories.All().OrderBy(x => x.Id).ToList();

            return this.Ok(categories);
        }
    }
}
