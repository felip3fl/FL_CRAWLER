using Puan.Infra.Data.Interfaces.ConexaoBase;
using Puan.Infra.Data.Repositorios.RepositorioConexao.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Infra.Data.Repositorios.RepositorioConexao.Conexoes
{
    public class ShadowConexaoBase : ConexaoBaseAbstract, IConexaoBase
    {
        private string _dataSourceServidor;
        private string _initialCatalog;
        private string _usuario;
        private string _senha;

        //public ShadowConexaoBase(string dataSourceServidor, string initialCatalog, string usuario, string senha)
        //public ShadowConexaoBase()
        //{
        //    SetAmbiente(dataSourceServidor, initialCatalog, usuario, senha);
        //}

        public override SqlConnection RetornarStringConexao()
        {
            SqlConnection conexao = null;
            var stringConexao = string.Empty;
            var complemento = string.Empty;

            stringConexao = "Data Source=" + _dataSourceServidor + ";" +
                            "Initial Catalog=" + _initialCatalog + ";" +
                            "User ID=" + _usuario + ";" +
                            "Connection Timeout= 360;persist security info=true;";

            stringConexao += "Password=" + _senha;
            stringConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Felipe\PuanDataBase.mdf;Integrated Security=True;Connect Timeout=30"; //TODO REMOVE
            conexao = new SqlConnection(stringConexao);

            return conexao;
        }

        public override void SetAmbiente(string dataSourceServidor, string initialCatalog, string usuario, string senha)
        {
            _dataSourceServidor = dataSourceServidor;
            _initialCatalog = initialCatalog;
            _usuario = usuario;
            _senha = senha;
        }
    }
}
