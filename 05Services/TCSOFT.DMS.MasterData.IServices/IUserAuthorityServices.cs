using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.IServices
{
    using DTO.Common;
    using DTO.Role;
    using DTO.User;
    using DTO.User.UserApply;
    public interface IUserAuthorityServices
    {
        #region 部门
        /// <summary>
        /// 得到所有部门信息
        /// </summary>
        /// <returns></returns>
        List<DepartmentResultDTO> GetDepartmentList();
        /// <summary>
        /// 得到一条部门信息
        /// </summary>
        /// <returns></returns>
        DepartmentResultDTO GetDepartment(int id);
        /// <summary>
        /// 新增部门信息
        /// </summary>
        /// <returns></returns>
        bool AddDepartment(DepartmentOperateDTO dto);
        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <returns></returns>
        bool UpdateDepartment(DepartmentOperateDTO dto);
        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <returns></returns>
        bool DeleteDepartment(DepartmentSearchDTO dto);
        List<DepartmentResultDTO> GetDepartment();
        
        #endregion 
        
        #region 角色
        /// <summary>
        /// 得到所有角色信息
        /// </summary>
        /// <returns></returns>
        List<RoleResultDTO> GetRoleList(RoleSearchDTO dto);
        /// <summary>
        /// 得到一条角色信息
        /// </summary>
        /// <returns></returns>
        RoleResultDTO GetRole(int id);
        /// <summary>
        /// 新增角色信息
        /// </summary>
        /// <returns></returns>
        bool AddRole(RoleOperateDTO dto);
        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <returns></returns>
        bool UpdateRole(RoleOperateDTO dto);
        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <returns></returns>
        bool DeleteRole(RoleSearchDTO dto);
        #endregion
        #region 用户申请及审核
        /// <summary>
        /// 已授权用户模块
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<UsersByAuthoritedResultDTO> GetUsersByAuthorited(UsersByAuthoritedSearchDTO dto);
        /// <summary>
        /// 用户审核(通过)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool AuditUserApplyAdopt(UserApplyOperateDTO dto);
        #endregion
        #region 用户管理
        /// <summary>
        /// 得到所有用户信息(含模糊查询)
        /// </summary>
        /// <returns></returns>
        List<UserResultDTO> GetUser(UserSearchDTO dto);
        /// <summary>
        /// 得到一条用户信息
        /// </summary>
        /// <returns></returns>
        UserResultDTO GetOneUser(int id);
        /// <summary>
        /// 用户信息新增
        /// </summary>
        /// <returns></returns>
        bool AddUser(UserOperate dto);
        /// <summary>
        /// 用户信息修改
        /// </summary>
        /// <returns></returns>
        bool UpdateUser(UserOperate dto);
        /// <summary>
        /// 用户信息删除
        /// </summary>
        /// <returns></returns>
        bool DeleteUser(UserOperate dto);
        /// <summary>
        /// 用户信息停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool StopEnableUser(UserOperate dto);
        /// <summary>
        /// 新增客户管理员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool AddCustomerAdmin(UserOperate dto);
        /// <summary>
        /// 删除客户管理员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DeleteCustomerAdmin(UserOperate dto);
        /// <summary>
        /// 修改模块管理员邮箱
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool UpdateModularAdmin(UserOperate dto);
        #endregion
    }
}
