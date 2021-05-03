using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.Report
{
    public class ServiceTransactionSummaryDTO
    {
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public Nullable<int> NoOfService { get; set; }
        public Nullable<int> BusinessClient { get; set; }
        public Nullable<int> CorporateClient { get; set; }
        public Nullable<int> OtherClient { get; set; }
        public Nullable<decimal> TotalServiceAmt { get; set; }
        public Nullable<decimal> BusinessClientValue { get; set; }
        public Nullable<decimal> CorporateClientValue { get; set; }
        public Nullable<decimal> OtherClientValue { get; set; }


    }
    public class ServiceTransactionDetailDTO 
    {
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string RegistrationCode { get; set; }
        public Nullable<DateTime> RegistationDate { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerTypeCode { get; set; }
        public string TypeName { get; set; }
        public string ServiceDescription { get; set; }
        public Nullable<decimal> ServiceAmount { get; set; }
    }
}
