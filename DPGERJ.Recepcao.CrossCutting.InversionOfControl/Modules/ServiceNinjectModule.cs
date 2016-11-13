
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
            Bind<IDestinoService>().To<DestinoService>();
            Bind<IAssistidoService>().To<AssitidoService>();
            Bind<IVisitaService>().To<VisitaService>();
        }

        #endregion
    }
}