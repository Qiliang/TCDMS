using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.Fcpa.DTO;
using TCSOFT.DMS.Fcpa.DTO.Credential;
using TCSOFT.DMS.Fcpa.DTO.Fcpa;
using TCSOFT.DMS.Fcpa.DTO.Org;
using TCSOFT.DMS.MasterData.DTO;
using TCSOFT.DMS.WebMain.Areas.Fcpa.Controllers;
using TCSOFT.DMS.WebMain.Common;
using TCSOFT.DMS.WebMain.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.Fcpa.Models.Provider
{
    public class FcpaProvider : BaseProvider
    {
        public static PageableDTO<CredentialResultDTO> Query(FcpaSearchDTO dto)
        {
            return PostAPI<PageableDTO<CredentialResultDTO>>(WebConfiger.FcpaServicesUrl + "Credentials/Query", dto);
        }

        public static IEnumerable<DistributorDTO> Distributors(UserInfoDTO userInfo)
        {
            return PostAPI<IEnumerable<DistributorDTO>>(WebConfiger.FcpaServicesUrl + "Credentials/Distributors", userInfo);
        }

        public static CredentialResultDTO Get(string id)
        {
            return GetAPI<CredentialResultDTO>(WebConfiger.FcpaServicesUrl + "Credentials/Get?id="+id);
        }

        public static OperateResultDTO Add(CredentialOperateDTO dto)
        {
            return PostAPI<OperateResultDTO>(WebConfiger.FcpaServicesUrl + "Credentials/Add", dto);
        }

        public static OperateResultDTO Update(CredentialOperateDTO dto)
        {
            return PostAPI<OperateResultDTO>(WebConfiger.FcpaServicesUrl + "Credentials/Update", dto);
        }

        public static OperateResultDTO AddOrgMap(OrgMapAddDTO dto)
        {            
           return PostAPI<OperateResultDTO>(WebConfiger.FcpaServicesUrl + "Credentials/AddOrgMap", dto);
        }
    }
}