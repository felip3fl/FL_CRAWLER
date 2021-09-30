using Dapper.FluentMap.Dommel.Mapping;
using Puan.Business.Models;
using Puan.Infra.Data.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Infra.Data.Mapping
{
    public class PointTimeMap : DommelEntityMap<PointTime>, IMapping
    {
        public PointTimeMap()
        {
            ToTable("TB_POINT_TIME");

            Map(x => x.Id).ToColumn("ID_POINT_TIME");
            Map(x => x.Mark).ToColumn("DT_INCLUSAO");
            Map(x => x.Activated).ToColumn("ST_ATIVO");
            Map(x => x.IdKindPointTimes).ToColumn("ID_KIND_POINT_TIME");
        }

    }
}
