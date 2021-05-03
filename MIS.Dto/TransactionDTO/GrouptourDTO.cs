using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.TransactionDTO
{
    public class GrouptourMasterDTO
    {
        public Nullable<int> ID { get; set; }
        public string TransactionCode { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public string TourName { get; set; }
        public Nullable<DateTime> TourStartDate { get; set; }
        public Nullable<DateTime> TourEndDate { get; set; }
        public Nullable<int> NoofDays { get; set; }
        public Nullable<int> NoofNight { get; set; }
        public Nullable<int> NoofParticipent { get; set; }
        public string SalesReferenceCode { get; set; }
        public Nullable<Boolean> IsFinalLocked { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string customers { get; set; }
        public string participants { get; set; }
        public string eventDetails { get; set; }
    }
    public class GroupTourMemberDto 
    {
        public Nullable<int> ID { get; set; }
        public string TransactionCode { get; set; }
        public string CustomerCode { get; set; }
        public string NameofParticipent { get; set; }
        public string PassportNo { get; set; }
        public Nullable<Boolean> IsChild { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
    public class GroupTourListDto 
    {
        public Nullable<int> ID { get; set; }
        public string TransactionCode { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public string TourName { get; set; }
        public Nullable<DateTime> TourStartDate { get; set; }
        public Nullable<DateTime> TourEndDate { get; set; }
        public Nullable<int> NoofDays { get; set; }
        public Nullable<int> NoofNight { get; set; }
        public Nullable<int> NoofParticipent { get; set; }
        public string SalesReferenceCode { get; set; }
        public Nullable<Boolean> IsFinalLocked { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string SalesStaff { get; set; }
        public string PreparedBy { get; set; }
    }

    public class rptGetGroupTourbytransCodeDto
    {
        public string TransactionCode { get; set; }

        public Nullable<DateTime> TransactionDate { get; set; }
        public string TourName { get; set; }
        public Nullable<DateTime> TourStartDate { get; set; }
        public Nullable<DateTime> TourEndDate { get; set; }
        public Nullable<int> NoofDays { get; set; }

        public Nullable<int> NoofNight { get; set; }
        public Nullable<int> NoofParticipent { get; set; }
        public string SalesReferenceCode { get; set; }
        public string SalesPersonName { get; set; }
        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }
        public Nullable<decimal> NetPayableAmt { get; set; }
        public string CardCode { get; set; }
        public string Currency { get; set; }
        public Nullable<decimal> CurrencyRate { get; set; }

    }

    public class rptGetGroupMemberbytransCodeDto
    {
        public string TransactionCode { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string NameofParticipent { get; set; }
        public string PassportNo { get; set; }
        public Nullable<Boolean> IsChild { get; set; }

    }

    public class rptGetGroupDetailsbytransCodeDto
    {
        public string TransactionCode { get; set; }
        public string ServiceName { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string NameofParticipent { get; set; }
        public string ProviderCode { get; set; }
        public string ProviderName { get; set; }

        public string AirlinesCode { get; set; }
        public string AirlinesName { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Route { get; set; }

        public string HotelName { get; set; }
        public string RoomType { get; set; }
        public Nullable<decimal> CardChargeAmount { get; set; }
        public Nullable<decimal> MainPrice { get; set; }
        public Nullable<decimal> GovtTax { get; set; }

        public Nullable<decimal> Commision { get; set; }
        public Nullable<decimal> ServiceCharge { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<Boolean> IsCancel { get; set; }
        public Nullable<decimal> CancelationCharge { get; set; }

        public Nullable<decimal> TotalPayableamt { get; set; }
    }



}
