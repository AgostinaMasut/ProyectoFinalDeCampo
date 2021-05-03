using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LolaApp.WebUI.Models
{
    public class RecuperarContraseñaViewModel : ModelBase
    {
        [Required]
        [MaxLength(8)]
        [Display(Name = "Usuario")]// Data Annotation
        public int Dni { get; set; }

        [Required]
        [MaxLength(10)]
        public int Contraseña { get; set; }
    }
}