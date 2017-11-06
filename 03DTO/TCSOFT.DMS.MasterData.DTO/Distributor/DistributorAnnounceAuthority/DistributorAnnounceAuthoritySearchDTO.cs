using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Distributor.DistributorAnnounceAuthority
{
    using TCSOFT.DMS.MasterData.DTO.Common;
    public class DistributorAnnounceAuthoritySearchDTO:PagingDTO
    {
        /// <summary>
        /// 模糊查询
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
    }
}
