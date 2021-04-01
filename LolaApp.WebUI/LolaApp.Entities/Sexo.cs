using LolaApp.Core;

namespace LolaApp.Entities
{
    public class Sexo : EntityBase
    {
        public int Id { get; set; }

        public string Denominacion { get; set; }

        public bool Deshabilitado { get; set; }

    }

}
