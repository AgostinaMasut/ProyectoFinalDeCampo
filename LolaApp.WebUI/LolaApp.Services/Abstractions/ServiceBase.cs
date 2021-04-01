using LolaApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolaApp.Services.Abstractions
{
    public abstract class ServiceBase<T> where T : EntityBase
    {
        private readonly IRepositoryBase<T> _repository;
        public IRepositoryBase<T> Repo => _repository;
        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }
    }
}
