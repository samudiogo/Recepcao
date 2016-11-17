using System;
using System.Collections.Generic;
using DPGERJ.Recepcao.Domain.Entities;

namespace DPGERJ.Recepcao.Domain.Interfaces.Service
{
    public interface IVisitaService : IServiceBase<Visita>
    {
        IEnumerable<Visita> VistasPorDia(DateTime dia);
    }
}
