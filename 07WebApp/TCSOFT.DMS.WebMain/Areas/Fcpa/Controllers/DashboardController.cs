using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCSOFT.DMS.WebMain.Areas.Fcpa.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.Fcpa.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Fcpa/Dashboard
        public ActionResult GetDashboard(int year)
        {
            var result = DashboardProvider.GetDashboard(year);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}