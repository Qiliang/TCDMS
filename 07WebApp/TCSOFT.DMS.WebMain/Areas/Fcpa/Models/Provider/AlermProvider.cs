using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.Fcpa.DTO;
using TCSOFT.DMS.Fcpa.DTO.Alerm;
using TCSOFT.DMS.Fcpa.DTO.Dashboard;
using TCSOFT.DMS.WebMain.Common;
using TCSOFT.DMS.WebMain.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.Fcpa.Models.Provider
{
    public class AlermdProvider : BaseProvider
    {
        public static PageableDTO<AlermResultDTO> Query(AlermSearchDTO dto)
        {
            return PostAPI<PageableDTO<AlermResultDTO>>(WebConfiger.FcpaServicesUrl + "Alerm/Query", dto);
        }
    }
}