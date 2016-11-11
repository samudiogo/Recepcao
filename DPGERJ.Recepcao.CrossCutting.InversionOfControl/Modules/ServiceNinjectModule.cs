using DPGERJ.Recepcao.Application.Interfaces;
using DPGERJ.Recepcao.Application.Services;
using DPGERJ.Recepcao.Domain.Interfaces.Service;
using DPGERJ.Recepcao.Domain.Services;
using Ninject.Modules;


namespace DPGERJ.Recepcao.CrossCutting.InversionOfControl.Modules
{
    public class ServiceNinjectModule : NinjectModule
    {
        #region Overrides of NinjectModule

        public override void Load()
        {
            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<IDestinoAppService>().To<IDestinoAppService>();
        }

        #endregion
    }
}