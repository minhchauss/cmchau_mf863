using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
   public class PaggingData<MSEntity>
    {
        public int TotalCount { get; set; }
        public IEnumerable<MSEntity> Items { set; get; }
    }
}
