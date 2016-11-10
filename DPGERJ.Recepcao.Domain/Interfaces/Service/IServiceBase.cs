using System.Collections.Generic;

namespace DPGERJ.Recepcao.Domain.Interfaces.Service
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        /// <summary>
        ///  retorna o objeto que tenha um id idêntico ao mencionado pelo usuário
        /// </summary>
        /// <param name="id">id chave que identifica a entidade</param>
        /// <returns></returns>
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}