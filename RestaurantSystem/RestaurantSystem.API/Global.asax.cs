namespace RestaurantSystem.API
{
    using RestaurantSystem.API.Infrastructure.Mappings;
    using RestaurantSystem.Infrastructure.Mappings;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            this.LoadAutomapper();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void LoadAutomapper()
        {
            var autoMapperConfig = new AutoMapperConfig(new List<Assembly>() { Assembly.GetExecutingAssembly() });
            autoMapperConfig.Execute();
            var helper = AutoMapperHelper.Instance;
        }
    }
}