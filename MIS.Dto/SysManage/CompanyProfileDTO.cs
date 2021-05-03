using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.SysManage
{
    public class CompanyProfileDTO
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string TradeLicNo { get; set; }
        public string InsuranceNo { get; set; }
        public System.DateTime OpeningDate { get; set; }
        public string HoAddress { get; set; }
        public string CompanyLogo { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}
