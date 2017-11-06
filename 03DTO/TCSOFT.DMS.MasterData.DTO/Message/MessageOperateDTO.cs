using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Message
{
    public class MessageOperateDTO
    {
        /// <summary>
        /// 短信统计ID
        /// </summary>
        public int? MessageStatID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserID { get; set; }
        /// <summary>
        /// 短信类别
        /// </summary>
        public short? MessageType { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime? SendTime { get; set; }
    }
}
