using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.User
{
    using MasterData.DTO.Common;
    using MasterData.DTO.Role;
    using TCSOFT.DMS.MasterData.DTO.Distributor.Distributor;
    public class UserOperate : OperateDTO
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserID { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DepartID { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 动态密码
        /// </summary>
        public string DynamicPassword { get; set; }
        /// <summary>
        /// 密码有效时间
        /// </summary>
        public DateTime? EffectiveTtime { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public short? UserType { get; set; }
        /// <summary>
        /// 大区ID
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// 停用时间
        /// </summary>
        public DateTime? NoActiveTime { get; set; }
        /// <summary>
        /// 用户有效时间
        /// </summary>
        public DateTime? StopTime { get; set; }
        /// <summary>
        /// 用户权限
        /// </summary>
        public List<UserCustomerAuthority> UserAuthority { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public List<int?> UserRole { get; set; }
        /// <summary>
        /// 用户经销商
        /// </summary>
        public List<Guid?> UserDistributor { get; set; }
        /// <summary>
        /// 修改类型
        /// </summary>
        public int? Uptype { get; set; }
    }
    public class UserResultDTO
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserID { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DepartID { get; set; }
        /// <summary>
        /// 部门Name
        /// </summary>
        public string DepartName { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 动态密码
        /// </summary>
        public string DynamicPassword { get; set; }
        /// <summary>
        /// 密码有效时间
        /// </summary>
        public DateTime? EffectiveTtime { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 大区ID
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public short? UserType { get; set; }
        /// <summary>
        /// 用户类型Name
        /// </summary>
        public string UserTypeName 
        {
            get 
            {
                string result = string.Empty;
                if (UserType != null) 
                {
                    switch (UserType)
                    {
                        case 0:
                            result = "系统管理员";
                            break;
                        case 1:
                            result = "贝克曼";
                            break;
                        case 2:
                            result = "经销商";
                            break;
                    }
                }

                return result;
            }
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public string IsActivestr 
        {
            get 
            {
                string isactive = string.Empty;

                if (IsActive == true)
                {
                    if (StopTime == null)
                    {
                    isactive = "启用";
                }
                    else if (StopTime >= DateTime.Now)
                    {
                        isactive = "启用";
                    }
                else 
                {
                    isactive = "停用";
                }
                }
                else
                {
                    isactive = "停用";
                }

                return isactive;
            }
        }
        /// <summary>
        /// 停用时间
        /// </summary>
        public DateTime? NoActiveTime { get; set; }
        /// <summary>
        /// 用户有效时间
        /// </summary>
        public DateTime? StopTime { get; set; }
        /// <summary>
        /// 用户权限
        /// </summary>
        public List<StructureDTO> UserAuthority { get; set; }
        /// <summary>
        /// 角色IDlist
        /// </summary>
        public List<int?> UserRolelist { get; set; }
        /// <summary>
        /// 角色Namelist
        /// </summary>
        public List<string> UserRoleNamelist { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public string UserRoleName
        {
            get
            {
                string strrole = string.Empty;
                if (UserRoleNamelist != null)
                {
                    foreach (var ur in UserRoleNamelist)
                    {
                        strrole += ur + ",";
                    }
                }

                return strrole;
            }
        }
        /// <summary>
        /// 用户经销商ID
        /// </summary>
        public List<Guid?> UserDistributorid { get; set; }
        public List<string> UserDistributorNamelist { get; set; }
        /// <summary>
        /// 用户经销商Name
        /// </summary>
        public string UserDistributorstr
        {
            get
            {
                string strrole = string.Empty;
                if (UserDistributorNamelist != null)
                {
                    foreach (var ud in UserDistributorNamelist)
                    {
                        strrole += ud + ",";
                    }
                }

                return strrole;
            }
        }

        /// <summary>
        /// 客户管理员对应区域
        /// </summary>
        public string CusAdminAreaNames { get; set; }
    }
    public class UserSearchDTO : PagingDTO
    {
        /// <summary>
        /// 模糊查询
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DepartID { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public string DepartPath { get; set; }
        /// <summary>
        /// 用户类型ID
        /// </summary>
        public short? UserTypeID { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public List<int?> RoleIDlist { get; set; }
        /// <summary>
        /// 1:根据用户部门所对应的区域ID查询模块管理员
        /// 2:已有用户
        /// 3:停用用户
        /// </summary>
        public int QueryType { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserID { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public short? UserType { get; set; }
        /// <summary>
        /// 经销商ID
        /// </summary>
        public List<Guid?> DistributorIDList { get; set; }
        /// <summary>
        /// 用户最后登录时间
        /// </summary>
        public DateTime? EffectiveTtime { get; set; }
    }
    public class UserCustomerAuthority
    {
        /// <summary>
        /// 用户自定义权限流水号
        /// </summary>
        public int? UserCustomerAuthorityID { get; set; }
        /// <summary>
        /// 结构ID
        /// </summary>
        public string StructureID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserID { get; set; }
        /// <summary>
        /// 所属按钮权限
        /// </summary>
        public int UserButtonAuthority { get; set; }
    }
}
