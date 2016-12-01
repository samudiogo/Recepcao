using System;
using System.Collections.Generic;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Repository;
using DPGERJ.Recepcao.Domain.Interfaces.Service;
using System.Linq;
using DPGERJ.Recepcao.Domain.Interfaces.Repository.ReadOnly;

namespace DPGERJ.Recepcao.Domain.Services
{
    public class AssitidoService : ServiceBase<Assistido>, IAssistidoService
    {

        public AssitidoService(IAssistidoRepository repository, IAssistidoReadOnlyRepository readOnlyRepository) : base(repository, readOnlyRepository)
        {

        }

        public new void Add(Assistido assistido)
        {

            Repository.Add(Normaliza(assistido));
        }

        public new void Update(Assistido assistido)
        {
            Repository.Update(Normaliza(assistido));
        }


        private static Assistido Normaliza(Assistido assistido)
        {
            assistido.Nome = assistido.Nome?.ToUpper();
            assistido.Documento = assistido.Documento?.ToUpper();
            assistido.OrgaoEmissor = assistido.OrgaoEmissor?.ToUpper();

            return assistido;
        }
        public Assistido GetByDocument(string document) => Repository.Find(a => a.Documento.ToUpper().Equals(document.ToUpper())).FirstOrDefault();

        /// <summary>
        /// Lista os vistantes mais recentes limitando pelo top
        /// </summary>
        /// <param name="top">número máximo de de registros</param>
        /// <returns></returns>
        public IEnumerable<Assistido> ListaTopAssistidosRecentes(int top = 200)
        {
            var repositoryAssistidoReadOnly = (IAssistidoReadOnlyRepository)ReadOnlyRepository;
            return repositoryAssistidoReadOnly.ListaTopAssistidosRecentes(top);

        }
    }
}