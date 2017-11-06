using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.UsersStat
{
    public class UsersStatOperateDTO
    {
        /// <summary>
        /// 用户统计ID
        /// </summary>
        public int? UsersStatID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserID { get; set; }
        /// <summary>
        /// 使用模块
        /// </summary>
        public string UseModel { get; set; }
        /// <summary>
        /// 进入模块时间
        /// </summary>
        public DateTime? UseModelTime { get; set; }
    }
}
