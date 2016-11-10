using System.Collections.Generic;

namespace DPGERJ.Recepcao.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adiciona a entidade no repositório
        /// </summary>
        /// <param name="entity">entidade</param>
        void Add(TEntity entity);
        /// <summary>
        /// Atualiza a entidade no repositório
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);
        /// <summary>
        /// Deleta a entidade no repositório
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);
        /// <summary>
        /// Retorna uma instancia da entidade no repositório, caso não tenha, retorna null
        /// </summary>
        /// <param name="id">identificador unico da entidade</param>
        /// <returns>instancia da entidade ou nulo</returns>
        TEntity GetById(int id);
        /// <summary>
        /// Retorna todos os registros da entidade no repositório
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();
    }
}