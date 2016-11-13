using System.Collections.Generic;
using DPGERJ.Recepcao.Application.Interfaces;
using DPGERJ.Recepcao.Data.DataSource;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Service;

namespace DPGERJ.Recepcao.Application.Services
{
    public class VisitaAppService: AppServiceBase<RecepcaoContext>, IVisitaAppService
    {
        private readonly IVisitaService _service;

        public VisitaAppService(IVisitaService visitaService)
        {
            _service = visitaService;
        }

        #region Implementation of IWriteOnlyAppService<in Visita>

        public void Create(Visita vista) => _service.Add(vista);

        public void Update(Visita vista) => _service.Update(vista);

        public void Remove(Visita vista) => _service.Remove(vista);

        #endregion

        #region Implementation of IDisposable

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
        }

        #endregion

        #region Implementation of IAppServiceBase<Visita>

        public Visita GetById(int id) => _service.GetById(id);

        public IEnumerable<Visita> GetAll() => _service.GetAll();

        #endregion
    }
}