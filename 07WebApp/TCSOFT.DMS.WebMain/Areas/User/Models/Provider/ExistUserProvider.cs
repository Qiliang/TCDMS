using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO;
using TCSOFT.DMS.MasterData.DTO.User;
using TCSOFT.DMS.UserApply.DTO.User;
using TCSOFT.DMS.UserApply.DTO.User.UserApply;
using TCSOFT.DMS.WebMain.Areas.User.Models.Model;
using TCSOFT.DMS.WebMain.Common;
using TCSOFT.DMS.WebMain.Models.Model;
using TCSOFT.DMS.WebMain.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.User.Models.Provider
{
    public class ExistUserProvider : BaseProvider
    {
        #region 已有用户
        /// <summary>
        /// 得到启用用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<UserModel>> GetEnableUser(UserSearchDTO dto)
        {
            ResultData<List<UserModel>> result = null;

            result = GetAPI<ResultData<List<UserModel>>>(WebConfiger.MasterDataServicesUrl + "UserManager?UserSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 得到一条启用用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<UserModel> GetOneEnableUser(UserSearchDTO dto)
        {
            ResultData<UserModel> result = new ResultData<UserModel>();

            result = GetAPI<ResultData<UserModel>>(WebConfiger.MasterDataServicesUrl + "UserManager?id=" + dto.UserID);

            return result;
        }
        /// <summary>
        /// 变更权限
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> ChangeUserAut(UserApplyOperateDTO dto)
        {
            ResultData<object> result = null;

            result = PostAPI<ResultData<object>>(WebConfiger.UserServicesUrl + "ExistUser", dto);

            return result;
        }
        /// <summary>
        /// 用户信息停用
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> StopUser(UserOperate dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "UserManager", dto);

            return result;
        }
        /// <summary>
        /// 用户权限
        /// </summary>
        /// <returns></returns>
        public static List<CurrentAuthorityDTO> GetUserAuthorityInfo(string userid, int type, int? roletype)
        {
            List<CurrentAuthorityDTO> result = null;

            result = GetAPI<List<CurrentAuthorityDTO>>(WebConfiger.MasterDataServicesUrl + "Common?strIdlst=" + userid + "&type=" + type + "&roletype=" + roletype);

            return result;
        }
        #endregion
    }
}