using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Repository;
using DPGERJ.Recepcao.Domain.Interfaces.Service;

namespace DPGERJ.Recepcao.Domain.Services
{
    public class DestinoService : ServiceBase<Destino>, IDestinoService
    {
        public DestinoService(IRepositoryBase<Destino> repository) : base(repository)
        {
        }
    }
}