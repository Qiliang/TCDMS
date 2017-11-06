using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterData.DTO.Message;
using TCSOFT.DMS.MasterData.DTO.System.ModularSysEmail;
using TCSOFT.DMS.MasterData.DTO.System.OperationSysEmail;
using TCSOFT.DMS.MasterData.DTO.User;
using TCSOFT.DMS.MasterData.DTO.UsersStat;
using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model;
using TCSOFT.DMS.WebMain.Common;
using TCSOFT.DMS.WebMain.Models.Model;
using TCSOFT.DMS.WebMain.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider
{
    public class SystemProvider : BaseProvider
    {
        /// <summary>
        /// 添加客户管理员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddCustomerAdmin(UserOperate dto)
        {
            ResultData<object> result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "UserManager", dto);

            return result;
        }

        #region 模块管理员配置
        /// <summary>
        /// 得到所有模块管理员信息
        /// </summary>
        /// <returns></returns>
        public static ResultData<List<CustomerSysEamilModel>> GetModularList(UserSearchDTO dto)
        {
            ResultData<List<CustomerSysEamilModel>> result = new ResultData<List<CustomerSysEamilModel>>();

            var pp = GetAPI<ResultData<List<UserResultDTO>>>(WebConfiger.MasterDataServicesUrl + "UserManager?UserSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            result.Object = new List<CustomerSysEamilModel>();
            foreach (var p in pp.Object) 
            {
                if (p.UserRolelist != null) 
                {
                    foreach (var r in p.UserRolelist.Where(ur => ur.Value >= 2 && ur.Value <= 13).ToList())
                    {
                        foreach (var m in ModelRoleModel.ModelRolelist.Where(mr => mr.RoleID == r).Select(s => s.ModelName))
                        {
                            CustomerSysEamilModel cussys = new CustomerSysEamilModel();
                            result.Object.Add(cussys);
                            cussys.UserID = p.UserID;
                            cussys.FullName = p.FullName;
                            cussys.Email = p.Email;
                            cussys.Module = m;
                        }
                    }
                }
            }

            return result;
        }
        /// <summary>
        /// 修改模块管理员邮箱
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdateModularInfo(UserOperate dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "UserManager", dto);

            return result;
        }
        #endregion

        #region 运维管理员配置
        /// <summary>
        /// 修改模块管理员邮箱
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdateOperationInfo(OperationOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "OperationSys", dto);

            return result;
        }
        #endregion

        #region 短信统计
        /// <summary>
        /// 得到短信统计
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<MessageStatModel>> GetMessageStatList(MessageSearchDTO dto)
        {
            ResultData<List<MessageStatModel>> result = null;

            result = GetAPI<ResultData<List<MessageStatModel>>>(WebConfiger.MasterDataServicesUrl + "MessageStat?MessageSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 删除短信统计
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> DeleteMessageStat(MessageResultDTO dto)
        {
            ResultData<object> blResult = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "MessageStat?MessageResultDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return blResult;
        }
        #endregion

        #region 用户统计
        /// <summary>
        /// 得到用户统计
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<UsersStatModel>> GetUsersStatList(UsersStatSearchDTO dto)
        {
            ResultData<List<UsersStatModel>> result = null;

            result = GetAPI<ResultData<List<UsersStatModel>>>(WebConfiger.MasterDataServicesUrl + "UsersStat?UsersStatSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
           
        }
        /// <summary>
        /// 新增用户统计
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddUsersStat(UsersStatOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "UsersStat", dto);

            return result;
        }
        /// <summary>
        /// 删除用户统计信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> DeleteUsersStat(UsersStatResultDTO dto)
        {
            ResultData<object> blResult = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "UsersStat?UsersStatResultDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return blResult;
        }
        #endregion

        #region 反馈管理
        /// <summary>
        /// 得到反馈管理
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<FeedbackModel>> GetFeedbackList(FeedbackSearchDTO dto)
        {
            ResultData<List<FeedbackModel>> result = null;

            result = GetAPI<ResultData<List<FeedbackModel>>>(WebConfiger.MasterDataServicesUrl + "Feedback?FeedbackSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        
        /// <summary>
        /// 新增反馈管理
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<int> AddFeedback(FeedbackOperateDTO dto)
        {
            ResultData<int> result = null;

            result = PostAPI<ResultData<int>>(WebConfiger.MasterDataServicesUrl + "Feedback", dto);

            return result;
        }
        /// <summary>
        /// 修改反馈管理(修改状态)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdateFeedback(FeedbackOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Feedback", dto);

            return result;
        }
        #endregion

        #region 日志管理
        /// <summary>
        /// 得到日志信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<LogDTO>> GetLog(LogSearchDTO dto)
        {
            ResultData<List<LogDTO>> result = null;

            result = GetAPI<ResultData<List<LogDTO>>>(WebConfiger.MasterDataServicesUrl + "Log?LogSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        #endregion
    }
}