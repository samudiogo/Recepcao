using System.Collections.Generic;

namespace DPGERJ.Recepcao.Domain.Entities
{
    public class Destino
    {
        public int DestinoId { get; set; }
        public string Nome { get; set; }
        public string Andar { get; set; }

        public virtual ICollection<Visita> Visitas { get; set; }
    }
}