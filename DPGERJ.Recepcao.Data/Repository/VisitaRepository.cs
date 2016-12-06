using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Repository;

namespace DPGERJ.Recepcao.Data.Repository
{
    public class VisitaRepository : RepositoryBase<Visita>, IVisitaRepository
    {
        public new IEnumerable<Visita> GetAll() => base.DbSet.Include(v => v.Assistido).Include(v => v.Destino).ToList();
    }
}