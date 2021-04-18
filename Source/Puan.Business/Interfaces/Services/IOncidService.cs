using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Business.Interfaces.Services
{
    public interface IOncidService
    {
        Task<String> MarkPoint();
        Task<String> MarkPoint(string usuario, string senha);
    }
}
