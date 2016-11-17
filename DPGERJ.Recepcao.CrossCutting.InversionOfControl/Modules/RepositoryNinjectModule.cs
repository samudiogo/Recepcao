using DPGERJ.Recepcao.Data.Dapper;
using DPGERJ.Recepcao.Data.Repository;
using DPGERJ.Recepcao.Domain.Interfaces.Repository;
using DPGERJ.Recepcao.Domain.Interfaces.Repository.ReadOnly;
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
            Bind<IDestinoReadOnlyRepository>().To<DestinoDapperRepository>();

            Bind<IAssistidoRepository>().To<AssistidoRepository>();
            Bind<IAssistidoReadOnlyRepository>().To<AssistidoDapperRepository>();

            Bind<IVisitaRepository>().To<VisitaRepository>();
            Bind<IVisitaReadOnlyRepository>().To<VisitaDapperRepository>();

        }

        #endregion
    }
}