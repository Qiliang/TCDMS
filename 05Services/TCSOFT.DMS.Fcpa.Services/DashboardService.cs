using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Fcpa.DTO.Dashboard;
using TCSOFT.DMS.Fcpa.IServices;

namespace TCSOFT.DMS.Fcpa.Services
{
    public class DashboardService: BaseService,IDashboardService
    {
        public IEnumerable<DashboardResultDTO> GetDashboard(int year)
        {
            return fcpa.fcpa_CredentialInfo//.Where(p => p.UpdateDate.Value.Year == year)
                .GroupBy(p => p.Status).ToList().Select(p => new DashboardResultDTO { Count = p.Count(), Status = Const.Status(p.Key.Value) });
        }
    }
}
