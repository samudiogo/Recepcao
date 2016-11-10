using System.Data.Entity;

namespace DPGERJ.Recepcao.Data.DataSource.Config
{
    public class BaseDbContext : DbContext, IDbContext
    {
        public BaseDbContext(string connStringName) : base(connStringName)
        {

        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class => base.Set<TEntity>();

    }
}