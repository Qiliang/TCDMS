using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Distributor
{
    public class DistributorPriceAuthorityModel
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