using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.ProductLine
{
    public class ProductLineResultDTO
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
        /// 部门Name
        /// </summary>
        public string DepartName { get; set; }
        /// <summary>
        /// 仪器类型ID
        /// </summary>
        public int? InstrumentTypeID { get; set; }
        /// <summary>
        /// 仪器类型Name
        /// </summary>
        public string InstrumentTypeName { get; set; }
        /// <summary>
        /// 产品类型ID
        /// </summary>
        public int? ProductTypeID { get; set; }
        /// <summary>
        /// 产品类型Name
        /// </summary>
        public string ProductTypeName { get; set; }
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
    }
}
