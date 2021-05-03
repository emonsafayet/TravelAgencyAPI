using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.TransactionDTO
{
    public class VisaRegistationDTO
    {

        public int ID { get; set; }
        public string TransactionCode { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public string CustomerCode { get; set; }
        public string SalesReferenceCode { get; set; }
        public decimal NetPayableAmt { get; set; }
        public bool IsFinalLocked { get; set; }
        public string CardCode { get; set; }
        public string Currency { get; set; }
        public Nullable<decimal> CurrencyRate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public bool isActive { get; set; }
        public string Remark { get; set; }
        public  string visaDetails  { get; set; }

    }
    public class VisaRegistrationList {

        public Nullable<int> ID { get; set; }

        public string TransactionCode { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public string CustomerCode { get; set; }
        public string SalesReferenceCode { get; set; }
        public Nullable<decimal> NetPayableAmt { get; set; }

        public Nullable<Boolean> IsFinalLocked { get; set; }
        public string CardCode { get; set; }
        public string Currency { get; set; }
        public Nullable<decimal> CurrencyRate { get; set; }
        public string Remark { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string CustomerAddress { get; set; }
        public string CardName { get; set; }
        public string CurrencyName { get; set; }

        public string SalesStaffName { get; set; }
    }
}