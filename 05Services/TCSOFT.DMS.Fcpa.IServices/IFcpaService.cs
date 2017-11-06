using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Fcpa.DTO;
using TCSOFT.DMS.Fcpa.DTO.Credential;
using TCSOFT.DMS.Fcpa.DTO.Fcpa;
using TCSOFT.DMS.Fcpa.DTO.Org;

namespace TCSOFT.DMS.Fcpa.IServices
{
    public interface IFcpaService
    {
        PageableDTO<CredentialResultDTO> Query(FcpaSearchDTO q);

        IEnumerable<DistributorDTO> Distributors(UserInfoDTO userInfo);

        OperateResultDTO Add(CredentialOperateDTO model);

        OperateResultDTO Update(CredentialOperateDTO model);

        CredentialResultDTO Get(string id);

        OperateResultDTO AddOrgMap(OrgMapAddDTO dto);
    }
}
