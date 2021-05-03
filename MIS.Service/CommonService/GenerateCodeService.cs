using MIS.Data.ClientModel;
using MIS.Data.Repositories;
using MIS.Dto.SysManage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BusinessService.CommonService
{
    public class GenerateCodeService
    {
        public Exception Error = new Exception();      

        public string  GenerateAutoCode(string key,string tranDate)
        {
            string code = "";

            if (key != "" || key != null) {
                SignatureResultDto c = new SysManageGenericRepository<SignatureResultDto>().FindOneUsingSP("spNewIDGeneration @KeyID, @TranDate", 
                    new SqlParameter("@KeyID", key), new SqlParameter("@TranDate", tranDate));

                code = c.NewGeneratedID;
            }         

            return code;
        }
       
    }
}
