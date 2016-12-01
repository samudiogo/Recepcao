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

        public int AssistidoId { get; set; }
        public int DestinoId { get; set; }

        public virtual AssistidoViewModel Assistido { get; set; }
        public virtual DestinoViewModel Destino { get; set; }
    }
}