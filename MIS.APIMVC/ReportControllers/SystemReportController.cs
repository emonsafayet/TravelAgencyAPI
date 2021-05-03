using Microsoft.Reporting.WebForms;
using MIS.BusinessService.ReportService;
using MIS.BusinessService.SysService;
using MIS.Data.Repositories;
using MIS.Data.SysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS.APIMVC.ReportControllers
{
    public class SystemReportController : Controller
    {
        public UserService userService = new UserService();
        public AccessService accessService = new AccessService();
        public MenuService menuService = new MenuService();
        public RoleServices roleService = new RoleServices();


       
        //[ActionName("system/user/role/list")]
        public ActionResult UserRoleList()
        {
            var RoleList = roleService.getRoleList();
            ReportViewer rptViewer = new ReportViewer();
            List<ReportParameter> parameters = new List<ReportParameter>();

            parameters.Add(new ReportParameter("Param1", "Param1 Value"));
            parameters.Add(new ReportParameter("Param2", "Param2 value"));

            rptViewer.ProcessingMode = ProcessingMode.Local;
            rptViewer.Width = 100;
            rptViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/MIS/UserRoleRpt.rdlc");

            rptViewer.LocalReport.EnableExternalImages = true;
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("SPResults", RoleList));

            rptViewer.LocalReport.SetParameters(parameters);
            rptViewer.LocalReport.Refresh();
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            byte[] bytes = rptViewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            return File(bytes, "application/pdf");
        }
       
    }
}