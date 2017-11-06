using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Distributor.DistributorAuthority
{
    using DTO.Common;
    public class DistributorAuthorityOperateDTO : OperateDTO
    {
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
        /// <summary>
        /// 是否拥有订货权限
        /// </summary>
        public bool? IsOrderGoods { get; set; }
        /// <summary>
        /// 经销商付款条款ID
        /// </summary>
        public int? DistributorPayID { get; set; }
        /// <summary>
        /// 经销商运输方式ID
        /// </summary>
        public int? DistributorTransportID { get; set; }
        /// <summary>
        /// 经销商授权产品线ID
        /// </summary>
        public int? DistributorProductLineID { get; set; }
        /// <summary>
        /// 经销商授权产品线区域ID
        /// </summary>
        public int? DistributorRegionID { get; set; }
        /// <summary>
        /// 付款条款ID
        /// </summary>
        public List<int?> PayIDlist { get; set; }
        /// <summary>
        /// 运输方式ID
        /// </summary>
        public List<int> TransportIDlist { get; set; }
        /// <summary>
        /// 授权产品线及对应区域
        /// </summary>
        public List<DistributorProductLineOperateDTO> ProductLineRegion { get; set; }
        /// <summary>
        /// 新增状态(1、授权经销商付款条款 2、授权经销商运输方式 3、授权经销商产品线 4、授权经销商授权产品线区域)
        /// </summary>
        public short AddType { get; set; }
        /// <summary>
        /// 修改状态(1、修改订货权限)
        /// </summary>
        public short UpType { get; set; }
        /// <summary>
        /// 删除状态(1、删除经销商付款条款 2、删除经销商运输方式 3、删除经销商产品线 4、删除经销商授权产品线区域)
        /// </summary>
        public short DelType { get; set; }
    }
    public class DistributorProductLineOperateDTO
    {
        /// <summary>
        /// 经销商授权产品线ID
        /// </summary>
        public int DistributorProductLineID { get; set; }
        /// <summary>
        /// 授权产品线ID
        /// </summary>
        public int ProductLineID { get; set; }
        /// <summary>
        /// 授权区域
        /// </summary>
        public List<DistributorRegionOperateDTO> Regionlist { get; set; }
    }
    public class DistributorRegionOperateDTO
    {
        /// <summary>
        /// 区域ID
        /// </summary>
        public int? RegionID { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DepartID { get; set; }
        /// <summary>
        /// 大区ID
        /// </summary>
        public int? AreaID { get; set; }
        /// <summary>
        /// 小区ID
        /// </summary>
        public int? DistrictID { get; set; }
    }
}
