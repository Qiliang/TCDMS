using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using TCSOFT.DMS.MasterData.DTO.User.UserApply;
using TCSOFT.DMS.MasterData.IServices;
using TCSOFT.DMS.MasterData.Services;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    /// <summary>
    /// 用户申请
    /// </summary>
    public class UserApplyController : ApiController
    {
        IUserAuthorityServices _lUserAuthorityServices = null;
        public UserApplyController()
        {
            _lUserAuthorityServices = new UserAuthorityServices();
        }
    }
}