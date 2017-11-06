using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Fcpa.DTO;
using TCSOFT.DMS.Fcpa.DTO.Org;

namespace TCSOFT.DMS.Fcpa.IServices
{
    public interface IOrgMapService
    {
        PageableDTO<OrgResultDTO> Query(OrgSearchDTO q);

        OrgResultDTO Get(string id);
    }
}
