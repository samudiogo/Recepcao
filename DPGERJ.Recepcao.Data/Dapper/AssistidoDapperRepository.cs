using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dapper;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Repository.ReadOnly;

namespace DPGERJ.Recepcao.Data.Dapper
{
    public class AssistidoDapperRepository : RepositoryBase, IAssistidoReadOnlyRepository
    {
        #region Implementation of IRepositoryReadOnlyBase<Assistido>

        public Assistido Get(int id)
        {
            return null;
        }

        public IEnumerable<Assistido> All()
        {
            yield break;
        }

        public IEnumerable<Assistido> Find(Expression<Func<Assistido, bool>> predicate)
        {
            yield break;
        }

        /// <summary>
        /// Lista os vistantes mais recentes limitando pelo top
        /// </summary>
        /// <param name="top">número máximo de de registros</param>
        /// <returns></returns>
        public IEnumerable<Assistido> ListaTopAssistidosRecentes(int top = 200)
        {

            using (var cn = RecepcaoConnection)
            {
                var vistas = cn.Query<Assistido>($"SELECT TOP({top}) * FROM Assistido order by id desc");

                return vistas;
            }
        }

        public IEnumerable<Assistido> ListAssistidosPorNome(string nome)
        {
            using (var cn = RecepcaoConnection)
            {
                var vistas = cn.Query<Assistido>($"SELECT * FROM Assistido WHERE nome like '%{nome.Trim()}%'order by Nome");

                return vistas;
            }
        }

        #endregion
    }
}