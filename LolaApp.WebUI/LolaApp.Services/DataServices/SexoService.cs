using LolaApp.Entities;
using LolaApp.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolaApp.Services.DataServices
{
    public class SexoService : ServiceBase<Sexo>, ISexoService
    {
        public SexoService(IRepositoryBase<Sexo> repository) : base(repository)
        {
        }
    }
}
