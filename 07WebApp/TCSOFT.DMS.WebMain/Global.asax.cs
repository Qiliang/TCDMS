using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TCSOFT.DMS.WebMain
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Common.EmailHelper.InnitEmailServer(Common.WebConfiger.EmailServer, int.Parse(Common.WebConfiger.EmailPort), Common.WebConfiger.EmailAccount, Common.WebConfiger.EmailAmtPassword);
            Common.AboutWebSiteHelper.Init(Server.MapPath(@"\AboutWebSite.xml"));
            string strLogPath = Server.MapPath("~/Log");
            if (!System.IO.Directory.Exists(strLogPath))
            {
                System.IO.Directory.CreateDirectory(strLogPath);
            }
            Common.Logger.Init(strLogPath + @"/dmslog.txt");
        }
    }
}
