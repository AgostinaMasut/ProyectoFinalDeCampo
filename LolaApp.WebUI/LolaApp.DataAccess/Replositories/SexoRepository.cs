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
    public class SexoRepository : RepositoryBase<Sexo>, ISexoRepository
    {
        public SexoRepository(DbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
