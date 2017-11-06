using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.MaintenanceInfo
{
    public class MaintenanceInfoOperateDTO : ProductDTO
    {
        /// <summary>
        /// 是否3C产品
        /// </summary>
        public bool? Is3C { get; set; }
        /// <summary>
        /// 中文描述及备注
        /// </summary>
        public string MaintenanceRemark { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// 修改状态
        /// </summary>
        public int UpType { get; set; }
    }
}
