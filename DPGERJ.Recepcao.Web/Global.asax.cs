using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DPGERJ.Recepcao.Data.DataSource;
using DPGERJ.Recepcao.Data.DataSource.Interfaces;
using DPGERJ.Recepcao.Web.AutoMapper;
using Microsoft.Practices.ServiceLocation;

namespace DPGERJ.Recepcao.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMappings();
            DataTables.AspNet.Mvc5.Configuration.RegisterDataTables();
        }

        protected void Application_EndRequest()
        {
            var ctxManager = ServiceLocator.Current.GetInstance<IContextManager<RecepcaoContext>>()
                as ContextManager<RecepcaoContext>;

            ctxManager?.GetContext().Dispose();
        }
    }
}
