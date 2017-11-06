using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.Fcpa.DTO;
using TCSOFT.DMS.Fcpa.DTO.Credential;
using TCSOFT.DMS.Fcpa.DTO.Dashboard;
using TCSOFT.DMS.Fcpa.DTO.Fcpa;
using TCSOFT.DMS.WebMain.Common;
using TCSOFT.DMS.WebMain.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.Fcpa.Models.Provider
{
    public class DashboardProvider : BaseProvider
    {
        public static IEnumerable<DashboardResultDTO> GetDashboard(int year)
        {
            return GetAPI<IEnumerable<DashboardResultDTO>>(WebConfiger.FcpaServicesUrl + "Dashboard/GetDashboard?year=" + year);
        }
    }
}