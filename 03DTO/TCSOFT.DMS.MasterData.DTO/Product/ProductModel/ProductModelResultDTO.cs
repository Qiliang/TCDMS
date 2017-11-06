using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.ProductModel
{
    public class ProductModelResultDTO
    {
        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int ProductModelID { get; set; }
        /// <summary>
        /// 产品线ID
        /// </summary>
        public int? ProductLineID { get; set; }
        /// <summary>
        /// 产品线Name
        /// </summary>
        public string ProductLineName { get; set; }
        /// <summary>
        /// 产品型号名
        /// </summary>
        public string ProductModelName { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsActive { get; set; }
    }
}
