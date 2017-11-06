using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Customer
{
    public class CustomerResultDTO
    {
        /// <summary>
        /// 客户ID
        /// </summary>
        public Guid? CustomerID { get; set; }
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
        /// <summary>
        /// 经销商名称
        /// </summary>
        public string DistributorName { get; set; }
        /// <summary>
        /// 客户名
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 县区
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Oracle号
        /// </summary>
        public string OracleNO { get; set; }
        /// <summary>
        /// OracleName
        /// </summary>
        public string OracleName { get; set; }
        /// <summary>
        /// XSW编号
        /// </summary>
        public string XSWNO { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// 停用原因
        /// </summary>
        public string NoActiveReason { get; set; }
        /// <summary>
        /// 停用时间
        /// </summary>
        public DateTime? NoActiveTime { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        public string ModifyUser { get; set; }
        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string Auditor { get; set; }
    }
}
