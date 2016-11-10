using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DPGERJ.Recepcao.Data.DataSource
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
        void Dispose();
    }
}