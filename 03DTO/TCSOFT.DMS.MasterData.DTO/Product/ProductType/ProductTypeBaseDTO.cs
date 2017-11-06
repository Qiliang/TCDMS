using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.ProductType
{
    public class ProductTypeBaseDTO
    {
        /// <summary>
        /// 产品类型ID
        /// </summary>
        public int? ProductTypeID { get; set; }
        /// <summary>
        /// 产品类型名
        /// </summary>
        public string ProductTypeName { get; set; }
    }
}
