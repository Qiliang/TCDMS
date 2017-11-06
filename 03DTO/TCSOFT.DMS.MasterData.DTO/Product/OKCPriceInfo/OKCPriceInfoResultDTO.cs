using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.MasterData.DTO.Distributor.Distributor;
using TCSOFT.DMS.MasterData.DTO.Product.ProductInfo;
using TCSOFT.DMS.MasterData.DTO.Product.ProductPriceInfo;

namespace TCSOFT.DMS.MasterData.DTO.Product.OKCPriceInfo
{
    public class OKCPriceInfoResultDTO
    {
        /// <summary>
        /// OKCID
        /// </summary>
        public int? OKCID { get; set; }
        /// <summary>
        /// OKC编号
        /// </summary>
        public string OKCNO { get; set; }
        /// <summary>
        /// OKC开始日期
        /// </summary>
        public DateTime? OKCStart { get; set; }
        /// <summary>
        /// OKC结束日期
        /// </summary>
        public DateTime? OKCEnd { get; set; }
        /// <summary>
        /// OKC产品列表
        /// </summary>
        //public List<OKCProductResult> OKCProductList { get; set; }
        /// <summary>
        /// OKC经销商及最终客户
        /// </summary>
        //public List<OKCDistributorResult> OKCDistributorList { get; set; }
    }
    public class OKCProductResult
    {
        /// <summary>
        /// 产品特价ID
        /// </summary>
        public int? ProductOKCPriceInfoID { get; set; }
        /// <summary>
        /// OKCID
        /// </summary>
        public int? OKCID { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        public Guid? ProductID { get; set; }
        /// <summary>
        /// 货号
        /// </summary>
        public string ArtNo { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 产品线Name
        /// </summary>
        public string ProductLineName { get; set; }
        /// <summary>
        /// 产品OKC价格
        /// </summary>
        public decimal? ProductOKCPrice { get; set; }
    }
    public class OKCDistributorResult
    {
        /// <summary>
        /// OKC经销商ID
        /// </summary>
        public int? DistributorOKCID { get; set; }
        /// <summary>
        /// OKCID
        /// </summary>
        public int? OKCID { get; set; }
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
        /// <summary>
        /// 经销商Name
        /// </summary>
        public string DistributorName { get; set; }
        /// <summary>
        /// 客户ID
        /// </summary>
        public Guid? CustomerID { get; set; }
        /// <summary>
        /// 客户Name
        /// </summary>
        public string CustomerName { get; set; }
    }
}
