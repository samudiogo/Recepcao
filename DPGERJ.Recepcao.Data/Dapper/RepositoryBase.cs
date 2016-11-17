using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DPGERJ.Recepcao.Data.Dapper
{
    public class RepositoryBase : IDisposable
    {
        public IDbConnection RecepcaoConnection => new SqlConnection(ConfigurationManager.ConnectionStrings["RecepcaoContext"].ConnectionString);

        #region Implementation of IDisposable

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}