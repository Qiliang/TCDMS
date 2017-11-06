using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.ReagentInfo
{
    using MasterData.DTO.Common;
    public class ReagentInfoOperateDTO:ProductDTO
    {
        /// <summary>
        /// 规格
        /// </summary>
        public string ReagentSize { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        public string ReagentProject { get; set; }
        /// <summary>
        /// 测试数
        /// </summary>
        public string ReagentTest { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string ReagentDes { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// 修改类型（1。修改 2 停启用）
        /// </summary>
        public int? UpType { get; set; }
    }
}
