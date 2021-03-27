using LolaApp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolaApp.Entities
{
    public class Usuario : EntityBase
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string DNI { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public string Calle { get; set; }

        public int? Número { get; set; }

        public string Barrio { get; set; }

        public string CP { get; set; }

        public string Localidad { get; set; }

        public string Email { get; set; }

        public string Cel { get; set; }

        public string Contraseña { get; set; }

        public int IdSexo { get; set; }
        [ForeignKey("IdSexo")]
        public virtual Sexo Sexo { get; set; }

        public int IdTipoDeUsuario { get; set; }
        [ForeignKey("IdTipoDeUsuario")]
        public virtual TipoDeUsario TipoDeUsario { get; set; }

    }

}
