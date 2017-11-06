using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCSOFT.DMS.WebMain.Areas.User.Controllers
{
    public class MainController : Controller
    {
        // GET: User/Main
        public ActionResult Index()
        {
            return View();
        }
    }
}