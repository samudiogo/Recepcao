using DPGERJ.Recepcao.Application.Interfaces;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Service;

namespace DPGERJ.Recepcao.Application.Services
{
    public class VisitaAppService : AppServiceBase<Visita>, IVisitaAppService
    {
        public VisitaAppService(IServiceBase<Visita> service) : base(service)
        {
        }
    }
}
