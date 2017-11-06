using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.MasterData.DTO.Common;

namespace TCSOFT.DMS.MasterData.DTO.User
{
    public class UsersByAuthoritedResultDTO
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 模块ID
        /// </summary>
        public string StructureID { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string StructureName { get; set; }
    }

    public class UsersByAuthoritedSearchDTO : PagingDTO
    {
        /// <summary>
        /// 申请用户ID
        /// </summary>
        public int intApplyid { get; set; }
        /// <summary>
        /// 经销商ID
        /// </summary>
        public string DistributorID { get; set; }
        /// <summary>
        /// 角色IDlist
        /// </summary>
        public List<int?> RoleIDlist { get; set; }
        /// <summary>
        /// 申请权限
        /// </summary>
        public List<UserApplyAuthority> ApplyUserAuthority { get; set; }
    }
    public class UserApplyAuthority
    {
        /// <summary>
        /// 结构ID
        /// </summary>
        public string StructureID { get; set; }
        /// <summary>
        /// 申请所属按钮权限
        /// </summary>
        public int AppyUserButtonAuthority { get; set; }
    }
}
