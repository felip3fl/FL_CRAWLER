using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puan.API.Models
{
    public class PointTimeModel
    {
        public long Id { get; set; }
        public long IdKindPointTimes { get; set; }
        public DateTime Mark { get; set; }
        public bool Activated { get; set; }
    }
}
