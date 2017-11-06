using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.MaintenanceInfo
{
    public class MaintenanceInfoResultDTO : ProductDTO
    {
        /// <summary>
        /// 是否3C产品
        /// </summary>
        public bool? Is3C { get; set; }
        /// <summary>
        /// 是否3C产品
        /// </summary>
        public string Is3Cstr
        {
            get
            {
                string isstr = string.Empty;

                if (Is3C == true)
                {
                    isstr = "是";
                }
                else
                {
                    isstr = "否";
                }

                return isstr;
            }
        }
        /// <summary>
        /// 中文描述及备注
        /// </summary>
        public string MaintenanceRemark { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public string IsActivestr
        {
            get
            {
                string isstr = string.Empty;

                if (IsActive == true)
                {
                    isstr = "启用";
                }
                else
                {
                    isstr = "停用";
                }

                return isstr;
            }
        }
        /// <summary>
        /// 产品类型名
        /// </summary>
        public string ProductTypeName { get; set; }
        /// <summary>
        /// 产品小类名
        /// </summary>
        public string ProductSmallTypeName { get; set; }
        /// <summary>
        /// 产品线名称
        /// </summary>
        public string ProductLineName { get; set; }
    }
}
