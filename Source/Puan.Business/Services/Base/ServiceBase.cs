using Puan.Business.Interfaces.Repositories.Dapper;
using Puan.Business.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Business.Services.Base
{
    public class ServiceBase<T> : IDisposable, IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Add(T obj)
        {
            return await _repository.Add(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<T> GetById(long id)
        {
            return await _repository.GetById(id);
        }

        public async Task<T> Update(T obj)
        {
            return await _repository.Update(obj);
        }
    }
}
