using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.MasterData.DTO.User.UserApply;
using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model;
using TCSOFT.DMS.WebMain.Common;
using TCSOFT.DMS.WebMain.Models.Model;

namespace TCSOFT.DMS.WebMain.Models.Provider
{
    public class UserApplyProvider:BaseProvider
    {
        public static bool AuthApply(UserApplyModel uam)
        {
            bool Result = PostAPI<bool>(WebConfiger.MasterDataServicesUrl + "UserApply", uam);

            return Result;
        }

        public static bool ChangeAuthority(UserApplyModel uam)
        {
            bool Result = PutAPI<bool>(WebConfiger.MasterDataServicesUrl + "UserApply", (UserApplyOperateDTO)uam);

            return Result;
        }

        public static List<TCSOFT.DMS.MasterData.DTO.Common.AdminDTO> GetAdminInfo(TCSOFT.DMS.MasterData.DTO.Common.AdminSearchDTO asdto)
        {
            List<TCSOFT.DMS.MasterData.DTO.Common.AdminDTO> Result = GetAPI<List<TCSOFT.DMS.MasterData.DTO.Common.AdminDTO>>(WebConfiger.MasterDataServicesUrl + "Common?asdto="+TCSOFT.DMS.Common.TransformHelper.ConvertDTOTOBase64JsonString(asdto));

            return Result;
        }
    }
}
