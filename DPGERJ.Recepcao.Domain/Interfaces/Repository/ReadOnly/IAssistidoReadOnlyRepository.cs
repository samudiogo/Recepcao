using System;
using System.Collections.Generic;
using DPGERJ.Recepcao.Domain.Entities;

namespace DPGERJ.Recepcao.Domain.Interfaces.Repository.ReadOnly
{
    public interface IAssistidoReadOnlyRepository : IRepositoryReadOnlyBase<Assistido>
    {
        /// <summary>
        /// Lista os vistantes mais recentes limitando pelo top
        /// </summary>
        /// <param name="top">número máximo de de registros</param>
        /// <returns></returns>
        IEnumerable<Assistido> ListaTopAssistidosRecentes(int top = 200);

        IEnumerable<Assistido> ListAssistidosPorNome(string nome);
    }
}