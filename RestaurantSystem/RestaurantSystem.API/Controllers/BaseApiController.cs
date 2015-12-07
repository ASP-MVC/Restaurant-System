using RestaurantSystem.Data.UoW;
using RestaurantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace RestaurantSystem.API.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        public BaseApiController(IRestaurantData data)
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
