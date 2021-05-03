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
    public class MenuController : ApiController
    {
        public MenuService service = new MenuService();

        //save
        [HttpPost]
        [Route("~/api/system/menu/save/update")]
        public HttpResponseMessage saveUpdateRole(Menu menu)
        {
            return MISResponse.Return(service.saveUpdateMenu(menu), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/system/application/list")]
        public HttpResponseMessage getApplicationList()
        {
            return MISResponse.Return(service.GetApplicationList(), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/system/check/user/menu/permission/")]
        public HttpResponseMessage IsUserHasMenuPermission(IpInfoDto ipInfoDto)
        {
            return MISResponse.Return(service.IsUserHasMenuPermission(ipInfoDto), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/system/all/menu/list/")]
        public HttpResponseMessage GetAllMenuList()
        {
            return MISResponse.Return(service.GetAllMenuList(), service.Error, Request);
        }

        [HttpGet]
        [Route("~/api/system/user/menu/list/{empcode}")]
        public HttpResponseMessage getUserMenuList(string empcode)
        {
            return MISResponse.Return(service.GetUserMenuList(empcode), service.Error, Request);
        }
    }
}