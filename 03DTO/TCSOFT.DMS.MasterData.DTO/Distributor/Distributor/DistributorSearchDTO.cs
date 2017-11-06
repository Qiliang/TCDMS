using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.MasterData.DTO.Common;

namespace TCSOFT.DMS.MasterData.DTO.Distributor.Distributor
{
    public class DistributorSearchDTO : PagingDTO
    {
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
        /// <summary>
        /// 模糊查询
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// 经销商服务类型ID
        /// </summary>
        public int? DistributorServiceTypeID { get; set; }
        /// <summary>
        /// 经销商类别ID
        /// </summary>
        public int? DistributorTypeID { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsActive { get; set; }
    }
}
