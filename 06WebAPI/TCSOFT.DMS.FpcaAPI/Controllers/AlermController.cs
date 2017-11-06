using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Fcpa.DTO;
using TCSOFT.DMS.Fcpa.DTO.Alerm;
using TCSOFT.DMS.Fcpa.IServices;
using TCSOFT.DMS.Fcpa.Services;

namespace TCSOFT.DMS.FpcaAPI.Controllers
{
    [RoutePrefix("api/Alerm")]
    public class AlermController : ApiController
    {
        IAlermService _AlermService = new AlermService();

        [Route("Query"), HttpPost]
        public PageableDTO<AlermResultDTO> Query(AlermSearchDTO q)
        {
            return _AlermService.Query(q);
        }
    }
}
