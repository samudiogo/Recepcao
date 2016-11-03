using DPGERJ.Recepcao.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DPGERJ.Recepcao.Data.Mapping
{
    public class AssistidoMap : EntityTypeConfiguration<Assistido>
    {
        public AssistidoMap()
        {
            HasKey(a => a.Id);

            Property(a => a.Nome)
                .HasMaxLength(50)
                .IsRequired();

            Property(a => a.Documento)
                .HasMaxLength(20)
                .IsRequired();

            Property(a => a.OrgaoEmissor)
                .HasMaxLength(20);

            Property(a => a.ImagemUrl)
                .HasMaxLength(50);
        }
    }
}
