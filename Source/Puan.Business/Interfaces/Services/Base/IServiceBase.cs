using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Business.Interfaces.Services.Base
{
    public interface IServiceBase<T> where T : class
    {
        Task<T> Add(T obj);
        Task<T> Update(T obj);
        Task<T> GetById(long id);
        Task<IEnumerable<T>> GetAll();
        void Dispose();
    }
}
