using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Dto.Report
{
    public class ReportParamDto
    {
        public string FromDate { get; set; }
	    public string ToDate { get; set; }
        public string ReportName { get; set; }
        public string Code { get; set; }
    }
}
