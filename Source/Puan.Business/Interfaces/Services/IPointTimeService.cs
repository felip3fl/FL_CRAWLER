using Puan.Business.Interfaces.Services.Base;
using Puan.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Puan.Business.Interfaces.Services
{
    public interface IPointTimeService : IServiceBase<PointTime>
    {
        Task<PointTime> Add(PointTime pointTime);

        Task<IEnumerable<PointTime>> GetByType(int id);

        Task Delete(int id);
    }
}
