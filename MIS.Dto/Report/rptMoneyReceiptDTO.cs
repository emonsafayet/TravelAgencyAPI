using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.Report
{
    public class rptMoneyreceiptMasterDTO
    {
        public Nullable<int> ID { get; set; }
        public string ReceiptCode { get; set; }
        public Nullable<DateTime> ReceivedDate { get; set; }
        public string CustomerCode { get; set; }
        public Nullable<decimal> TotalPayableAmount { get; set; }
        public string Remark { get; set; }
        public Nullable<Boolean> IsLocked { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string Email { get; set; }
        public string EmergencyNo { get; set; }
        public string MobileNo { get; set; }
        public string Passport { get; set; }
        public string NID { get; set; }
        public string PreparedBy { get; set; }
    }
    public class rptMRPaymentDetailsDTO
    {
        public Nullable<int> ID { get; set; }
        public string ReceiptCode { get; set; }
        public string PaymentType { get; set; }
        public Nullable<decimal> ReceivedAmount { get; set; }
        public string BankName { get; set; }
        public string ChequeNo { get; set; }
        public string CardNo { get; set; }
        public string POSTransactionNo { get; set; }
        public string TxnNo { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string PaymentTypeName { get; set; }
        public string BankName1 { get; set; }
    }
    public class rptMRServiceDetailsDTO
    {
        public string ReceiptCode { get; set; }

        public string servicecode { get; set; }
        public string serviceName { get; set; }
        public string InvoiceId { get; set; }
        public Nullable<DateTime> InvoiceDate { get; set; }
        public string ServiceDescription { get; set; }

        public Nullable<decimal> InvoiceAmount { get; set; }
        public Nullable<decimal> PrePaidAmount { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public string Remark { get; set; }
        public Nullable<decimal> RefundAmount { get; set; }
    }

}
