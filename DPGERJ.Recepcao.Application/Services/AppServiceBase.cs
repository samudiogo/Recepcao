using System.Collections.Generic;
using DPGERJ.Recepcao.Application.Interfaces;
using DPGERJ.Recepcao.Domain.Interfaces.Service;

namespace DPGERJ.Recepcao.Application.Services
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {
        protected IServiceBase<TEntity> Service { get; }

        public AppServiceBase(IServiceBase<TEntity> service)
        {
            Service = service;
        }

        public void Add(TEntity entity) => Service.Add(entity);

        public IEnumerable<TEntity> GetAll() => Service.GetAll();

        public TEntity GetById(int id) => Service.GetById(id);

        public void Remove(TEntity entity) => Service.Remove(entity);

        public void Update(TEntity entity) => Service.Update(entity);
    }
}
