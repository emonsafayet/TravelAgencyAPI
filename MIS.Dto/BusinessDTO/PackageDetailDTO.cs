using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.BusinessDTO
{
    public class PackageDetailDTO
    {
        public int ID { get; set; }
        public string PackageCode { get; set; }
        public string EventName { get; set; }
        public string EventDetails { get; set; }
        public Nullable<decimal> EventPrice { get; set; }
        public string Remarks { get; set; }
     
    }
}
