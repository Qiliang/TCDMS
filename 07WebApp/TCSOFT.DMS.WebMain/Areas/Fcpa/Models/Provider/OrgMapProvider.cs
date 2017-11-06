using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.Fcpa.DTO;
using TCSOFT.DMS.Fcpa.DTO.Dashboard;
using TCSOFT.DMS.Fcpa.DTO.Org;
using TCSOFT.DMS.WebMain.Common;
using TCSOFT.DMS.WebMain.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.Fcpa.Models.Provider
{
    public class OrgMapProvider : BaseProvider
    {
        public static PageableDTO<OrgResultDTO> Query(OrgSearchDTO dto)
        {           
            return PostAPI<PageableDTO<OrgResultDTO>>(WebConfiger.FcpaServicesUrl + "OrgMap/Query", dto);
        }

        public static OrgResultDTO Get(string id)
        {
            return GetAPI<OrgResultDTO>(WebConfiger.FcpaServicesUrl + "OrgMap/Get?id="+id);
        }
    }
}