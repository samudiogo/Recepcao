using DPGERJ.Recepcao.Application.Interfaces;
using DPGERJ.Recepcao.Data.DataSource.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace DPGERJ.Recepcao.Application.Services
{
    public class AppServiceBase<TContext> : ITransactionAppService<TContext> where TContext : IDbContext, new ()
    {
        private IUnitOfWork<TContext> _unitOfWork;

        
        public void BeginTransaction()
        {
            _unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork<TContext>>();
            _unitOfWork.BeginTransaction();
        }

        public void Commit()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
