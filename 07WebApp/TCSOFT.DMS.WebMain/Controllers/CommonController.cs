using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCSOFT.DMS.WebMain.Controllers
{
    using Models.Provider;
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult NoAuthorityInfo()
        {
            return View();
        }

        public ActionResult GetDistributorBaseInfo(string q)
        {
            return Json(CommonProvider.GetDistributorBaseInfoByName(q));
        }
    }
}