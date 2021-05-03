using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.BusinessDTO
{
    public class OnlineRegistationDTO
    {
        public int ID { get; set; }
        public string TransactionCode { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public string CustomerCode { get; set; }
        public string TravelDestinationCode { get; set; }
        public string SalesReferenceCode { get; set; }
        public string Remarks { get; set; }
        public decimal NetPayableAmt { get; set; }
        public bool IsCancel { get; set; }
        public bool IsFinalLocked { get; set; }
        public string ReasonofCancel { get; set; }
        public string CardCode { get; set; }       
        public string Currency { get; set; }
        public Nullable<decimal> CurrencyRate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string OnlineRegistrationDetail { get; set; }

    }
    public class OnlineRegistationListDto  
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
        public Nullable<Boolean> IsCancel { get; set; }
        public string ReasonofCancel { get; set; }
        public string CardCode { get; set; } 
        public string Currency { get; set; }
        public Nullable<decimal> CurrencyRate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CardName { get; set; }
        public string CustomerName { get; set; }
        public string DestinationName { get; set; }
        public string CurrencyName { get; set; }
        public string SALESEXCUTIVENAME { get; set; }
    }

}
