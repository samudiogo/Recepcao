using System;
using DPGERJ.Recepcao.Data.DataSource.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace DPGERJ.Recepcao.Data.DataSource
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable where TContext : IDbContext, new()
    {

        private readonly ContextManager<TContext> _contextManager =
            ServiceLocator.Current.GetInstance<IContextManager<TContext>>()
                as ContextManager<TContext>;

        private readonly IDbContext _dbContext;
        private bool _disposed;

        public UnitOfWork()
        {
            _dbContext = _contextManager.GetContext();
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _dbContext.Dispose();

            _disposed = true;
        }
    }
}