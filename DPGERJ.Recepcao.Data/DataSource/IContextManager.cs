namespace DPGERJ.Recepcao.Data.DataSource
{
    public interface IContextManager<TContext> where TContext : IDbContext, new()
    {
        IDbContext GetContext();
        void Finish();
    }
}