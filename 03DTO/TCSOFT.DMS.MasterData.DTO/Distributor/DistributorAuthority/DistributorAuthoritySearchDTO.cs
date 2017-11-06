using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.MasterData.DTO.Common;

namespace TCSOFT.DMS.MasterData.DTO.Distributor.DistributorAuthority
{
    public class DistributorAuthoritySearchDTO : PagingDTO
    {
        /// <summary>
        /// 模糊查询条件
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
        /// <summary>
        /// 经销商授权产品线ID
        /// </summary>
        public int? DistributorProductID { get; set; }
    }
}
