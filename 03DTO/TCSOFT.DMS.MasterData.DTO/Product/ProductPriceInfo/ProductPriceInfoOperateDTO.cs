using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.ProductPriceInfo
{
    using MasterData.DTO.Common;
    public class ProductPriceInfoOperateDTO : OperateDTO
    {
        /// <summary>
        /// 产品价格ID
        /// </summary>
        public int? ProductPriceID { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        public Guid? ProductID { get; set; }
        /// <summary>
        /// DNP价格
        /// </summary>
        public decimal? DNPPrice { get; set; }
        /// <summary>
        /// DNP价格开始日期
        /// </summary>
        public DateTime? DNPPriceStart { get; set; }
        /// <summary>
        /// DNP价格结束日期
        /// </summary>
        public DateTime? DNPPriceEnd { get; set; }
    }
}
