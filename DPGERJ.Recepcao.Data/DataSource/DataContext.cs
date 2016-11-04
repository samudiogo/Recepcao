using System.Data.Entity;
using System.Configuration;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Data.Mapping;

namespace DPGERJ.Recepcao.Data.DataSource
{
    public class DataContext : DbContext
    {
        public DbSet<Assistido> Assistido { get; set; }
        public DbSet<Destino> Destino { get; set; }
        public DbSet<Visita> visita { get; set; }

        public DataContext()
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
