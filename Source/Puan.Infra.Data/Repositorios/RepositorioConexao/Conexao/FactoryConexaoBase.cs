using Microsoft.Extensions.Configuration;
using Puan.Infra.Data.Enum;
using Puan.Infra.Data.Interfaces.ConexaoBase;
using Puan.Infra.Data.Repositorios.RepositorioConexao.Abstract;
using Puan.Infra.Data.Repositorios.RepositorioConexao.Conexoes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Infra.Data.Repositorios.RepositorioConexao.Conexao
{
    public class FactoryConexaoBase : ConexaoBaseAbstract, IFactoryConexaoBase
    {
        private readonly IConfiguration _config;

        private ConexaoBaseAbstract _conexaoBase;
        private string _dataSourceServidor;
        private string _initialCatalog;
        private string _usuario;
        private string _senha;

        public FactoryConexaoBase(IConfiguration config)
        {
            _config = config;
        }

        public override SqlConnection RetornarStringConexao()
        {
            SqlConnection conexao = new SqlConnection(); 

            CarregarVariaveisDeClasse();
            //_conexaoBase = new ShadowConexaoBase(_dataSourceServidor, _initialCatalog,_usuario,_senha);
            _conexaoBase = new ShadowConexaoBase();
            _conexaoBase.SetAmbiente(_dataSourceServidor,_initialCatalog,_usuario,_senha);
            return _conexaoBase.RetornarStringConexao();
        }

        public override void SetAmbiente(string dataSourceServidor, string initialCatalog, string usuario, string senha)
        {
            _dataSourceServidor = _config["DataBase:DataSource"];
            _initialCatalog = _config["DataBase:InitialCatalog"];
            _usuario = _config["DataBase:UserId"];
            _senha = _config["DataBase:Password"];
        }

        private void CarregarVariaveisDeClasse()
        {
            _dataSourceServidor = _config["DataBase:DataSource"];
            _initialCatalog = _config["DataBase:InitialCatalog"];
            _usuario = _config["DataBase:UserId"];
            _senha = _config["DataBase:Password"];
        }

        public string StringConexaoBase(EnumBaseConexao tipoConexao)
        {
            return RetornarStringConexao().ConnectionString;
        }
    }
}
