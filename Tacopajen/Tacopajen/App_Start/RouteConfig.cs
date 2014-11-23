using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tacopajen
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "Recept",
                url: "recept",
                defaults: new {controller = "Recept", action = "Recipe", id = UrlParameter.Optional});

            routes.MapRoute(
                name: "Other",
                url: "recept/andra-tacopajer",
                defaults: new { controller = "Recept", action = "Index" });

            routes.MapRoute(
                name: "LCHF",
                url: "recept/lchf-tacopaj",
                defaults: new { controller = "Recept", action = "Lchf" });

            routes.MapRoute(
                name: "Vegetarisk",
                url: "recept/vegetarisk-tacopaj",
                defaults: new { controller = "Recept", action = "Vegetarisk" });

            routes.MapRoute(
                name: "Kyckling",
                url: "recept/kyckling-tacopaj",
                defaults: new { controller = "Recept", action = "Kyckling" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
