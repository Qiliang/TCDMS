using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider
{
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using TCSOFT.DMS.MasterData.DTO.ImportExcel;
    using TCSOFT.DMS.MasterData.DTO.Role;
    using TCSOFT.DMS.MasterData.DTO.User;
    using TCSOFT.DMS.UserApply.DTO.User.UserApply;
    using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model;
    using TCSOFT.DMS.WebMain.Areas.User.Models.Model;
    using TCSOFT.DMS.WebMain.Models.Model;
    using WebMain.Common;
    using WebMain.Models.Provider;
    public class UserAuthorityProvider : BaseProvider
    {
        #region 用户管理
        /// <summary>
        /// 得到所有用户信息(含模糊查询)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<UserResultDTO>> GetUser(UserSearchDTO dto)
        {
            ResultData<List<UserResultDTO>> result = null;

            result = GetAPI<ResultData<List<UserResultDTO>>>(WebConfiger.MasterDataServicesUrl + "UserManager?UserSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到一条用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<UserResultDTO> GetOneUser(int id)
        {
            ResultData<UserResultDTO> result = GetAPI<ResultData<UserResultDTO>>(WebConfiger.MasterDataServicesUrl + "UserManager?id=" + id);

            return result;
        }
        /// <summary>
        /// 用户信息新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddUser(UserOperate dto)
        {
            ResultData<object> result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "UserManager", dto);

            return result;
        }
        /// <summary>
        /// 用户信息修改/停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdateStopEnableUser(UserOperate dto)
        {
            ResultData<object> result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "UserManager", dto);

            return result;
        }
        /// <summary>
        /// 用户信息删除
        /// </summary>
        /// <param name="UserOperate"></param>
        /// <returns></returns>
        public static ResultData<object> DeleteUser(UserOperate dto)
        {
            ResultData<object> blResult = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "UserManager?UserOperate=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return blResult;
        }
        /// <summary>
        /// 导入用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> ImportUser(List<ExcelUser> dto)
        {
            return PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "ImportData", new { Data = TransformHelper.ConvertDTOTOBase64JsonString(dto), Type = 13 });
        }
        #endregion

        #region 用户审核
        /// <summary>
        /// 得到所有用户申请信息(含模糊查询)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<UserApplyResultDTOModel>> GetUserApply(UserApplySearchDTO dto)
        {
            ResultData<List<UserApplyResultDTOModel>> result = null;

            result = GetAPI<ResultData<List<UserApplyResultDTOModel>>>(WebConfiger.UserServicesUrl + "ApplyUserAudit?UserApplySearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到一条用户申请信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ResultData<UserApplyResultDTOModel> GetOneUserApply(UserApplySearchDTO dto)
        {
            ResultData<UserApplyResultDTOModel> result = new ResultData<UserApplyResultDTOModel>();

            var pp = GetAPI<ResultData<List<UserApplyResultDTOModel>>>(WebConfiger.UserServicesUrl + "ApplyUserAudit?UserApplySearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            if (pp.Object.Count > 0)
            {
                result.Object = pp.Object.First();
                result.SubmitResult = true;
            }
            else
            {
                result.Message = "此条信息不存在！";
            }

            return result;
        }
        /// <summary>
        /// 得到申请人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ResultData<UserApplyBatchchResultModel> GetBatchUser(UserApplySearchDTO dto)
        {
            ResultData<UserApplyBatchchResultModel> result = new ResultData<UserApplyBatchchResultModel>();

            var pp = GetAPI<ResultData<List<UserApplyBatchchResultModel>>>(WebConfiger.UserServicesUrl + "ApplyUser?UserApplySearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            if (pp.Object.Count > 0)
            {
                result.Object = pp.Object.FirstOrDefault();
                result.SubmitResult = true;
            }
            else
            {
                result.Message = "此条信息不存在！";
            }

            return result;
        }
        /// <summary>
        /// 用户申请审核（通过）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<UserApplyOperateDTO> AuditUserApplyAdopt(UserApplyOperateDTO dto)
        {
            ResultData<UserApplyOperateDTO> result = new ResultData<UserApplyOperateDTO>();

            result = PostAPI<ResultData<UserApplyOperateDTO>>(WebConfiger.UserServicesUrl + "ApplyUserAudit", dto);

            return result;
        }
        /// <summary>
        /// 用户申请审核（通过）添加权限
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AuditUserApplyAdoptAut(UserApplyOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "UserAudit", dto);

            return result;
        }
        /// <summary>
        /// 用户申请审核（拒绝）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<UserApplyOperateDTO> AuditUserApplyRefuse(UserApplyOperateDTO dto)
        {
            ResultData<UserApplyOperateDTO> result = new ResultData<UserApplyOperateDTO>();

            result = PostAPI<ResultData<UserApplyOperateDTO>>(WebConfiger.UserServicesUrl + "ApplyUserAudit", dto);

            return result;
        }
        /// <summary>
        /// 已授权用户信息
        /// </summary>
        /// <param name="Structurelist"></param>
        /// <returns></returns>
        public static ResultData<List<AuthModuleUserModel>> GetUsersByAuthorited(UsersByAuthoritedSearchDTO dto)
        {
            ResultData<List<AuthModuleUserModel>> result = null;

            result = GetAPI<ResultData<List<AuthModuleUserModel>>>(WebConfiger.MasterDataServicesUrl + "UsersByAuthorited?UsersByAuthoritedSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        public static AttachFileResultDTO GetAttachFileList(AttachFileSearchDTO dto) 
        {
            AttachFileResultDTO result = null;

            var pp = GetAPI<List<AttachFileResultDTO>>(WebConfiger.MasterDataServicesUrl + "AttachFile?AttachFileSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            if (pp.Count() > 0) 
            {
                result = pp.FirstOrDefault();
            }

            return result;
        }

        #endregion

        #region 角色管理
        /// <summary>
        /// 得到所有角色信息
        /// </summary>
        /// <returns></returns>
        public static List<RoleResultDTO> GetRoleList(RoleSearchDTO dto)
        {
            List<RoleResultDTO> result = new List<RoleResultDTO>();

            result = GetAPI<List<RoleResultDTO>>(WebConfiger.MasterDataServicesUrl + "Role?RoleSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            result = result.OrderBy(m => m.RoleType).ToList();

            return result;
        }
        /// <summary>
        /// 得到所有角色信息
        /// </summary>
        /// <returns></returns>
        public static List<RoleResultDTO> GetAllRoleList(int? id)
        {
            List<RoleResultDTO> result = new List<RoleResultDTO>();

            RoleSearchDTO dto = new RoleSearchDTO();
            result = GetRoleList(dto);
            result = result.Where(p => p.RoleType == id).ToList();

            return result;
        }
        /// <summary>
        /// 得到一条角色信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<RoleResultDTO>  GetRole(int id)
        {
            ResultData<RoleResultDTO> result = new ResultData<RoleResultDTO>();

            result = GetAPI<ResultData<RoleResultDTO>>(WebConfiger.MasterDataServicesUrl + "Role/"+id);

            return result;
        }
        /// <summary>
        /// 新增角色信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> AddRole(RoleOperateDTO dto)
        {
            var result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Role", dto);

            return result;
        }
        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> UpdateRole(RoleOperateDTO dto)
        {
            var result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Role", dto);

            return result;
        }
        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> DeleteRole(RoleSearchDTO dto)
        {

            var result = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Role?RoleSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        #endregion

        #region 部门管理
        /// <summary>
        /// 得到所有部门信息
        /// </summary>
        /// <returns></returns>
        public static List<DepartmentResultDTO> GetDepartmentList()
        {
            List<DepartmentResultDTO> result = new List<DepartmentResultDTO>();

            result = GetAPI<List<DepartmentResultDTO>>(WebConfiger.MasterDataServicesUrl + "Department");

            var i = 0;
            FictitiousDepartment(result,ref i);

            return result;
        }
        public static List<DepartmentResultDTO> FictitiousDepartment(List<DepartmentResultDTO> result,ref int i)
        {
            foreach (var r in result) 
            {
                i++;
                r.FictitiousID = i;
                if (r.children != null) 
                {
                    FictitiousDepartment(r.children, ref i);
                }
            }

            return result;
        }
       
        /// <summary>
        /// 得到一条部门信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<DepartmentResultDTO> GetDepartment(int id)
        {
            ResultData<DepartmentResultDTO> result = new ResultData<DepartmentResultDTO>();

            result = GetAPI<ResultData<DepartmentResultDTO>>(WebConfiger.MasterDataServicesUrl + "Department/" + id);

            return result;
        }
        /// <summary>
        /// 新增部门信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> AddDepartment(DepartmentOperateDTO dto)
        {
            var result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Department", dto);

            return result;
        }
        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> UpdateDepartment(DepartmentOperateDTO dto)
        {
            var result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Department", dto);

            return result;
        }
        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> DeleteDepartment(DepartmentSearchDTO dto)
        {
            var result = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Department?DepartmentSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 初始化上级部门
        /// </summary>
        /// <returns></returns>
        public static List<DepartmentTreeDTO> GetDepartmentTree()
        {
            List<DepartmentTreeDTO> result = new List<DepartmentTreeDTO>();
            var list = GetAPI<List<DepartmentResultDTO>>(WebConfiger.MasterDataServicesUrl + "Department");
            foreach (var li in list)
            {
                var item = GenerateDepartmentTree(li);
                result.Add(item);
            }

            return result;
        }
        private static DepartmentTreeDTO GenerateDepartmentTree(DepartmentResultDTO root)
        {
            DepartmentTreeDTO result = new DepartmentTreeDTO();
            result.children = new List<DepartmentTreeDTO>();
            result.id = root.DepartID;
            result.path = root.DepartPath;
            result.text = root.DepartName;
            if (root.children != null)
            {
                foreach (var child in root.children)
                {
                    var item = GenerateDepartmentTree(child);
                    result.children.Add(item);
                }
            }

            return result;
        }
        #endregion
    }
}