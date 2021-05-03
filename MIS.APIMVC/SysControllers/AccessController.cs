using MIS.BusinessService.SysService;
using MIS.Data.SysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MIS.APIMVC.SysControllers
{
    [EnableCors("*", "*", "*")]
    public class AccessController : ApiController
    {
        public AccessService service = new AccessService();

        [HttpGet]
        [Route("~/api/system/user/access/save/update/{employeecode}/{accesstype}/{menuID}/{accessID}/{entryBy}")]
        public HttpResponseMessage saveUpdateUserAccess(string employeecode, bool accesstype, int menuID, int accessID, string entryBy)
        {
            return MISResponse.Return(service.saveUpdateUserAccess(employeecode, accesstype, menuID, accessID, entryBy), service.Error, Request);
        }

        // GET: Access
        [HttpGet]
        [Route("~/api/system/user/all/access/list/{EmployeeCode}")]
        public HttpResponseMessage getApplicationAccessListByUser(string EmployeeCode)
        {
            return MISResponse.Return(service.getAllMenuAccessListByUser(EmployeeCode), service.Error, Request);

            //return MISResponse.Return(service.getApplicationMenuAccessListByUser(EmployeeCode), service.Error, Request);
        }
    }
}