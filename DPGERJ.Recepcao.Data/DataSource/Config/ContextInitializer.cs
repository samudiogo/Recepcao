using System.Collections.Generic;
using System.Data.Entity;
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
            new List<Destino>
            {
                new Destino {Andar = "1º andar",Nome = "Protocolo"},
                new Destino {Andar = "2º andar",Nome = "Gabinete"},
                new Destino {Andar = "3º andar",Nome = "Biblioteca"}
            }.ForEach(destino => context.Destino.Add(destino));
            context.SaveChanges();
        }
    }
}