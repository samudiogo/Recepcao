using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Repository.ReadOnly;

namespace DPGERJ.Recepcao.Data.Dapper
{
    public class DestinoDapperRepository:RepositoryBase, IDestinoReadOnlyRepository
    {
        #region Implementation of IRepositoryReadOnlyBase<Destino>

        public Destino Get(int id)
        {
            return null;
        }

        public IEnumerable<Destino> All()
        {
            yield break;
        }

        public IEnumerable<Destino> Find(Expression<Func<Destino, bool>> predicate)
        {
            yield break;
        }

        #endregion
    }
}