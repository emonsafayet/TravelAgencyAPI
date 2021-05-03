using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.TransactionDTO
{
    public class HolidayPackageTourInfoDTO
    {
        public Nullable<int> ID { get; set; }
        public string HOPCode { get; set; }
        public Nullable<DateTime> TourDate { get; set; }
        public Nullable<int> NoOfPersonAdult { get; set; }
        public Nullable<int> NoOfPersonChild { get; set; }
        public string CustomerCode { get; set; }
        public string CompanyCode { get; set; }
        public string Destination { get; set; }
        public string PackageCode { get; set; }
        public Nullable<int> NoOfDay { get; set; }
        public string Currency { get; set; }
        public Nullable<decimal> CurrencyRate { get; set; }
        public Nullable<decimal> TotalServiceCharge { get; set; }
        public Nullable<decimal> TotalPayable { get; set; }
        public string CardCode { get; set; }
        public string SalesStaffCode { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string CardName { get; set; }
        public string PackageName { get; set; }
        public string EmployeeName { get; set; }
    }
}
