using DPGERJ.Recepcao.Domain.Entities;

namespace DPGERJ.Recepcao.Domain.Interfaces.Service
{
    public interface IAssistidoService : IServiceBase<Assistido>
    {
        Assistido GetByDocument(string document);
    }
}
