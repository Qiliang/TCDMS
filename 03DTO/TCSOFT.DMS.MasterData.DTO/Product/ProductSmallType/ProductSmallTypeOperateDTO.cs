using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.ProductSmallType
{
    using DTO.Common;
    public class ProductSmallTypeOperateDTO : OperateDTO
    {
        /// <summary>
        /// 产品小类ID
        /// </summary>
        public int ProductSmallTypeID { get; set; }
        /// <summary>
        /// 产品线ID
        /// </summary>
        public int ProductLineID { get; set; }
        /// <summary>
        /// 产品小类名
        /// </summary>
        public string ProductSmallTypeName { get; set; }
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
