using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LolaApp.WebUI.Models
{
    public class LoginViewModel : ModelBase
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