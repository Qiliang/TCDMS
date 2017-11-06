using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.Fcpa.Services.Jobs;

namespace TCSOFT.DMS.FpcaAPI.Jobs
{
    public class JobRegistry: Registry
    {
        public JobRegistry()
        {
            Schedule<DistributorJob>().ToRunNow().AndEvery(1).Minutes();
            Schedule<UserJob>().ToRunNow().AndEvery(1).Minutes();
            Schedule<StatusJob>().ToRunNow().AndEvery(3).Minutes();
            Schedule<OrgJob>().ToRunNow().AndEvery(3).Minutes();
            Schedule<AlermJob>().ToRunNow().AndEvery(3).Minutes();
        }
    }
}