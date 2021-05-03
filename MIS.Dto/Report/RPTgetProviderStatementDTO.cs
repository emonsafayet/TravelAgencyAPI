using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.Report
{
    public class RPTgetProviderStatementDTO
    {
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public string ProviderCode { get; set; }
        public string ProviderName { get; set; }
        public string ServiceName { get; set; }
        public string TransactionCode { get; set; }
        public string CustomerName { get; set; }
        public string PersonName { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public Nullable<decimal> OpeningBalance { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<decimal> ExpenseAmount { get; set; }
    }
}
