using MIS.BusinessService.SysService;
using MIS.Data.SysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MIS.APIMVC.SysControllers
{
    [EnableCors("*", "*", "*")]
    public class UserController : ApiController
    {
        //user access will be in this controller
        public UserService service = new UserService();

        

        [HttpPost]
        [Route("~/api/system/user/save/update")]
        public HttpResponseMessage userSaveUpdate(UserTbl user)
        {
            return MISResponse.Return(service.userSaveUpdate(user), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/system/user/list")]
        public HttpResponseMessage getUserList()
        {
            return MISResponse.Return(service.getUserList(), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/system/user/detail/list")]
        public HttpResponseMessage getUserDetailList()
        {
            return MISResponse.Return(service.getUserDetailList(), service.Error, Request);
        }

        [Authorize]
        [HttpGet]
        [Route("api/user/session/validate")]
        public HttpResponseMessage validateUserSession()
        {
            return MISResponse.Return("success", service.Error, Request);
        }


        //User Access Type List
        [HttpGet]
        [Route("~/api/system/user/access/type/list")]
        public HttpResponseMessage getUserAccessTypeList()
        {
            return MISResponse.Return(service.getUserAccessTypeList(), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/system/user/access/type/save/update")]
        public HttpResponseMessage userAccessSaveUpdate(UserAccessType UserAccessType)
        {
            return MISResponse.Return(service.userSaveUpdateAccessType(UserAccessType), service.Error, Request);
        }
    }
}