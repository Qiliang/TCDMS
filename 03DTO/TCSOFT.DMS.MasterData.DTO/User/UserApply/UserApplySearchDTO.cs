using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.User.UserApply
{
    public class UserApplySearchDTO
    {
        /// <summary>
        /// 模糊查询
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// 当前用户角色ID
        /// </summary>
        public List<int?> RoleIDlist { get; set; }
    }
}
