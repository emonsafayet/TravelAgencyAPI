using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.BusinessDTO
{
    public  class AdvancePaymentClearanceDTO
    {
        public Nullable<int> ID { get; set; }

        public string AdvanceCode { get; set; }
        public Nullable<DateTime> AdvanceDate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string CompanyCode { get; set; }
        public string CustomerCode { get; set; }

        public string PaymentType { get; set; }
        public string BankCode { get; set; }
        public string ChequeNo { get; set; }
        public Nullable<DateTime> ClearingDate { get; set; }
        public Nullable<Boolean> isClear { get; set; }

        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string PaymentTypeName { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string BankName { get; set; }
    }
}
