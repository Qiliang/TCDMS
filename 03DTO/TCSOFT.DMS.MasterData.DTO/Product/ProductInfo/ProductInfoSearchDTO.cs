using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.MasterData.DTO.Common;

namespace TCSOFT.DMS.MasterData.DTO.Product.ProductInfo
{
    public class ProductInfoSearchDTO:PagingDTO
    {
        /// <summary>
        /// 模糊查询条件
        /// </summary>
        public string  SearchText { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        public Guid? ProductID { get; set; }
        /// <summary>
        /// 产品线ID
        /// </summary>
        public int? ProductLineID { get; set; }
    }
}
