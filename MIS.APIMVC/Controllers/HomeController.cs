using MIS.BusinessService.SysService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS.APIMVC.Controllers
{
    public class HomeController : Controller
    {
        public MenuService service = new MenuService();

        public ActionResult register()
        {
            return View();
        }

        public ActionResult index()
        {
            return View();
        }
    }
}