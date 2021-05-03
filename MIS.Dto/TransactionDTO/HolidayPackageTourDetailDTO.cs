using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.TransactionDTO
{
    public class HolidayPackageTourDetailDTO
    {
        public Nullable<int> ID { get; set; }
        public string HOPCode { get; set; }
        public string PackageCode { get; set; }
        public string EventName { get; set; }
        public string EventDetail { get; set; }
        public string EventRemark { get; set; }
        public Nullable<decimal> EventCharge { get; set; }
    }
}
