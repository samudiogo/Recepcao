using System.ComponentModel.DataAnnotations;

namespace DPGERJ.Recepcao.Web.ViewModels
{
    public class AssistidoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres.")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Preencha o campo")]
        public string OrgaoEmissor { get; set; }


        public string ImagemUrl { get; set; }

        public virtual VisitaViewModel Visita { get; set; }
    }
}