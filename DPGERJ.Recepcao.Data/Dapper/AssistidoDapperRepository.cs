using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Repository.ReadOnly;

namespace DPGERJ.Recepcao.Data.Dapper
{
    public class AssistidoDapperRepository:RepositoryBase, IAssistidoReadOnlyRepository
    {
        #region Implementation of IRepositoryReadOnlyBase<Assistido>

        public Assistido Get(int id)
        {
            return null;
        }

        public IEnumerable<Assistido> All()
        {
            yield break;
        }

        public IEnumerable<Assistido> Find(Expression<Func<Assistido, bool>> predicate)
        {
            yield break;
        }

        #endregion
    }
}