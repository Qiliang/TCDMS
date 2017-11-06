using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO.User;
using TCSOFT.DMS.UserApply.DTO.User;
using TCSOFT.DMS.WebMain.Areas.User.Models.Model;
using TCSOFT.DMS.WebMain.Common;
using TCSOFT.DMS.WebMain.Models.Model;
using TCSOFT.DMS.WebMain.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.User.Models.Provider
{
    public class StopUserProvider : BaseProvider
    {
        #region 停用用户
        /// <summary>
        /// 得到停用用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<List<UserModel>> GetStopUser(UserSearchDTO dto)
        {
            ResultData<List<UserModel>> result = null;

            result = GetAPI<ResultData<List<UserModel>>>(WebConfiger.MasterDataServicesUrl + "UserManager?UserSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return result;
        }
        /// <summary>
        /// 用户启用
        /// </summary>
        /// <returns></returns>
        public static ResultData<object> EnableUser(UserOperate dto)
        {
            ResultData<object> result = null;

            result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "UserManager", dto);

            return result;
        }
        #endregion
    }
}