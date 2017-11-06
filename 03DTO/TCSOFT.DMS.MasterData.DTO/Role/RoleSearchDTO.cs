using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Role
{
    public class RoleSearchDTO
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int? RoleID { get; set; }
        /// <summary>
        /// 角色类型ID
        /// </summary>
        public int? RoleType { get; set; }
        /// <summary>
        /// 模糊查询
        /// </summary>
        public string SearchText { get; set; }
    }
}
