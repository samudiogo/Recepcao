using System;
using System.Collections.Generic;
using DPGERJ.Recepcao.Domain.Entities;

namespace DPGERJ.Recepcao.Application.Interfaces
{
    public interface IVisitaAppService : IAppServiceBase<Visita>
    {
        IEnumerable<Visita> VisitasDoDia(DateTime? dia);
    }
}
