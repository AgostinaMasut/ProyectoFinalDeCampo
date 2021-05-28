using LolaApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolaApp.DataAccess
{
    public class LolaAppContext : DbContext
    {

        public LolaAppContext() : base("CS")
        {

        }
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Sexo> Sexo { get; set; }
        public DbSet<TipoDeUsario> TipoDeUsario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
