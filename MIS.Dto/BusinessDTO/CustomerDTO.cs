using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BusinessService.Map.ClientBusinessMap
{
    public class CustomerDto 
    {
        public Nullable<int> ID { get; set; }

        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerTypeCode { get; set; }
        public string CustomerTypeName  { get; set; }
        public string CustomerAddress { get; set; }
        public string MobileNo { get; set; }

        public string EmergencyNo { get; set; }
        public string ContactPersion { get; set; }
        public string Passport { get; set; }
        public string NID { get; set; }
        public string Email { get; set; }

        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<Boolean> isActive { get; set; }
    }

}
