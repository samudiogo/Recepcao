using System;

namespace DPGERJ.Recepcao.Domain.Entities
{
    public class Visita
    {
        public int Id { get; set; }
        public string PessoaMotivo { get; set; }
        public DateTime DataCadastro { get; set; }
        public Assistido Assistido { get; set; }
        public Destino Destino { get; set; }
    }
}
