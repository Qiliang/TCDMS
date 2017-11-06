using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Fcpa.DTO;
using TCSOFT.DMS.Fcpa.DTO.Org;
using TCSOFT.DMS.Fcpa.IServices;
using TCSOFT.DMS.Fcpa.Services;

namespace TCSOFT.DMS.FpcaAPI.Controllers
{
    [RoutePrefix("api/OrgMap")]
    public class OrgMapController : ApiController
    {

        IOrgMapService _OrgMapService = new OrgMapService();

        [Route("Query"), HttpPost]
        public PageableDTO<OrgResultDTO> Query(OrgSearchDTO q)
        {
            return _OrgMapService.Query(q);
        }

        [Route("Get"), HttpGet]
        public OrgResultDTO Query(string id)
        {
            return _OrgMapService.Get(id);
        }

       
    }
}
