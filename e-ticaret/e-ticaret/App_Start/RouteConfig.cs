using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace e_ticaret
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{directory}/{resource}.asmx/{*pathInfo}");
            //routes.IgnoreRoute("{*x}", new { x = @".*\.asmx(/.*)?" });           
            routes.IgnoreRoute("e-ticaretyonetimdata.asmx/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Shop", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
