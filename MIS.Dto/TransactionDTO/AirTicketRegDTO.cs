using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.TransactionDTO
{
    public class AirTicketRegMasterDTO
    {
        public Nullable<int> ID { get; set; }

        public string TransactionCode { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public string CustomerCode { get; set; }
        public string Remarks { get; set; }
        public string SalesReferenceCode { get; set; }

        public Nullable<Boolean> isConfirmed { get; set; }
        public Nullable<Boolean> IsFinalLocked { get; set; }
        public string CardCode { get; set; }      
        public string Currency { get; set; }

        public Nullable<decimal> CurrencyRate { get; set; }
        public  decimal NetPayableAmt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string AirticketDetails { get; set; }

    }
    public class AirTicketDetailDto  
    {
        public Nullable<int> DetailID { get; set; }

        public string TransactionCode { get; set; }
        public string NameofPerson { get; set; }
        public string AirlinesCode { get; set; }
        public string Route { get; set; }
        public string TicketNo { get; set; }

        public string SeatTypeCode { get; set; }
        public string ProviderCode { get; set; }
        public Nullable<DateTime> TravelDate { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
        public Nullable<decimal> BaseFare { get; set; }

        public Nullable<decimal> GovTax { get; set; }
        public Nullable<decimal> AIT { get; set; }
        public Nullable<decimal> ComissionChargePercent { get; set; }
        public Nullable<decimal> Comission { get; set; }
        public Nullable<decimal> CardChargeAmount { get; set; }
        public Nullable<decimal> ServiceChargePercent { get; set; }
        public Nullable<decimal> ServiceChargeValue { get; set; }

        public Nullable<decimal> DiscountValue { get; set; }
        public Nullable<decimal> TotalPayableAmt { get; set; }
        public Nullable<Boolean> IsForward { get; set; }
        public Nullable<decimal> ChangePenalty { get; set; }
        public Nullable<DateTime> ChangeDate { get; set; }
        public Nullable<decimal> ProviderPenalty { get; set; }
        public Nullable<Boolean> IsCancel { get; set; }
        public Nullable<decimal> CancellationCharge { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }

    public class  AirTicketListDTO {
 
            public Nullable<int> ID { get; set; }
            public string TransactionCode { get; set; }
            public Nullable<DateTime> TransactionDate { get; set; }
            public string CustomerCode { get; set; }
            public string Remarks { get; set; }
            public string SalesReferenceCode { get; set; }

            public Nullable<Boolean> isConfirmed { get; set; }
            public Nullable<Boolean> IsFinalLocked { get; set; }
            public string CardCode { get; set; } 
            public string Currency { get; set; }

            public Nullable<decimal> CurrencyRate { get; set; }
            public Nullable<decimal> NetPayableAmt { get; set; }
            public string CreatedBy { get; set; }
            public string UpdatedBy { get; set; }

            public string CustomerName { get; set; }
            public string SalesStaffName { get; set; }
       

    }
}
