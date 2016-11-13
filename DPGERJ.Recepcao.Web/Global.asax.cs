using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DPGERJ.Recepcao.Data.DataSource;
using DPGERJ.Recepcao.Data.DataSource.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace DPGERJ.Recepcao.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_EndRequest()
        {
            var ctxManager = ServiceLocator.Current.GetInstance<IContextManager<RecepcaoContext>>()
                as ContextManager<RecepcaoContext>;

            ctxManager?.GetContext().Dispose();
        }
    }
}
