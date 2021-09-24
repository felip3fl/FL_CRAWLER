using Puan.Infra.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Infra.Data.Interfaces.ConexaoBase
{
    public interface IFactoryConexaoBase
    {
        string StringConexaoBase(EnumBaseConexao tipoConexao);
    }
}
