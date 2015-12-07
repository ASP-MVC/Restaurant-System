using Microsoft.Owin;

using RestaurantSystem.API;

[assembly: OwinStartup(typeof(Startup))]

namespace RestaurantSystem.API
{
    using System.Reflection;
    using System.Web.Http;

    using Ninject;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;

    using Owin;

    using RestaurantSystem.Data;
    using RestaurantSystem.Data.UoW;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
            this.ConfigureNinject(app);
        }

        private void ConfigureNinject(IAppBuilder app)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IRestaurantDbContext>().To<RestaurantDbContext>();
            kernel.Bind<IRestaurantData>()
                  .To<RestaurantData>()
                  .WithConstructorArgument("context", new RestaurantDbContext());
            var httpConfig = new HttpConfiguration();
            WebApiConfig.Register(httpConfig);
            app.UseNinjectMiddleware(() => kernel).UseNinjectWebApi(httpConfig);
        }
    }
}