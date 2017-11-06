using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.MasterData.DTO.Common;

namespace TCSOFT.DMS.MasterData.DTO.Distributor.DistributorAnnounceAuthority
{
    public class DistributorAnnounceAuthorityOperateDTO :OperateDTO
    {
        /// <summary>
        /// 经销商名称
        /// </summary>
        public Guid? DistributorID { get; set; }
        /// <summary>
        /// 经销商名称
        /// </summary>
        public string DistributorName { get; set; }
        /// <summary>
        /// 产品线列表
        /// </summary>
        public List<int?> ProductLineIDList { get; set; }
    }
}
