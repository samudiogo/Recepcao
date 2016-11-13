using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DPGERJ.Recepcao.Domain.Entities;

namespace DPGERJ.Recepcao.Data.DataSource.Config
{
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<RecepcaoContext>
    {
        /// <summary>
        /// A method that should be overridden to actually add data to the context for seeding.
        /// The default implementation does nothing.
        /// TODO Fazer seed das entidades padrões
        /// </summary>
        /// <param name="context"> The context to seed. </param>
        protected override void Seed(RecepcaoContext context)
        {
            var visitantePadrao = new Assistido
            {
                Documento = "980701947",
                ImagemUrl = "imagem-padrao.png",
                Nome = "Visitante Padrão",
                OrgaoEmissor = "DETRAN RJ"
            };

            var destinos = new List<Destino>
            {
                new Destino {Andar = "1º andar", Nome = "Protocolo"},
                new Destino {Andar = "2º andar", Nome = "Gabinete"},
                new Destino {Andar = "3º andar", Nome = "Biblioteca"}
            };

            new List<Visita>
            {
                new Visita {
                    Assistido = visitantePadrao,
                    Destino = destinos.Single(d=> d.Nome.Equals("Protocolo")),
                    DataCadastro = DateTime.Now,
                    PessoaMotivo = "wolwerine"
                },
                new Visita {
                    Assistido = visitantePadrao,
                    Destino = destinos.Single(d=> d.Nome.Equals("Gabinete")),
                    DataCadastro = DateTime.Now,
                    PessoaMotivo = "andré"
                },
                new Visita {
                    Assistido = visitantePadrao,
                    Destino = destinos.Single(d=> d.Nome.Equals("Biblioteca")),
                    DataCadastro = DateTime.Now,
                    PessoaMotivo = "seu pedro"
                }

            }.ForEach(visita => context.Visita.Add(visita));

            context.SaveChanges();


        }
    }
}