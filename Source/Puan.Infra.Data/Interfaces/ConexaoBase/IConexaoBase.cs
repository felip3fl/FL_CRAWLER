using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Infra.Data.Interfaces.ConexaoBase
{
    public interface IConexaoBase
    {
        void SetAmbiente(string dataSourceServidor, string initialCatalog, string usuario, string senha);
    }
}
