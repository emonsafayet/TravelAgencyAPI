using MIS.BusinessService.SysService;
using MIS.Data.SysModels;
using MIS.Dto.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MIS.APIMVC.SysControllers
{
    public class RolesController : ApiController
    {
        public RoleServices service = new RoleServices();

        [HttpGet]
        [Route("~/api/system/role/list")]
        public HttpResponseMessage getRoleList()
        {
            return MISResponse.Return(service.getRoleList(), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/system/role/save/update")]
        public HttpResponseMessage saveUpdateRole(Role role)
        {
            return MISResponse.Return(service.saveUpdateRole(role), service.Error, Request);
        }
    }
}