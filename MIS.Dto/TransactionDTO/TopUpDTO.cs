using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.TransactionDTO
{
    public class TopUpDTO
    {

        public Nullable<int> ID { get; set; }

        public string TopUpCode { get; set; }
        public string TopUpTypeCode { get; set; }
        public string ProviderID { get; set; }
        public string CardID { get; set; }
        public string AirlinesID { get; set; }
        public bool isActive { get; set; }
        public Nullable<DateTime> TopUpDate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
        public string TopUpTypeName { get; set; }

        public string ProviderName { get; set; }
        public string AirlinesName { get; set; }

    }
}