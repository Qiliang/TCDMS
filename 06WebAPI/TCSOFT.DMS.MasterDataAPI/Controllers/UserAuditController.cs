using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using MasterData.IServices;
    using MasterData.Services;
    using MasterData.DTO.User.UserApply;
    using DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.User;
    using TCSOFT.DMS.MasterData.DTO.Common;
    public class UserAuditController : ApiController
    {
        IUserAuthorityServices _lUserAuthorityServices = null;
        public UserAuditController()
        {
            _lUserAuthorityServices = new UserAuthorityServices();
        }

        /// <summary>
        /// 用户审核(通过)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AuditUserApplyAdopt(UserApplyOperateDTO dto)
        {
            ResultDTO<UserApplyOperateDTO> actionresult = new ResultDTO<UserApplyOperateDTO>();

            actionresult.SubmitResult = _lUserAuthorityServices.AuditUserApplyAdopt(dto);
            actionresult.Object = dto;

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
    }
}
