using System;
using System.ComponentModel.DataAnnotations;

namespace DPGERJ.Recepcao.Web.ViewModels
{
    public class VisitaViewModel
    {
        
        public int Id { get; set; }
        [Display(Name = "Pessoa/Motivo")]
        public string PessoaMotivo { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "Data entrada")]
        public DateTime DataCadastro { get; set; }

        public int IdAssistido { get; set; }
        public int IdDestino { get; set; }

        public virtual AssistidoViewModel Assistido { get; set; } = new AssistidoViewModel();
        public virtual DestinoViewModel Destino { get; set; } = new DestinoViewModel();
    }
}