using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.ProductSmallType
{
    public class ProductSmallTypeResultDTO
    {
        /// <summary>
        /// 产品小类ID
        /// </summary>
        public int ProductSmallTypeID { get; set; }
        /// <summary>
        /// 产品线ID
        /// </summary>
        public int? ProductLineID { get; set; }
        /// <summary>
        /// 产品线Name
        /// </summary>
        public string ProductLineName { get; set; }
        /// <summary>
        /// 产品小类名
        /// </summary>
        public string ProductSmallTypeName { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsActive { get; set; }
    }
}
