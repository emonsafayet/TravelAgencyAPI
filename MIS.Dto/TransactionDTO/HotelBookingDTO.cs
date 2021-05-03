using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.TransactionDTO
{
    public class HotelBookingDTO
    {
        public Nullable<int> ID { get; set; }

        public string TransactionCode { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public string CustomerCode { get; set; }
        public string SalesStaffCode { get; set; }
        public string CardCode { get; set; }

        public string Currency { get; set; }
        public Nullable<decimal> CurrencyRate { get; set; }
        public string Remark { get; set; }
        public Nullable<decimal> NetPayableAmt { get; set; }
        public Nullable<Boolean> IsFinalLocked { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string FullName { get; set; }

        public string CardName { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string CustomerAddress { get; set; }
        public string HotelBookingDetail { get; set; }

    }
    public class HotelBookingByTransCodeDto 
    {
        public Nullable<int> ID { get; set; }

        public string TransactionCode { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public string CustomerCode { get; set; }
        public string SalesStaffCode { get; set; }
        public string CardCode { get; set; }

        public string Currency { get; set; }
        public Nullable<decimal> CurrencyRate { get; set; }
        public string Remark { get; set; }
        public Nullable<decimal> NetPayableAmt { get; set; }
        public Nullable<Boolean> IsFinalLocked { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<int> DetailID { get; set; }
         
        public string NameofPerson { get; set; }
        public string CityName { get; set; }
        public string TravelProvider { get; set; }
        public string HotelName { get; set; }
        public string BookingRefNo { get; set; }
        public string RoomType { get; set; }
        public Nullable<DateTime> CheckInDate { get; set; }
        public Nullable<DateTime> CheckOutDate { get; set; }
        public Nullable<int> NoOfDay { get; set; }
        public Nullable<decimal> CardChargeAmount { get; set; }

        public Nullable<decimal> RoomFare { get; set; }
        public Nullable<decimal> ServiceChargePercent { get; set; }
        public Nullable<decimal> ServiceChargeValue { get; set; }
        public Nullable<decimal> DiscountValue { get; set; }
        public Nullable<decimal> TotalPayableAmt { get; set; }

        public Nullable<Boolean> IsCancel { get; set; }
        public Nullable<decimal> CancellationCharge { get; set; }

        public string SalesStaff { get; set; }
        public string Preparedby { get; set; }

        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string RoomTypeName { get; set; }
        public string ProviderName { get; set; }
    }
}
