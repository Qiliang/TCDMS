using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.UsersStat
{
    using TCSOFT.DMS.MasterData.DTO.User;
    public class UsersStatResultDTO
    {
        /// <summary>
        /// 用户统计ID
        /// </summary>
        public int UsersStatID { get; set; }
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
        /// 使用模块
        /// </summary>
        public string UseModel { get; set; }
        /// <summary>
        /// 进入模块时间
        /// </summary>
        public DateTime? UseModelTime { get; set; }
    }
}
