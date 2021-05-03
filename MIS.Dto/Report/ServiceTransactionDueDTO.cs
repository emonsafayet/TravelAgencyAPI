using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.Report
{
    public class DueStatusASONDto
    {
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public Nullable<decimal> InvoiceAmount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
    }
    public class DueStatusASONDetailsDto
    {
        public string ServiceCode { get; set; }
        public DateTime ASONDate { get; set; }        
        public string ServiceName { get; set; }
        public string InvoiceID { get; set; }
        public Nullable<DateTime> InvoiceDate { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }        
        public string ServiceDescription { get; set; }
        public Nullable<decimal> InvoiceAmount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
    }

}
