using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.SysManage
{
    public class signatureDto  
    {
        public Nullable<int> ID { get; set; }
        public string KeyID { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public Nullable<int> NoOfDigit { get; set; }
        public string DBName { get; set; }
        public string TableType { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string InitialCode { get; set; }
        public string CriteriaColumn { get; set; }
        public string ExtraCondition { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class SignatureResultDto
    {
        public string NewGeneratedID { get; set; }
    }
}
