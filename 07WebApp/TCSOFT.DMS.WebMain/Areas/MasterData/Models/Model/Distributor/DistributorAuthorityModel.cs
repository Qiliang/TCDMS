using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorAuthority;
using TCSOFT.DMS.WebMain.Common;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Distributor
{
    public class DistributorAuthorityModel : DistributorAuthorityOperateDTO
    {
        /// <summary>
        /// 付款条款ID
        /// </summary>
        public List<int?> PayID { get; set; }
        /// <summary>
        /// 运输方式ID
        /// </summary>
        public int? TransportID { get; set; }
        /// <summary>
        /// 产品线ID
        /// </summary>
        public int? ProductLineID { get; set; }
        public string AuthorityRegion { get; set; }
        /// <summary>
        /// 授权区域ID
        /// </summary>
        public int? RegionID { get; set; }
        /// <summary>
        /// 授权部门ID
        /// </summary>
        public int? DepartID { get; set; }
        /// <summary>
        /// 授权大区ID
        /// </summary>
        public int? AreaID { get; set; }
        /// <summary>
        /// 授权小区ID
        /// </summary>
        public int? DistrictID { get; set; }
    }
}