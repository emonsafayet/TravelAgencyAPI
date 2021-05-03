using MIS.Data.ClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.BusinessDTO
{
    public class PackageMasterDTO
    {
        public int ID { get; set; }
        public string PackageCode { get; set; }
        public string PackageName { get; set; }
        public string Summary { get; set; }
        public  int NoOfDay { get; set; }
        public  int NoOfNight { get; set; }
        public decimal TotalPackagePrice { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public  DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool isActive { get; set; }
        public string packageDetails { get; set; }

        public List<PackageDetail> PackageDetailList = new List<PackageDetail>();
    } 
}
