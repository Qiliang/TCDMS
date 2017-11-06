using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterData.DTO.Payment;

namespace TCSOFT.DMS.MasterData.DTO.Distributor.DistributorAuthority
{
    public class DistributorAuthorityResultDTO
    {
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
        /// <summary>
        /// 经销商Name
        /// </summary>
        public string DistributorName { get; set; }
        /// <summary>
        /// 是否拥有订货权限
        /// </summary>
        public bool? IsOrderGoods { get; set; }
        /// <summary>
        /// 经销商付款条款
        /// </summary>
        //public List<DistributorPaymentResultDTO> Paylist { get; set; }
        /// <summary>
        /// 经销商运输方式
        /// </summary>
        //public List<DistributorTransportResultDTO> Transportlist { get; set; }
        /// <summary>
        /// 授权产品线
        /// </summary>
        //public List<DistributorProductLineResultDTO> ProductLineRegion { get; set; }
    }
    public class DistributorPaymentResultDTO
    {
        /// <summary>
        /// 经销商付款条款ID
        /// </summary>
        public int DistributorPayID { get; set; }
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
        /// <summary>
        /// 付款条款ID
        /// </summary>
        public int PayID { get; set; }
        /// <summary>
        /// 付款条款Name
        /// </summary>
        public string PayName { get; set; }
    }
    public class DistributorTransportResultDTO
    {
        /// <summary>
        /// 经销商运输方式ID
        /// </summary>
        public int DistributorTransportID { get; set; }
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
        /// <summary>
        /// 运输方式ID
        /// </summary>
        public int TransportID { get; set; }
        /// <summary>
        /// 运输方式
        /// </summary>
        public string TransportName { get; set; }
    }
    public class DistributorProductLineResultDTO
    {
        /// <summary>
        /// 经销商授权产品线ID
        /// </summary>
        public int DistributorProductLineID { get; set; }
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
        /// <summary>
        /// 授权产品线ID
        /// </summary>
        public int ProductLineID { get; set; }
        /// <summary>
        /// 授权产品线Name
        /// </summary>
        public string ProductLineName { get; set; }
        /// <summary>
        /// 授权产品线部门
        /// </summary>
        public string DepartName { get; set; }
        /// <summary>
        /// 授权区域
        /// </summary>
        //public List<DistributorRegionResultDTO> Region { get; set; }
    }
    public class DistributorRegionResultDTO 
    {
        /// <summary>
        /// 经销商授权区域流水ID
        /// </summary>
        public int? DistributorRegionID { get; set; }
        /// <summary>
        /// 经销商授权产品ID
        /// </summary>
        public int? DistributorProductLineID { get; set; }
        /// <summary>
        /// 区域ID
        /// </summary>
        public int? RegionID { get; set; }
        /// <summary>
        /// 区域Name
        /// </summary>
        public string RegionName { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DepartID { get; set; }
        /// <summary>
        /// 部门Name
        /// </summary>
        public string DepartName { get; set; }
        /// <summary>
        /// 大区ID
        /// </summary>
        public int? AreaID { get; set; }
        /// <summary>
        /// 大区
        /// </summary>
        public string LargeAreaName { get; set; }
        /// <summary>
        /// 小区ID
        /// </summary>
        public int? DistrictID { get; set; }
        /// <summary>
        /// 小区
        /// </summary>
        public string SmallAreaName { get; set; }
    }
}
