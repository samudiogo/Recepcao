using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DPGERJ.Recepcao.Domain.Interfaces.Repository.ReadOnly
{
    public interface IRepositoryReadOnlyBase<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}