using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.Report
{ 
    public class rptGetCustomerStatement
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

}
