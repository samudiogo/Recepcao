using DPGERJ.Recepcao.Data.Repository;
using DPGERJ.Recepcao.Domain.Interfaces.Repository;
using Ninject.Modules;

namespace DPGERJ.Recepcao.CrossCutting.InversionOfControl.Modules
{
    public class RepositoryNinjectModule:NinjectModule
    {
        #region Overrides of NinjectModule

        public override void Load()
        {
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));

            Bind<IDestinoRepository>().To<IDestinoRepository>();
            Bind<IAssistidoRepository>().To<AssistidoRepository>();
            Bind<IVisitaRepository>().To<VisitaRepository>();
            
        }

        #endregion
    }
}