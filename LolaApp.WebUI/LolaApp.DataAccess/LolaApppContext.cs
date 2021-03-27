using LolaApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolaApp.DataAccess
{
    public class LolaApppContext : DbContext
    {
        public LolaApppContext() : base("CS")
        {

        }
        public DbSet<Sexo> Sexo { get; set; }
        public DbSet<TipoDeUsario> TipoDeUsario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
