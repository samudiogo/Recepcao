using DPGERJ.Recepcao.Domain.Entities;

namespace DPGERJ.Recepcao.Application.Interfaces
{
    public interface IAssistidoAppService : IAppServiceBase<Assistido>
    {
        Assistido GetByDocument(string document);
    }
}
