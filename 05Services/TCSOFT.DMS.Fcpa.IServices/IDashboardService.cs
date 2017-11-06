using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Fcpa.DTO.Dashboard;

namespace TCSOFT.DMS.Fcpa.IServices
{
    public interface IDashboardService
    {
        IEnumerable<DashboardResultDTO> GetDashboard(int year);
    }
}
