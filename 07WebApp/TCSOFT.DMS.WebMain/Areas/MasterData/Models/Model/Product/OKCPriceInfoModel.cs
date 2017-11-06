using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.MasterData.DTO.Product.OKCPriceInfo;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Product
{
    public class OKCPriceInfoModel : OKCPriceInfoOperateDTO
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public Guid? ProductID { get; set; }
        /// <summary>
        /// OKC价格
        /// </summary>
        public decimal? ProductOKCPrice { get; set; }
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
        /// <summary>
        /// 客户ID
        /// </summary>
        public Guid? CustomerID { get; set; }
    }
}