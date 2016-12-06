using System;
using System.Collections.Generic;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Repository;
using DPGERJ.Recepcao.Domain.Interfaces.Repository.ReadOnly;
using DPGERJ.Recepcao.Domain.Interfaces.Service;

namespace DPGERJ.Recepcao.Domain.Services
{
    public class VisitaService : ServiceBase<Visita>, IVisitaService
    {
        public VisitaService(IRepositoryBase<Visita> repository, IVisitaReadOnlyRepository readOnlyRepository) : base(repository, readOnlyRepository)
        {

        }

        IEnumerable<Visita> IServiceBase<Visita>.GetAll()
        {
            //TODO parametrizar com readonly
            var visitaRepository = (IVisitaReadOnlyRepository)ReadOnlyRepository;
            return visitaRepository.All();
        }


        #region Implementation of IVisitaService

        public IEnumerable<Visita> VistasPorDia(DateTime dia)
        {
            var visitaRepository = (IVisitaReadOnlyRepository)ReadOnlyRepository;
            return visitaRepository.VisitasDoDia(dia);
        }

        #endregion
    }
}