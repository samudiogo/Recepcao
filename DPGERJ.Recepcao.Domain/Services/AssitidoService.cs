using System;
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

        public Assistido GetByDocument(string document) => Repository.Find(a => a.Documento.ToUpper().Equals(document.ToUpper())).FirstOrDefault();
    }
}