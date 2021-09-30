using Puan.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Puan.Business.Interfaces.Repositories.Dapper
{
    public interface IPointTimeRepositoryDap : IRepositoryBase<PointTime>
    {
        //Task<PointTime> Add(PointTime pointTime);

        Task<IEnumerable<PointTime>> GetByType(int id);

        Task Delete(int id);
    }
}
