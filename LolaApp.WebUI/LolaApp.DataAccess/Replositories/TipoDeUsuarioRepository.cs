using LolaApp.DataAccess.Concrete;
using LolaApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolaApp.DataAccess.Replositories
{
    public class TipoDeUsuarioRepository : RepositoryBase<TipoDeUsario>, ITipoDeUsuarioRepository
    {
        public TipoDeUsuarioRepository(DbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
