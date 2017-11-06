using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.MasterData.DTO.Product.OKCPriceInfo;

namespace TCSOFT.DMS.MasterData.DTO.Distributor.DistributorPriceAuthority
{
    public class DistributorOKCProduct
    {
        public int DistributorOKCID { get; set; }
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
    }
}
