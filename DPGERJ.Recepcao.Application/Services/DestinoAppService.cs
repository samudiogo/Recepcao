using System;
using System.Collections.Generic;
using DPGERJ.Recepcao.Application.Interfaces;
using DPGERJ.Recepcao.Data.DataSource;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Service;

namespace DPGERJ.Recepcao.Application.Services
{
    public class DestinoAppService : AppServiceBase<RecepcaoContext>, IDestinoAppService
    {

        private readonly IDestinoService _service;

        public DestinoAppService(IDestinoService destinoService)
        {
            _service = destinoService;
        }

        public void Create(Destino destino)
        {
            BeginTransaction();
            _service.Add(destino);
            Commit();
        }

        public IEnumerable<Destino> GetAll() => _service.GetAll();

        public Destino GetById(int id) => _service.GetById(id);

        public void Remove(Destino destino) => _service.Remove(destino);

        public void Update(Destino destino) => _service.Update(destino);

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
