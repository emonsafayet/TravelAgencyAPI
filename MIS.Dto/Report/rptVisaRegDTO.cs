using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.Report
{
    public class rptGetVisaRegistationByVisaRegCodeDto 
    {
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
        public Nullable<int> DetailID { get; set; } 
        public string NameofPerson { get; set; }
        public string VisaType { get; set; }
        public string VisaCountry { get; set; }

        public string PassportNo { get; set; }
        public Nullable<decimal> CardChargeAmount { get; set; }
        public Nullable<decimal> VisaFee { get; set; }
        public Nullable<decimal> GovtTax { get; set; }
        public Nullable<decimal> ServiceChargePercent { get; set; }

        public Nullable<decimal> ServiceChargeValue { get; set; }
        public Nullable<decimal> TotalPayableAmt { get; set; } 

        public string VisaTypeName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string visaCountryName { get; set; }

        public string CardName { get; set; }
        public string SalesStaffName { get; set; }
        public string PreparedBy { get; set; }
        public string ProviderName { get; set; }

        
    }
}
