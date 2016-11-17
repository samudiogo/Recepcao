using System;
using System.Collections.Generic;
using DPGERJ.Recepcao.Domain.Entities;

namespace DPGERJ.Recepcao.Domain.Interfaces.Repository.ReadOnly
{
    public interface IVisitaReadOnlyRepository : IRepositoryReadOnlyBase<Visita>
    {
        IEnumerable<Visita> VisitasDoDia(DateTime dia);
    }
}