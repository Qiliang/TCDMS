using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.CustomerAudit
{
    using TCSOFT.DMS.MasterData.DTO.Common;
    public class CustomerAuditOperateDTO:OperateDTO
    {
        /// <summary>
        /// 客户申请ID
        /// </summary>
        public Guid? CustomerApplyID { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public short? Status { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? AuditTime { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string Auditor { get; set; }
        /// <summary>
        /// 审核拒绝原因
        /// </summary>
        public string AuditReason { get; set; }
    }
}
