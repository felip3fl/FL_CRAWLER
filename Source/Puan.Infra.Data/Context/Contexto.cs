using Puan.Infra.Data.Interfaces.ConexaoBase;
using Puan.Infra.Data.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Infra.Data.Context
{
    public class Contexto : IContexto
    {
        private readonly string _connectionString;

        public Contexto(IFactoryConexaoBase factoryConexaoBase)
        {
            _connectionString = factoryConexaoBase.StringConexaoBase(Enum.EnumBaseConexao.SHADOW);
        }

        public IDbConnection Connection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
