using System;
using System.Collections.Generic;

namespace DPGERJ.Recepcao.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> : IWriteOnlyAppService<TEntity>, IDisposable where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
