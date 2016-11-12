using System;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Repository;
using System.Linq;

namespace DPGERJ.Recepcao.Data.Repository
{
    public class AssistidoRepository : RepositoryBase<Assistido>, IAssistidoRepository
    {
        public Assistido GetByDocument(string document)
        {
            return DbSet.FirstOrDefault(assistido => assistido.Documento.ToUpper().Equals(document.ToUpper()));
        }
    }
}