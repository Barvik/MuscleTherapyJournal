using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MuscleTherapyJournal.Infrastructure.WebApi;
using StructureMap;

namespace MuscleTherapyJournal
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.DependencyResolver = new StructureMapResolver(ObjectFactory.Container);
        }
    }
}
