using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.TransactionDTO
{
    public class MoneyReceiptDTO
    {
        public Nullable<int> ID { get; set; }
        public string ReceiptCode { get; set; }
        public Nullable<DateTime> ReceivedDate { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public Nullable<decimal> TotalPayableAmount { get; set; }
        public string Remark { get; set; }
        public Nullable<Boolean> IsLocked { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string PaymentDetail { get; set; }
        public string InvoiceDetail { get; set; }

    }
    public class MRInvoiceDetailDTO
    {
        public Nullable<int> ID { get; set; }
        public string InvoiceID { get; set; }
        public string ReceiptCode { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<decimal> RefundAmount { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }


    }
    public class MRPaymentDetailsDTO
    {
        public Nullable<int> ID { get; set; }
        public string AdvanceCode { get; set; }
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
    }
    public class ServiceDetailByCustomerCodeDTO
    {
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string InvoiceID { get; set; }
        public Nullable<DateTime> InvoiceDate { get; set; }
        public string CustomerCode { get; set; }
        public string ServiceDescription { get; set; }    
        public Nullable<decimal> InvoiceAmount { get; set; }
        public Nullable<decimal> PrePaidAmount { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public string Remark { get; set; }
        public Nullable<decimal> RefundAmount { get; set; }
    }
    public class MrCustomerDTO
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerTypeCode { get; set; }
        public string CustomerTypeName { get; set; }
    }

    public class CustomerAdvanceAmountDto
    {
        public string CustomerCode { get; set; }

        public string AdvanceCode { get; set; }
        public Nullable<DateTime> AdvanceDate { get; set; }
        public Nullable<decimal> AdvanceAmount { get; set; }
        public Nullable<decimal> AdjustedAmount { get; set; }
        public Nullable<decimal> UnAdjustedBalance { get; set; }

    }

}
