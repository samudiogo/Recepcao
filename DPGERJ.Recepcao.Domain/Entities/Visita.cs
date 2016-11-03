using System;

namespace DPGERJ.Recepcao.Domain.Entities
{
    public class Visita
    {
        public int Id { get; set; }
        public string PessoaMotivo { get; set; }
        public DateTime DataCadastro { get; set; }

        public int IdAssistido { get; set; }
        public int IdDestino { get; set; }

        public virtual Assistido Assistido { get; set; }
        public virtual Destino Destino { get; set; }
    }
}
