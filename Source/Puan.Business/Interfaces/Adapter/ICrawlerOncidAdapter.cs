using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Business.Interfaces.Adapter
{
    public interface ICrawlerOncidAdapter
    {
        Task<String> MarkPoint();
        Task<String> MarkPoint(string nome, string senha);
    }
}
