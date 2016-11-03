using DPGERJ.Recepcao.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DPGERJ.Recepcao.Data.Mapping
{
    public class VisitaMap : EntityTypeConfiguration<Visita>
    {
        public VisitaMap()
        {
            HasKey(v => v.Id);

            Property(v => v.PessoaMotivo)
                .HasMaxLength(50)
                .IsRequired();

            Property(v => v.DataCadastro)
                .IsRequired();

            HasRequired(v => v.Assistido)
                .WithRequiredPrincipal(v => v.Visita);

            HasRequired(v => v.Destino)
                .WithRequiredPrincipal(v => v.Visita);
        }
    }
}
