using Puan.Business.Interfaces.Adapter;
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
    public class OncidService : IOncidService
    {
        private readonly ICrawlerOncidAdapter _crawlerOncidService;

        public OncidService(ICrawlerOncidAdapter crawlerOncidService)
        {
            _crawlerOncidService = crawlerOncidService;
            
        }

        public Task<String> MarkPoint()
        {
            _crawlerOncidService.MarkPoint();
            //_pointTimeRepositoryDap.Add(new PointTime {
            //    Mark = DateTime.Now,
            //    Activated = true
            //});
            return null;
        }

        public Task<String> MarkPoint(string usuario, string senha)
        {
            _crawlerOncidService.MarkPoint(usuario, senha);
            return null;
        }
    }
}
