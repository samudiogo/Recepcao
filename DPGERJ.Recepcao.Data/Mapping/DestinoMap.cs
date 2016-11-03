using DPGERJ.Recepcao.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DPGERJ.Recepcao.Data.Mapping
{
    public class DestinoMap : EntityTypeConfiguration<Destino>
    {
        public DestinoMap()
        {
            HasKey(d => d.Id);

            Property(d => d.Nome)
                .HasMaxLength(30)
                .IsRequired();

            Property(d => d.Andar)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
