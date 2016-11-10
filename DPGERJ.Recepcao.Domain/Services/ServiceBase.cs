using System.Collections.Generic;
using DPGERJ.Recepcao.Domain.Interfaces.Repository;
using DPGERJ.Recepcao.Domain.Interfaces.Service;

namespace DPGERJ.Recepcao.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {

        #region contrutor

        protected IRepositoryBase<TEntity> Repository { get; }

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            Repository = repository;
        }
        #endregion
        
        /// <summary>
        ///  retorna o objeto que tenha um id idêntico ao mencionado pelo usuário
        /// </summary>
        /// <param name="id">id chave que identifica a entidade</param>
        /// <returns></returns>
        public TEntity GetById(int id) => Repository.GetById(id);

        public IEnumerable<TEntity> GetAll() => Repository.GetAll();

        public void Add(TEntity entity) => Repository.Add(entity);

        public void Update(TEntity entity) => Repository.Update(entity);

        public void Remove(TEntity entity) => Repository.Delete(entity);
    }
}