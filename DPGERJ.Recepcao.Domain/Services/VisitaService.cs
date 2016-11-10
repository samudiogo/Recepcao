using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Repository;
using DPGERJ.Recepcao.Domain.Interfaces.Service;

namespace DPGERJ.Recepcao.Domain.Services
{
    public class VisitaService:ServiceBase<Visita>, IVisitaService
    {
        public VisitaService(IRepositoryBase<Visita> repository) : base(repository)
        {
        }
    }
}