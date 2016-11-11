namespace DPGERJ.Recepcao.Application.Interfaces
{
    public interface IWriteOnlyAppService<in TEntity>
        where TEntity: class 
    {
        void Create(TEntity tEntity);
        void Update(TEntity tEntity);
        void Remove(TEntity tEntity);
    }
}