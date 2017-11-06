using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.ReagentInfo
{
    public class ReagentInfoResultDTO : ProductDTO
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
        /// 是否启用字符串
        /// </summary>
        public string IsActiveStr
        {
            get
            {
                var result = "停用";
                if (IsActive == true)
                {
                    result = "启用";
                }
                return result;
            }
        }
        /// <summary>
        /// 产品类型名
        /// </summary>
        public string ProductTypeName { get; set; }
        /// <summary>
        /// 产品线名称
        /// </summary>
        public string ProductLineName { get; set; }
    }
}
