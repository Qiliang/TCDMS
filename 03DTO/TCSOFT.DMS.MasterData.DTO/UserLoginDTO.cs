using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO
{
    [Serializable]
    /// <summary>
    /// 当前登录用户信息
    /// </summary>
    public class UserLoginDTO
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 邮件
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public int UserType { get; set; }
         /// <summary>
        /// 用户状态
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// 所属角色ID
        /// </summary>
        public List<int?> CurrentRoleIDList { get;set;}
        /// <summary>      
        /// <summary>
        /// 当前用户自定义权限
        /// </summary>
        public List<CurrentUserCustomerAuthority> CurrentUserCustomerAuthorityList { get; set; }
        /// <summary>
        /// 当前用户权限列表
        /// </summary>
        public List<CurrentAuthorityDTO> CurrentAuthorityList
        {
            get
            {
                List<CurrentAuthorityDTO> result = new List<CurrentAuthorityDTO>();
                List<CurrentAuthorityDTO> TempResult = new List<CurrentAuthorityDTO>();
            
                if (CurrentUserCustomerAuthorityList != null)
                {
                    CurrentUserCustomerAuthorityList.ForEach(g =>
                    {
                        TempResult.Add(new CurrentAuthorityDTO { StructureID = g.StructureID, BelongButton = g.UserButtonAuthority.Value });
                    });
                }

                CurrentAuthorityDTO cadto = null;
                foreach (var p in TempResult)
                {
                    cadto = result.Where(g => g.StructureID == p.StructureID).FirstOrDefault();
                    if (cadto == null)
                    {
                        result.Add(new CurrentAuthorityDTO { StructureID = p.StructureID, BelongButton = p.BelongButton });
                    }
                    else
                    {
                        cadto.BelongButton |= p.BelongButton;
                    }
                }

                return result;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public List<Guid?> DistributorIDlist { get; set; }
        public List<string> DistributorNamelist { get; set; }
        /// <summary>
        /// 对应绑定经销商(以逗号分隔)
        /// </summary>
        public string Distributorstr
        {
            get;
            set;
        }
    }

    [Serializable]
    public class CurrentUserRoleAuthority
    {
        /// <summary>
        /// 结构ID
        /// </summary>
        public string StructureID { get; set; }
        /// <summary>
        /// 结构按钮权限
        /// </summary>
        public int? RoleButtonAuthority { get; set; }
    }

    [Serializable]
    public class CurrentUserCustomerAuthority
    {
        /// <summary>
        /// 结构ID
        /// </summary>
        public string StructureID { get; set; }
        /// <summary>
        /// 按钮权限
        /// </summary>
        public int? UserButtonAuthority { get; set; }
    }

    [Serializable]
    /// <summary>
    /// 当前权限
    /// </summary>
    public class CurrentAuthorityDTO
    {
        /// <summary>
        /// 结构ID
        /// </summary>
        public string StructureID { get; set; }
        /// <summary>
        /// 所属按钮
        /// </summary>
        public int BelongButton { get; set; }
    }

    /// <summary>
    /// 登录信息
    /// </summary>
    public class LoginDTO
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 动态密码
        /// </summary>
        public string DynamicPassword { get; set; }
    }

    public class MoblieLoginDTO
    {
        public string PhoneNumber { get; set; }
        public string DymicPassword { get; set; }
        public int ValidDate { get; set; }
    }
}
