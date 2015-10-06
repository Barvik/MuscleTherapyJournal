using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MuscleTherapyJournal.App_Start;
using MuscleTherapyJournal.Common.Infrastructure;

namespace MuscleTherapyJournal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Mapping (needs to run before DI setup)
            AutomapperBootstrapper.Bootstrap();

            //Set up StructureMap
            StructuremapMvc.Start();

            log4net.Config.XmlConfigurator.Configure();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
