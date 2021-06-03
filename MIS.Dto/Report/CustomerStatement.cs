using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.Report
{ 
    public class rptCustomerStatement
    {
        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }
        public string ServiceName { get; set; }
        public string TransactionCode { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public Nullable<decimal> NetPayableAmt { get; set; }

        public string ReceiptCode { get; set; }
        public Nullable<DateTime> ReceivedDate { get; set; }
        public Nullable<decimal> collectamt { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
        public Nullable<decimal> AdvanceAmount { get; set; }

    }
    public class rptGetCustomerwiseColletionSummaryDto  
    {
        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }
        public string ReceiptCode { get; set; }
        public Nullable<DateTime> ReceivedDate { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }

        public string InvoiceID { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public Nullable<int> AgeofInvoice { get; set; }
        public Nullable<decimal> InvoiceAmount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }

    }



}
