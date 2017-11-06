using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Distributor.DistributorPriceAuthority
{
    public class DistributorPriceAuthorityOperateDTO
    {
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
        /// <summary>
        /// OKCID
        /// </summary>
        public int? OKCID { get; set; }
    }
}
