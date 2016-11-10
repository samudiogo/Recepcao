using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Repository;
using DPGERJ.Recepcao.Domain.Interfaces.Service;

namespace DPGERJ.Recepcao.Domain.Services
{
    public class AssitidoService : ServiceBase<Assistido>, IAssistidoService
    {
        public AssitidoService(IRepositoryBase<Assistido> repository) : base(repository)
        {
        }
    }
}