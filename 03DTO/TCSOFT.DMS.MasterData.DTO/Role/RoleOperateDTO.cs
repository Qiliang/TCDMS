using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Role
{
    public class RoleOperateDTO
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
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        public string ModifyUser { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }
        /// <summary>
        /// 角色权限
        /// </summary>
        public List<RoleAuthorityDTO> RoleAuthority { get; set; }
    }
    public class RoleAuthorityDTO
    {
        /// <summary>
        /// 角色权限流水号
        /// </summary>
        public int? RoleAuthorityID { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID { get; set; }
        /// <summary>
        /// 结构ID
        /// </summary>
        public string StructureID { get; set; }
        /// <summary>
        /// 结构Name
        /// </summary>
        public string StructureName { get; set; }
        /// <summary>
        /// 所属按钮权限
        /// </summary>
        public int? RoleButtonAuthority { get; set; }
        
    }
}
