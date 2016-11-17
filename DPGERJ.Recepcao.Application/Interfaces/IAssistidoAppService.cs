using System.Collections.Generic;
using DPGERJ.Recepcao.Domain.Entities;

namespace DPGERJ.Recepcao.Application.Interfaces
{
    public interface IAssistidoAppService : IAppServiceBase<Assistido>
    {
        Assistido GetByDocument(string document);

        /// <summary>
        /// Lista os vistantes mais recentes limitando pelo top
        /// </summary>
        /// <param name="top">número máximo de de registros</param>
        /// <returns></returns>
        IEnumerable<Assistido> ListaTopAssistidosRecentes(int top = 200);
    }
}
