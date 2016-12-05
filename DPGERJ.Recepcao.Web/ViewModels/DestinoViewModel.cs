using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DPGERJ.Recepcao.Web.ViewModels
{
    public class DestinoViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(30, ErrorMessage = "Máximo {0} caracteres.")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres.")]
        [Display(Name = "Destino")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Andar")]
        public string Andar { get; set; }

    }

    public class DestinoDetalhesViewModel : DestinoViewModel
    {
        public virtual IEnumerable<VisitaViewModel> Visitas { get; set; }// = new List<VisitaViewModel>();
    }
}