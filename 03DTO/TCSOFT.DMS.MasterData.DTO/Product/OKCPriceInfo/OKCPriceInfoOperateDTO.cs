using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Product.OKCPriceInfo
{
    using MasterData.DTO.Common;
    public class OKCPriceInfoOperateDTO:OperateDTO
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
        /// OKC产品
        /// </summary>
        public List<OKCProductOperate> ProductOKC { get; set; }
        /// <summary>
        /// OKC经销商
        /// </summary>
        public List<OKCDistributorOperate> DistributorOKC { get; set; }
        /// <summary>
        /// 产品特价ID
        /// </summary>
        public int? ProductOKCPriceInfoID { get; set; }
        /// <summary>
        /// OKC经销商ID
        /// </summary>
        public int? DistributorOKCID { get; set; }
        /// <summary>
        /// 旧货号
        /// </summary>
        public string OldArtNo { get; set; }
        /// <summary>
        /// 旧OKC价格
        /// </summary>
        public decimal? OldOKCPrice { get; set; }
        /// <summary>
        /// 新货号
        /// </summary>
        public string NewArtNo { get; set; }
        /// <summary>
        /// /// <summary>
        /// 新OKC价格
        /// </summary>
        /// </summary>
        public decimal? NewOKCPrice { get; set; }
        /// <summary>
        /// 新增状态(1、新增OKC号 2、新增OKC产品特价 3、新增经销商及最终客户)
        /// </summary>
        public short AddType { get; set; }
        /// <summary>
        /// 修改状态(1、修改OKC号 2、插入)
        /// </summary>
        public short UpType { get; set; }
        /// <summary>
        /// 删除状态(1、删除OKC号 2、删除OKC产品特价 3、删除经销商及最终客户)
        /// </summary>
        public short DelType { get; set; }
    }
    public class OKCProductOperate
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
        /// 产品OKC价格
        /// </summary>
        public decimal? ProductOKCPrice { get; set; }
    }
    public class OKCDistributorOperate
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
        /// 客户ID
        /// </summary>
        public Guid? CustomerID { get; set; }
    }
}
