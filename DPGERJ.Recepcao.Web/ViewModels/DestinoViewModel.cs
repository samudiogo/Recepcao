using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DPGERJ.Recepcao.Domain.Entities;

namespace DPGERJ.Recepcao.Web.ViewModels
{
    public class DestinoViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(30, ErrorMessage = "Máximo {0} caracteres.")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Andar")]
        public string Andar { get; set; }

        public virtual VisitaViewModel Visita { get; set; }
    }
}