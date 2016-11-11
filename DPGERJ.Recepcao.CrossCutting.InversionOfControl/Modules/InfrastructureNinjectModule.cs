using DPGERJ.Recepcao.Data.DataSource;
using DPGERJ.Recepcao.Data.DataSource.Interfaces;
using Ninject.Modules;

namespace DPGERJ.Recepcao.CrossCutting.InversionOfControl.Modules
{
    public class InfrastructureNinjectModule : NinjectModule
    {
        #region Overrides of NinjectModule

        public override void Load()
        {
            Bind<IDbContext>().To<RecepcaoContext>();

            Bind(typeof(IContextManager<>)).To(typeof(ContextManager<>));
            Bind(typeof(IUnitOfWork<>)).To((typeof(UnitOfWork<>)));
        }

        #endregion
    }
}