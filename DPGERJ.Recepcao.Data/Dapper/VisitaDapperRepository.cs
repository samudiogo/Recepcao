using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using DapperExtensions;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Domain.Interfaces.Repository.ReadOnly;

namespace DPGERJ.Recepcao.Data.Dapper
{
    public class VisitaDapperRepository : RepositoryBase, IVisitaReadOnlyRepository
    {
        #region Implementation of IRepositoryReadOnlyBase<Visita>

        private const string DefaultQuery = "SELECT * FROM Visita vis " +
                                            "JOIN Assistido ass on ass.Id = vis.AssistidoId " +
                                            "JOIN Destino   des on des.DestinoId = vis.DestinoId ";
        public Visita Get(int id)
        {
            using (var cn = RecepcaoConnection)
            {
                var vista = cn.Query<Visita, Assistido, Destino, Visita>($"{DefaultQuery} where vis.AssistidoId = @AssistidoId",
                    (vis, ass, des) =>
                    {
                        vis.Assistido = ass; vis.Destino = des;
                        return vis;
                    },
                    new { AsssitidoId = id }, splitOn: "Id,AssistidoId, DestinoId").FirstOrDefault();

                return vista;
            }
        }

        public IEnumerable<Visita> All()
        {
            using (var cn = RecepcaoConnection)
            {
                var visitas = cn.Query<Visita, Assistido, Destino, Visita>($"{DefaultQuery}",
                    (vis, ass, des) =>
                    {
                        vis.Assistido = ass;
                        vis.Destino = des;
                        return vis;
                    }, splitOn: "Id,AssistidoId, DestinoId");
                return visitas;
            }
        }


        public IEnumerable<Visita> Find(Expression<Func<Visita, bool>> predicate)
        {
            using (var cn = RecepcaoConnection)
            {
                var vistas = cn.GetList<Visita>(predicate);
                return vistas;
            }
        }

        public IEnumerable<Visita> VisitasDoDia(DateTime dia)
        {
            using (var cn = RecepcaoConnection)
            {
                var vistas = cn.Query<Visita, Assistido, Destino, Visita>($"{DefaultQuery} where CONVERT(DATE, vis.DataCadastro, 112) = @DataCadastro",
                    (vis, ass, des) =>
                    {
                        vis.Assistido = ass; vis.Destino = des;
                        return vis;
                    },
                    new { DataCadastro = dia.Date }, splitOn: "Id,AssistidoId, DestinoId");
                return vistas;
            }
        }

        #endregion
    }
}