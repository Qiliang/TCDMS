using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Fcpa.DTO;
using TCSOFT.DMS.Fcpa.DTO.Credential;
using TCSOFT.DMS.Fcpa.DTO.Fcpa;
using TCSOFT.DMS.Fcpa.DTO.Org;
using TCSOFT.DMS.Fcpa.IServices;
using TCSOFT.DMS.Fcpa.Services;

namespace TCSOFT.DMS.FpcaAPI.Controllers
{
    [RoutePrefix("api/Credentials")]
    public class CredentialsController : ApiController
    {
        IFcpaService _FcpaService = new FcpaService();

        [Route("Distributors"), HttpPost]
        public IEnumerable<DistributorDTO> Distributors(UserInfoDTO userInfo)
        {
            return _FcpaService.Distributors(userInfo);
        }

        [Route("Get"), HttpGet]
        public CredentialResultDTO Get(string id)
        {
            return _FcpaService.Get(id);
        }

        [Route("Query"), HttpPost]
        public PageableDTO<CredentialResultDTO> Query(FcpaSearchDTO q)
        {
            return _FcpaService.Query(q);
        }

        [Route("Add"), HttpPost]
        public OperateResultDTO Add(CredentialOperateDTO dto)
        {
            return _FcpaService.Add(dto);
        }

        [Route("Update"), HttpPost]
        public OperateResultDTO Update(CredentialOperateDTO dto)
        {
            return _FcpaService.Update(dto);
        }

        [Route("AddOrgMap"), HttpPost]
        public OperateResultDTO AddOrgMap(OrgMapAddDTO dto)
        {
            return _FcpaService.AddOrgMap(dto);
        }

    }
}
