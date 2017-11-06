using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Fcpa.DTO.Dashboard;
using TCSOFT.DMS.Fcpa.IServices;
using TCSOFT.DMS.Fcpa.Services;

namespace TCSOFT.DMS.FpcaAPI.Controllers
{
    [RoutePrefix("api/Dashboard")]
    public class DashboardController : ApiController
    {
        IDashboardService _DashboardService = new DashboardService();
        [Route("GetDashboard"), HttpGet]
        public IEnumerable<DashboardResultDTO> GetDashboard(int year)
        {
            return _DashboardService.GetDashboard(year);
        }
    }
}
