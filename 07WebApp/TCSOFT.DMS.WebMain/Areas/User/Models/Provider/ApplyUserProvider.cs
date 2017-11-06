using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterData.DTO.Role;
using TCSOFT.DMS.UserApply.DTO.ImportExcel;
using TCSOFT.DMS.UserApply.DTO.User.UserApply;
using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model;
using TCSOFT.DMS.WebMain.Areas.User.Models.Model;
using TCSOFT.DMS.WebMain.Common;
using TCSOFT.DMS.WebMain.Models.Model;
using TCSOFT.DMS.WebMain.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.User.Models.Provider
{
    public class ApplyUserProvider : BaseProvider
    {
        #region 用户申请
        /// <summary>
        /// 得到用户申请批次信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<UserApplyBatchchResultModel>> GetApplyBatchUser(UserApplySearchDTO dto)
        {
            ResultData<List<UserApplyBatchchResultModel>> result = null;

            result = GetAPI<ResultData<List<UserApplyBatchchResultModel>>>(WebConfiger.UserServicesUrl + "ApplyUser?UserApplySearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<UserApplyUserResultDTO> GetOneUserApply(UserApplySearchDTO dto)
        {
            ResultData<UserApplyUserResultDTO> result = new ResultData<UserApplyUserResultDTO>();

            var pp = GetAPI<ResultData<List<UserApplyBatchchResultModel>>>(WebConfiger.UserServicesUrl + "ApplyUser?UserApplySearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            if (pp.Object != null && pp.Object.Count > 0)
            {
                var qq = pp.Object.FirstOrDefault();
                if (qq != null)
                {
                    result.Object = qq.UserApplyUserList.FirstOrDefault();
                    result.SubmitResult = true;
                }
                else
                {
                    result.Message = "此条信息不存在！";
                }
            }
            else
            {
                result.Message = "此条信息不存在！";
            }

            return result;
        }
        /// <summary>
        /// 得到批次用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<UserApplyUserResultDTO>> GetOneBachUserApply(UserApplySearchDTO dto)
        {
            ResultData<List<UserApplyUserResultDTO>> result = new ResultData<List<UserApplyUserResultDTO>>(); ;

            var pp = GetAPI<ResultData<List<UserApplyBatchchResultModel>>>(WebConfiger.UserServicesUrl + "ApplyUser?UserApplySearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            if (pp.Object != null && pp.Object.Count > 0)
            {
                var qq = pp.Object.FirstOrDefault();
                if (qq != null)
                {
                    result.Object = qq.UserApplyUserList;
                    result.SubmitResult = true;
                }
                else
                {
                    result.Message = "此条信息不存在！";
                }
            }
            else
            {
                result.Message = "此条信息不存在！";
            }

            return result;
        }
        /// <summary>
        /// 保存用户/保存批次用户
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> AddApplyUser(BatchApplyOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.UserServicesUrl + "ApplyUser", dto);

            return result;
        }
        /// <summary>
        /// 申请用户/申请批次用户(含全部)
        /// </summary>
        /// <returns></returns>
        public static ResultData<List<UserApplyOperateDTO>> ApplyUser(BatchApplyOperateDTO dto)
        {
            ResultData<List<UserApplyOperateDTO>> result = null;

            result = PostAPI<ResultData<List<UserApplyOperateDTO>>>(WebConfiger.UserServicesUrl + "Users", dto);

            return result;
        }
        /// <summary>
        /// 上传附件
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddAttachFileList(List<AttachFileOperateDTO> dtolist)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "AttachFile", dtolist);

            return result;
        }
        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> DelAttachFileList(AttachFileOperateDTO dto)
        {
            ResultData<object> result = null;

            result = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "AttachFile?AttachFileOperateDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到所有角色信息
        /// </summary>
        /// <returns></returns>
        public static List<RoleResultDTO> GetRoleList(RoleSearchDTO dto)
        {
            List<RoleResultDTO> result = new List<RoleResultDTO>();

            result = GetAPI<List<RoleResultDTO>>(WebConfiger.MasterDataServicesUrl + "Role?RoleSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到一条角色信息权限
        /// </summary>
        /// <returns></returns>
        public static RoleResultDTO GetRole(int? id)
        {
            RoleResultDTO result = new RoleResultDTO();

            var pp = GetAPI<ResultData<RoleResultDTO>>(WebConfiger.MasterDataServicesUrl + "Role/" + id);
            result = pp.Object;

            return result;
        }
        /// <summary>
        /// 得到申请用户权限
        /// </summary>
        /// <returns></returns>
        public static ResultData<List<UserApplyAuthority>> GetApplyUserAut(UserApplySearchDTO dto)
        {
            ResultData<List<UserApplyAuthority>> result = new ResultData<List<UserApplyAuthority>>();

            var pp = GetAPI<ResultData<List<UserApplyAuthority>>>(WebConfiger.MasterDataServicesUrl + "ApplyUserAuthority?UserApplySearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 戴锐2017/00/0
        /// 导入.
        /// </summary>
        /// <param name="regentprdlist"></param>
        /// <returns></returns>
        public static ResultData<object> ImportUserApplyData(List<ExcelBatch> regentprdlist)
        {
            return PostAPI<ResultData<object>>(WebConfiger.UserServicesUrl + "ImportData", new { Data = TransformHelper.ConvertDTOTOBase64JsonString(regentprdlist), Type = 1 });
        }
        #endregion
    }
}