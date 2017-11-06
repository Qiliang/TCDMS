using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Distributor.Distributor
{
    using DTO.Common;
    public class DistributorOperateDTO:OperateDTO
    {
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
        /// <summary>
        /// 经销商服务类型ID
        /// </summary>
        public int? DistributorServiceTypeID { get; set; }
        /// <summary>
        /// 经销商类别ID
        /// </summary>
        public int? DistributorTypeID { get; set; }
        /// <summary>
        /// 注册省份ID
        /// </summary>
        public int? RegionID { get; set; }
        /// <summary>
        /// 经销商编号
        /// </summary>
        public string DistributorCode { get; set; }
        /// <summary>
        /// 经销商名
        /// </summary>
        public string DistributorName { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// 停用时间
        /// </summary>
        public DateTime? NoActiveTime { get; set; }
        /// <summary>
        /// 停用原因
        /// </summary>
        public string NoActiveReason { get; set; }
        /// <summary>
        /// 发票地址编号
        /// </summary>
        public string InvoiceCode { get; set; }
        /// <summary>
        /// 送货地址编号
        /// </summary>
        public string DeliverCode { get; set; }
        /// <summary>
        /// CSR用户名(试剂)
        /// </summary>
        public string CSRNameReagent { get; set; }
        /// <summary>
        /// CSR用户名(维修D部)
        /// </summary>
        public string CSRNameD { get; set; }
        /// <summary>
        /// CSR用户名(维修B部)
        /// </summary>
        public string CSRNameB { get; set; }
        /// <summary>
        /// 办事处
        /// </summary>
        public string Office { get; set; }
        /// <summary>
        /// 修改类型（1.修改 2.停启用）
        /// </summary>
        public int? UpType { get; set; }
    }
}
