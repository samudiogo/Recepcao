using DPGERJ.Recepcao.Application.Interfaces;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Service;

namespace DPGERJ.Recepcao.Application.Services
{
    public class DestinoAppService : AppServiceBase<Destino>, IDestinoAppService
    {
        public DestinoAppService(IServiceBase<Destino> service) : base(service)
        {
        }
    }
}
