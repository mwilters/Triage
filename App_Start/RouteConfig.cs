using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Triage
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PatientRecords",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "PatientRecords", action = "Edit", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Analytics",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Analytics", action = "Index", id = UrlParameter.Optional }
            );
                        routes.MapRoute(
                name: "Patients",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Patients", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Doctors",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Doctors", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Main",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Main", id = UrlParameter.Optional }
            );
        }
    }
}
