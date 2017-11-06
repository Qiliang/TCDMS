using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCSOFT.DMS.WebMain.Filter;

namespace TCSOFT.DMS.WebMain.Areas.Fcpa.Controllers
{
    public class MainController : Controller
    {
        [AuthorityFilter]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult Certificate()
        {
            return View();
        }

        public ActionResult Remind()
        {
            return View();
        }

        public ActionResult Branch()
        {
            return View();
        }

    }
}