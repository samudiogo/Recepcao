using DPGERJ.Recepcao.Data.DataSource;
using DPGERJ.Recepcao.Data.DataSource.Interfaces;

namespace DPGERJ.Recepcao.Application.Interfaces
{
    public interface ITransactionAppService<TContext>
        where TContext: IDbContext, new ()
    {
        void BeginTransaction();
        void Commit();
    }
}