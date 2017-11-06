using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.MasterData.DTO.Common;

namespace TCSOFT.DMS.MasterData.DTO.Product.OKCPriceInfo
{
    public class OKCPriceInfoSearchDTO : PagingDTO
    {
        /// <summary>
        /// OKCID
        /// </summary>
        public int? OKCID { get; set; }
        /// <summary>
        /// 模糊查询
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// 产品线ID
        /// </summary>
        public int? ProductLineID { get; set; }
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
    }
}
