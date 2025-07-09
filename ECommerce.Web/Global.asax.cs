using AutoMapper;
using ECommerce.Web.App_Start;
using ECommerce.Web.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using ECommerce.Data.Context;


namespace ECommerce.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            System.Data.Entity.Database.SetInitializer(new ECommerce.Data.Context.ApplicationDbInitializer());

            using (var context = new ApplicationDbContext())
            {
                context.Users.FirstOrDefault(); // This forces DB init and runs Seed()
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            

            DIContainer.Register();
            //MapsterConfig.RegisterMappings();
            //System.Data.Entity.Database.SetInitializer(new ECommerce.Data.Context.ApplicationDbInitializer());

        }
    }
}
