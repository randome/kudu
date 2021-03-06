﻿using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using Kudu.Web.Models;

namespace Kudu.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Deployments",
                            "deployments/{slug}",
                            new { controller = "Deployments", action = "Index" });

            routes.MapRoute("Deploy",
                            "deployments/{slug}/deploy/{id}",
                            new { controller = "Deployments", action = "Deploy" });

            routes.MapRoute("DeploymentLog",
                            "deployments/{slug}/log/{id}",
                            new { controller = "Deployments", action = "Log" });

            routes.MapRoute("DeploymentLogVerbose",
                            "deployments/{slug}/log/{id}/{logId}",
                            new { controller = "Deployments", action = "Details" });

            routes.MapRoute("ApplicationCreate",
                            "application/create",
                            new { controller = "Application", action = "Create" });

            routes.MapRoute("ApplicationDetails",
                            "application/{slug}",
                            new { controller = "Application", action = "Details" });

            routes.MapRoute("Configuration",
                            "configuration/{slug}",
                            new { controller = "Settings", action = "Index" });

            routes.MapRoute("Trace",
                            "trace/{slug}",
                            new { controller = "Application", action = "Trace" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{slug}", // URL with parameters
                new { controller = "Application", action = "Index", slug = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}