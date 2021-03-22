using Puan.Business.Interfaces.Adapter;
using Puan.Infra.CrawlerOncid.Component.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Infra.CrawlerOncid.Adapter
{
    public class CrawlerOncidAdapter : ICrawlerOncidAdapter
    {
        private readonly ICrawlerOncidConector _crawlerOncidConector;

        public CrawlerOncidAdapter(ICrawlerOncidConector crawlerOncidConector)
        {
            _crawlerOncidConector = crawlerOncidConector;
        }

        public Task<string> MarkPoint()
        {
            _crawlerOncidConector.MarkPoint();
            throw new NotImplementedException();
        }
    }
}
