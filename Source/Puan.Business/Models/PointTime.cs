using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Business.Models
{
    [Table("TB_POINT_TIME")]
    public class PointTime
    {

        public PointTime()
        {
            KindPointTimes = new HashSet<KindPointTime>();
        }

        public long Id { get; set; }
        public DateTime Mark { get; set; }
        public bool Activated { get; set; }

        public virtual IEnumerable<KindPointTime> KindPointTimes { get; set; }

    }
}
