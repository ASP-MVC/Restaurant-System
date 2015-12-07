namespace RestaurantSystem.API.Controllers
{
    using System.Web.Http;

    using RestaurantSystem.Data.UoW;

    public abstract class BaseApiController : ApiController
    {
        protected BaseApiController(IRestaurantData data)
        {
            this.Data = data;
        }

        protected IRestaurantData Data { get; private set; }

        protected bool IsAuthenticated()
        {
            if (this.User == null)
            {
                return false;
            }
            return this.User.Identity.IsAuthenticated;
        }
    }
}