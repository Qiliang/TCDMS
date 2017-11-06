using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.ProductSmallType
{
    public class ProductSmallTypeBaseDTO
    {
        /// <summary>
        /// 产品小类ID
        /// </summary>
        public int? ProductSmallTypeID { get; set; }
        /// <summary>
        /// 产品小类名
        /// </summary>
        public string ProductSmallTypeName { get; set; }
    }
}
