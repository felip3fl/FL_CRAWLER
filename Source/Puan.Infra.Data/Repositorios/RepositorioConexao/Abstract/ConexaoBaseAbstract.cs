using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Infra.Data.Repositorios.RepositorioConexao.Abstract
{
    public abstract class ConexaoBaseAbstract
    {
        public abstract SqlConnection RetornarStringConexao();
        public abstract void SetAmbiente(string dataSourceServidor, string initialCatalog, string usuario, string senha);
    }
}
