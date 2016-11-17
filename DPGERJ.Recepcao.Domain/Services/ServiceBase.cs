using System.Collections.Generic;
using DPGERJ.Recepcao.Domain.Interfaces.Repository;
using DPGERJ.Recepcao.Domain.Interfaces.Repository.ReadOnly;
using DPGERJ.Recepcao.Domain.Interfaces.Service;

namespace DPGERJ.Recepcao.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {

        #region contrutor

        private IRepositoryBase<TEntity> _repository;
        private IRepositoryReadOnlyBase<TEntity> _repositoryReadOnlyBase;

        public ServiceBase(IRepositoryBase<TEntity> repository, IRepositoryReadOnlyBase<TEntity> repositoryReadOnly)
        {
            _repository = repository;
            _repositoryReadOnlyBase = repositoryReadOnly;
        }
        #endregion

        protected IRepositoryBase<TEntity> Repository => _repository;
        protected IRepositoryReadOnlyBase<TEntity> ReadOnlyRepository => _repositoryReadOnlyBase;


        /// <summary>
        ///  retorna o objeto que tenha um id idêntico ao mencionado pelo usuário
        /// </summary>
        /// <param name="id">id chave que identifica a entidade</param>
        /// <returns></returns>
        public TEntity GetById(int id) => _repository.GetById(id);

        public IEnumerable<TEntity> GetAll() => _repository.GetAll();

        public void Add(TEntity entity) => _repository.Add(entity);

        public void Update(TEntity entity) => _repository.Update(entity);

        public void Remove(TEntity entity) => _repository.Delete(entity);
    }
}