namespace DPGERJ.Recepcao.Domain.Entities
{
    public class Destino
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Andar { get; set; }

        public virtual Visita Visita { get; set; }
    }
}