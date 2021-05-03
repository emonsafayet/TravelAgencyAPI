using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto
{
    public abstract class BaseEntityDTO
    {
        public Nullable<int> ID { get; set; }
        public string CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }

        public string Remarks { get; set; }


        public string Location { get; set; }
        public string MachineNameIP { get; set; }
        public Nullable<Boolean> Transfered { get; set; }
        public Nullable<Boolean> HoTransfered { get; set; }

        public string Addedby { get; set; }
        public Nullable<DateTime> DateAdded { get; set; }

        public string UpdatedByID { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
    }

    public abstract class BaseEntity2DTO
    {
        public Nullable<int> ID { get; set; }
        public string Remarks { get; set; }
        public Nullable<Boolean> IsActive { get; set; }

        public Nullable<int> CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }

        public Nullable<int> UpdatedByID { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
    }

    public abstract class BaseEntityBusinessDTO
    {
        public Nullable<int> ID { get; set; } 
        public Nullable<Boolean> IsActive { get; set; }         
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }         
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
    }
}
