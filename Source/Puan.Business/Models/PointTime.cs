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
            //KindPointTimes = new HashSet<KindPointTime>(); //RELACIONAMENTO DO TIPO MUITOS 
        }

        public long Id { get; set; }
        public long IdKindPointTimes { get; set; }
        public DateTime Mark { get; set; }
        public bool Activated { get; set; }


        //public virtual IEnumerable<KindPointTime> KindPointTimes { get; set; }  //RELACIONAMENTO DO TIPO MUITOS 
        public virtual KindPointTime KindPointTimes { get; set; }

    }
}
