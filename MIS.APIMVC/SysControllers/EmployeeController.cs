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
    public class EmployeeController : ApiController
    {
        public EmployeeService service = new EmployeeService();

        //Employee List With Out User Account For User Menu
        [HttpGet]
        [Route("~/api/system/employee/list/without/user/account")]
        public HttpResponseMessage GetEmployeeListWithOutUserAccount()
        {
            return MISResponse.Return(service.GetEmployeeListWithOutUserAccount(), service.Error, Request);
        }

        //save
        [HttpPost]
        [Route("~/api/system/employee/save/update")]
        public HttpResponseMessage saveUpdateEmployee(Employee employee)
        {
            return MISResponse.Return(service.saveUpdateEmployee(employee), service.Error, Request);
        }

        //Designation
        //save Designation
        [HttpPost]
        [Route("~/api/system/employee/designation/save/update")]
        public HttpResponseMessage saveUpdateDesignation(EmployeeDesignation designation)
        {
            return MISResponse.Return(service.saveUpdateDesignation(designation), service.Error, Request);
        }

        //Get Employee List

        [HttpGet]
        [Route("~/api/system/employee/list")]
        public HttpResponseMessage getEmployeeList()
        {
            return MISResponse.Return(service.getEmployeeList(), service.Error, Request);
        }

        //Get Employee Designation

        [HttpGet]
        [Route("~/api/system/employee/designation/list")]
        public HttpResponseMessage getDesignationList()
        {
            return MISResponse.Return(service.getDesignationList(), service.Error, Request);
        }

        //Get Employee Department

        [HttpGet]
        [Route("~/api/system/employee/department/list")]
        public HttpResponseMessage getDepartmentList()
        {
            return MISResponse.Return(service.getDepartmentList(), service.Error, Request);
        }
        //Get Employee Type

        [HttpGet]
        [Route("~/api/system/employee/type/list")]
        public HttpResponseMessage getemployeeTypeList()
        {
            return MISResponse.Return(service.getEmployeeTypeList(), service.Error, Request);
        }

        //Get EmployeeStatus

        [HttpGet]
        [Route("~/api/system/employee/status/list")]
        public HttpResponseMessage getemployeeStatusList()
        {
            return MISResponse.Return(service.getEmployeeStatusList(), service.Error, Request);
        }

       
       

    }
}
