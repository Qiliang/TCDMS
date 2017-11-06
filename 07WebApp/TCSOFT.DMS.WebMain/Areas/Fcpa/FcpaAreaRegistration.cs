using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCSOFT.DMS.WebMain.Areas.Fcpa
{ 

    public class FcpaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Fcpa";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Fcpa_default",
                "Fcpa/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}