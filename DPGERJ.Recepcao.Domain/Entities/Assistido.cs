namespace DPGERJ.Recepcao.Domain.Entities
{
    public class Assistido
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string OrgaoEmissor { get; set; }
        public string ImagemUrl { get; set; }

        public virtual Visita Visita { get; set; }
    }
}
