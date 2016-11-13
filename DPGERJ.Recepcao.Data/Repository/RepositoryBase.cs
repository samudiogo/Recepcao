using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DPGERJ.Recepcao.Data.DataSource;
using DPGERJ.Recepcao.Data.DataSource.Interfaces;
using DPGERJ.Recepcao.Domain.Interfaces.Repository;
using Microsoft.Practices.ServiceLocation;

namespace DPGERJ.Recepcao.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IDisposable where TEntity : class
    {

        private readonly IDbContext _dbContext;
        private readonly IDbSet<TEntity> _dbSet;
        public RepositoryBase()
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager<RecepcaoContext>>()
                as ContextManager<RecepcaoContext>;

            _dbContext = contextManager?.GetContext();
            _dbSet = _dbContext?.Set<TEntity>();
        }

        protected IDbContext Context => _dbContext;
        protected IDbSet<TEntity> DbSet => _dbSet;

        /// <summary>
        /// Adiciona a entidade no repositório
        /// </summary>
        /// <param name="entity">entidade</param>
        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
        }


        /// <summary>
        /// Atualiza a entidade no repositório
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            Context.SaveChanges();
        }

        /// <summary>
        /// Deleta a entidade no repositório
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            Context.SaveChanges();
        }

        /// <summary>
        /// Retorna uma instancia da entidade no repositório, caso não tenha, retorna null
        /// </summary>
        /// <param name="id">identificador unico da entidade</param>
        /// <returns>instancia da entidade ou nulo</returns>
        public TEntity GetById(int id) => DbSet.Find(id);

        /// <summary>
        /// Retorna todos os registros da entidade no repositório
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll() => DbSet.ToList();

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            Context?.Dispose();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => DbSet.Where(predicate);
    }
}