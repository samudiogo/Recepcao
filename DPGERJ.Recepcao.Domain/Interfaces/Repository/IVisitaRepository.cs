using System.Collections.Generic;
using DPGERJ.Recepcao.Domain.Entities;

namespace DPGERJ.Recepcao.Domain.Interfaces.Repository
{
    public interface IVisitaRepository : IRepositoryBase<Visita>
    {
        IEnumerable<Visita> ListaPorDestinoId(int destinoId);
    }
}