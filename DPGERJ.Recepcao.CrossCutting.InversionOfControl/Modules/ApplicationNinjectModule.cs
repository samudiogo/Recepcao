using DPGERJ.Recepcao.Application.Interfaces;
using DPGERJ.Recepcao.Application.Services;
using Ninject.Modules;

namespace DPGERJ.Recepcao.CrossCutting.InversionOfControl.Modules
{
    public class ApplicationNinjectModule:NinjectModule
    {
        #region Overrides of NinjectModule

        /// <summary>Loads the module into the kernel.</summary>
        public override void Load()
        {
            Bind<IDestinoAppService>().To<DestinoAppService>();
            Bind<IAssistidoAppService>().To<AssistidoAppService>();
            Bind<IVisitaAppService>().To<VisitaAppService>();
        }

        #endregion
    }
}