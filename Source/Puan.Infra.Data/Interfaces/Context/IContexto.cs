using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Infra.Data.Interfaces.Context
{
    public interface IContexto
    {
        IDbConnection Connection();
    }
}
