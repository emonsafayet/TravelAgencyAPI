using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.Report
{
    public class rptIncomeFlowSummary
    {
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string TransactionCode { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public Nullable<decimal> Comission { get; set; }
        public Nullable<decimal> ServiceChargeValue { get; set; }
        public Nullable<decimal> DiscountValue { get; set; }
        public Nullable<decimal> ChangePenalty { get; set; }
        public Nullable<decimal> ProviderPenalty { get; set; }
        public Nullable<decimal> ChangeValueGain { get; set; }
        public Nullable<decimal> GrossIncome { get; set; }

    }

    public class rptIncomeFlowDetails
    {
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string TransactionCode { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string NameofPerson { get; set; }
        public Nullable<decimal> Comission { get; set; }
        public Nullable<decimal> ServiceChargeValue { get; set; }
        public Nullable<decimal> DiscountValue { get; set; }
        public Nullable<decimal> ChangePenalty { get; set; }
        public Nullable<decimal> ProviderPenalty { get; set; }
        public Nullable<decimal> ChangeValueGain { get; set; }
        public Nullable<decimal> GrossIncome { get; set; }
    }



}
