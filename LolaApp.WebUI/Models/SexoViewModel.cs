using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LolaApp.WebUI.Models
{
    public class SexoViewModel : ModelBase
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name ="Descripción")]// Data Annotation
        public string Denominacion { get; set; }
    }
}