using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.ProductLine
{
    using DTO.Common;
    public class ProductLineOperateDTO : OperateDTO
    {
        /// <summary>
        /// 产品线ID
        /// </summary>
        public int ProductLineID { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DepartID { get; set; }
        /// <summary>
        /// 仪器类型ID
        /// </summary>
        public int? InstrumentTypeID { get; set; }
        /// <summary>
        /// 产品类型ID
        /// </summary>
        public int? ProductTypeID { get; set; }
        /// <summary>
        /// 产品线名称
        /// </summary>
        public string ProductLineName { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// 产品线缩写
        /// </summary>
        public string ProductLineNameAB { get; set; }
        /// <summary>
        /// 修改状态
        /// </summary>
        public int UpType { get; set; }
    }
}
