
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.Report
{
    public  class TransactionCollectionSummaryDTO
    {
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public Nullable<decimal> Payableamount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
    }
    public class TransactionCollectionDetailsDto
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string ReceiptCode { get; set; }
        public Nullable<DateTime> ReceivedDate { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceID { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
    }
    public class CustomerAdvanceSummaryDto 
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public Nullable<decimal> AdvanceAmt { get; set; }
    }

}
