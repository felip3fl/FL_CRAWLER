using Puan.Business.Interfaces.Services.Base;
using Puan.Business.Models;
using System.Threading.Tasks;

namespace Puan.Business.Interfaces.Services
{
    public interface IPointTimeService : IServiceBase<PointTime>
    {
        Task<PointTime> Add(PointTime pointTime);
    }
}
