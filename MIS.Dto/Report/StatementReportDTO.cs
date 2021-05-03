using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.Report
{
    public class rptCreditCardStatementDto
    {
        public string FromDate { get; set; }

        public string ToDate { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string Currency { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public string TransactionCode { get; set; }
        public string NameofPerson { get; set; }
        public string EventName { get; set; }
        public Nullable<decimal> CurrencyRate { get; set; }
        public Nullable<decimal> cardchargeamount { get; set; }
        public Nullable<decimal> ChargedAmountinLocalcurrency { get; set; }

    }
    public class rptCustomerDueStatusDto
    {
        public Nullable<DateTime> ASONDate { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string InvoiceID { get; set; }
        public Nullable<DateTime> InvoiceDate { get; set; }

        public string InvoiceAging { get; set; }
        public Nullable<decimal> InvoiceAmount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
    }

}
