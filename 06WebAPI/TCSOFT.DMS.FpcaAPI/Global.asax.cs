using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using TCSOFT.DMS.FpcaAPI.Jobs;

namespace TCSOFT.DMS.FpcaAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            JobManager.Initialize(new JobRegistry());
        }
    }
}
