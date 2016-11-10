using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DPGERJ.Recepcao.Web.ViewModels
{
    public class VisitaViewModel
    {
        public int Id { get; set; }
        public string PessoaMotivo { get; set; }
        public DateTime DataCadastro { get; set; }

        public int IdAssistido { get; set; }
        public int IdDestino { get; set; }

        public virtual AssistidoViewModel Assistido { get; set; }
        public virtual DestinoViewModel Destino { get; set; }
    }
}