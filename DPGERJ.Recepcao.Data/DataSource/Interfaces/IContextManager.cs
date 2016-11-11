namespace DPGERJ.Recepcao.Data.DataSource.Interfaces
{
    public interface IContextManager<TContext> where TContext : IDbContext, new()
    {
        IDbContext GetContext();
        void Finish();
    }
}