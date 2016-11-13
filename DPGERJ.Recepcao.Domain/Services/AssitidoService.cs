using System;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Repository;
using DPGERJ.Recepcao.Domain.Interfaces.Service;
using System.Linq;

namespace DPGERJ.Recepcao.Domain.Services
{
    public class AssitidoService : ServiceBase<Assistido>, IAssistidoService
    {

        public AssitidoService(IAssistidoRepository repository) : base(repository)
        {
        }

        public Assistido GetByDocument(string document) => Repository.Find(a => a.Documento.ToUpper().Equals(document.ToUpper())).Single();
    }
}