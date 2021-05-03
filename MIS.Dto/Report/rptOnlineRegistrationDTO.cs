using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.Report
{
    public class rptgetOnlineRegistationByregCodeDto  
    {
        public Nullable<int> ID { get; set; }
        public string TransactionCode { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public string CustomerCode { get; set; }
        public string TravelDestinationCode { get; set; }
        public string SalesReferenceCode { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> NetPayableAmt { get; set; }
        public Nullable<Boolean> IsFinalLocked { get; set; }
        public string CardCode { get; set; }
        public Nullable<decimal> CardChargeAmount { get; set; }
        public string Currency { get; set; }
        public Nullable<decimal> CurrencyRate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<int> OnlineRegDetailID { get; set; } 
        public string NameofPerson { get; set; }
        public string EventName { get; set; }
        public Nullable<DateTime> EvenDate { get; set; }
        public Nullable<decimal> RegistrationCharge { get; set; }
        public Nullable<decimal> ServiceChargePercent { get; set; }
        public Nullable<decimal> ServiceChargeValue { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<decimal> TotalPayableAmt { get; set; }
        public Nullable<Boolean> IsCancel { get; set; }
        public Nullable<decimal> CancellationCharge { get; set; } 
        public string CardName { get; set; }
        public string CustomerName { get; set; }
        public string DestinationName { get; set; }

        public string CurrencyName { get; set; }
        public string SALESEXCUTIVENAME { get; set; }
        public string PreparedBy { get; set; }
    }


}
