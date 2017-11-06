using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Payment
{
    using DTO.Common;
    public class PaymentOperateDTO:OperateDTO
    {
        /// <summary>
        /// 付款条款ID
        /// </summary>
        public int? PayID { get; set; }
        /// <summary>
        /// 付款条款名称
        /// </summary>
        public string PayName { get; set; }
        /// <summary>
        /// OracleName
        /// </summary>
        public string OracleName { get; set; }
        /// <summary>
        /// 付款条款开始时间
        /// </summary>
        public DateTime? PayStartTime { get; set; }
        /// <summary>
        /// 付款条款结束时间
        /// </summary>
        public DateTime? PayEndTime { get; set; }
        /// <summary>
        /// 付款条款启用状态
        /// </summary>
        public bool? PayStatus { get; set; }
        /// <summary>
        /// 修改类型（1.修改 2.停启用）
        /// </summary>
        public int? UpType { get; set; }
    }
}
