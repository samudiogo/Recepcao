using DPGERJ.Recepcao.Application.Interfaces;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Service;

namespace DPGERJ.Recepcao.Application.Services
{
    public class AssistidoAppService : AppServiceBase<Assistido>, IAssistidoAppService
    {
        public AssistidoAppService(IServiceBase<Assistido> service) : base(service)
        {
        }
    }
}
