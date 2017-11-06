using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.CustomerAudit
{
    public class CustomerAuditResultDTO
    {
        /// <summary>
        /// 客户申请ID
        /// </summary>
        public Guid? CustomerApplyID { get; set; }
        /// <summary>
        /// 经销商ID
        /// </summary>
        public Guid? DistributorID { get; set; }
        /// <summary>
        /// 经销商名称
        /// </summary>
        public string DistributorName { get; set; }
        /// <summary>
        /// 申请客户名
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
        /// 审核状态
        /// </summary>
        public short? Status { get; set; }
    }
}
