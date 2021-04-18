using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Infra.CrawlerOncid.Component.Interface
{
    public interface ICrawlerOncidConector
    {
        Task<String> MarkPoint();
        Task<String> MarkPoint(string usuario, string senha);
    }
}
