using System;
using System.Collections.Generic;
using DPGERJ.Recepcao.Application.Interfaces;
using DPGERJ.Recepcao.Data.DataSource;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Service;


namespace DPGERJ.Recepcao.Application.Services
{
    public class AssistidoAppService : AppServiceBase<RecepcaoContext>, IAssistidoAppService
    {

        private readonly IAssistidoService _service;

        public AssistidoAppService(IAssistidoService assistidoService)
        {
            _service = assistidoService;
        }

        #region Implementation of IWriteOnlyAppService<in Assistido>

        public void Create(Assistido assitido) => _service.Add(assitido);

        public void Update(Assistido assitido) => _service.Update(assitido);

        public void Remove(Assistido assitido) => _service.Remove(assitido);

        #endregion


        #region Implementation of IAppServiceBase<Assistido>

        public Assistido GetById(int id) => _service.GetById(id);

        public IEnumerable<Assistido> GetAll() => _service.GetAll();

        public Assistido GetByDocument(string document) => _service.GetByDocument(document);

        #endregion


        #region Implementation of IDisposable

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose() => GC.SuppressFinalize(this);
        #endregion
    }
}
