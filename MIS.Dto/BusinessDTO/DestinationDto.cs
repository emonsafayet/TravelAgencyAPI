using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.BusinessDTO
{
    public class DestinationDto
    {
        public Nullable<int> ID { get; set; }
        public string DestinationCode { get; set; }
        public string DestinationName { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public bool isActive { get; set; }
    }
}
 