using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Role
{
    public class RoleResultDTO
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int? RoleID { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 角色说明
        /// </summary>
        public string RoleIntroduction { get; set; }
        /// <summary>
        /// 启用状态
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// 角色类型
        /// </summary>
        public short? RoleType { get; set; }
        /// <summary>
        /// 角色类型字符串
        /// </summary>
        public string RoleTypeStr
        {
            get
            {
                var result = string.Empty;
                if (RoleType == 0)
                {
                    result = "系统管理员";
                }
                if (RoleType == 1)
                {
                    result = "贝克曼";
                }
                if (RoleType == 2)
                {
                    result = "经销商";
                }

                return result;
            }
        }
        /// <summary>
        /// 角色权限
        /// </summary>
        public List<RoleAuthorityDTO> RoleAuthority { get; set; }
    }
}
