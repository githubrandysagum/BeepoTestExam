using BeepoExamProject.Authentication;
using BeepoExamProject.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BeepoExamProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Filters.Add(new ModelValidationAttribute());
            //config.Filters.Add(new JwtAuthentication());


            config.EnableCors();

          


        }
    }
}
