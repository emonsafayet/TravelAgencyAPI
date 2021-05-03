using MIS.BusinessService.SysService;
using MIS.Data.SysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MIS.APIMVC.SysControllers
{
    public class SettingController : ApiController
    {
        public SettingsService service = new SettingsService();


        [HttpGet]
        [Route("~/api/system/table/type/list")]
        public HttpResponseMessage getTableTypeList()
        {
            return MISResponse.Return(service.getTableTypeList(), service.Error, Request);
        }

                

        [HttpGet]
        [Route("~/api/system/signature/list")]
        public HttpResponseMessage getSignatureList()
        {
            return MISResponse.Return(service.getSignatureList(), service.Error, Request);
        }

        [HttpPost]
        [Route("~/api/system/signature/save/update")]
        public HttpResponseMessage saveUpdateSignature(signature signature)
        {
            return MISResponse.Return(service.saveUpdateSignature(signature), service.Error, Request);
        }
    }
}
