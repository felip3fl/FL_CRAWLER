using Puan.Business.Interfaces.Repositories.Dapper;
using Puan.Business.Interfaces.Services;
using Puan.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Business.Services
{
    public class PointTimeService : IPointTimeService
    {
        private readonly IPointTimeRepositoryDap _pointTimeRepositoryDap;

        public PointTimeService(IPointTimeRepositoryDap pointTimeRepositoryDap)
        {
            _pointTimeRepositoryDap = pointTimeRepositoryDap;
        }

        public async Task<PointTime> Add(PointTime pointTime)
        {
            try
            {
                return await _pointTimeRepositoryDap.Add(pointTime);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            await _pointTimeRepositoryDap.Delete(id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PointTime>> GetAll()
        {
            try
            {
                return await _pointTimeRepositoryDap.GetAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<PointTime> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PointTime>> GetByType(int id)
        {
            return await _pointTimeRepositoryDap.GetByType(id);
        }

        public Task<PointTime> Update(PointTime obj)
        {
            throw new NotImplementedException();
        }
    }
}
