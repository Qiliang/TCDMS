using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Payment
{
    public class PaymentResultDTO
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
        /// 付款条款开始时间
        /// </summary>
        public string PayStartTimeDes 
        {
            get
            {
                return PayStartTime == null ? String.Empty : PayStartTime.Value.ToString("yyyy-MM-dd");
            }
        }
        /// <summary>
        /// 付款条款结束时间
        /// </summary>
        public string PayEndTimeDes 
        {
            get
            {
                return PayEndTime == null ? String.Empty : PayEndTime.Value.ToString("yyyy-MM-dd");
            }
        }
        /// <summary>
        /// 付款条款启用状态
        /// </summary>
        public bool? PayStatus { get; set; }
        /// <summary>
        /// 付款条款启用状态字符串
        /// </summary>
        public string PayStatusStr
        {
            get
            {
                var result = "停用";
                if (PayStatus == true)
                {
                    result = "启用";
                }

                return result;
            }
        }
    }
}
