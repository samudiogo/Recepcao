using System.Data.Entity;
using System.Configuration;
using DPGERJ.Recepcao.Data.DataSource.Config;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Data.Mapping;

namespace DPGERJ.Recepcao.Data.DataSource
{
    public class RecepcaoContext : BaseDbContext
    {
        public DbSet<Assistido> Assistido { get; set; }
        public DbSet<Destino> Destino { get; set; }
        public DbSet<Visita> visita { get; set; }

        static RecepcaoContext()
        {
            Database.SetInitializer(new ContextInitializer());
        }

        public RecepcaoContext()
            : base(ConfigurationManager.ConnectionStrings[""].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AssistidoMap());
            modelBuilder.Configurations.Add(new DestinoMap());
            modelBuilder.Configurations.Add(new VisitaMap());
        }
    }
}
