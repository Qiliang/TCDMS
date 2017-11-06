using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.MasterData.DTO.User;

namespace TCSOFT.DMS.MasterData.DTO.Message
{
    public class MessageResultDTO
    {
        /// <summary>
        /// 短信统计ID
        /// </summary>
        public int MessageStatID { get; set; }
        /// <summary>
        /// 部门Name
        /// </summary>
        public string DepartName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public short? UserType { get; set; }
        /// <summary>
        /// 用户经销商Name
        /// </summary>
        public string UserDistributorstr { get; set; }
        /// <summary>
        /// 短信类别
        /// </summary>
        public short MessageType { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime? SendTime { get; set; }
    }
}
