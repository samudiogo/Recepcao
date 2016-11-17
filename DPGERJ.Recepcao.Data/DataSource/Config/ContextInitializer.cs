using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using DPGERJ.Recepcao.Domain.Entities;

namespace DPGERJ.Recepcao.Data.DataSource.Config
{
    public partial class ContextInitializer : DropCreateDatabaseIfModelChanges<RecepcaoContext>
    {

        private Destino DestinoPadrao => new Destino { Andar = "1º andar", Nome = "Recepção" };

        /// <summary>
        /// A method that should be overridden to actually add data to the context for seeding.
        /// The default implementation does nothing.
        /// TODO Fazer seed das entidades padrões
        /// </summary>
        /// <param name="context"> The context to seed. </param>
        protected override void Seed(RecepcaoContext context)
        {

            //Visitas.ForEach(visita => context.Visita.Add(visita));

           // context.SaveChanges();


        }
    }
}