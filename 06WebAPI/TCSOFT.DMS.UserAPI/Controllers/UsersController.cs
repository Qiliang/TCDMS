using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.UserApply.DTO.Common;
using TCSOFT.DMS.UserApply.DTO.User.UserApply;
using TCSOFT.DMS.UserApply.IServices;
using TCSOFT.DMS.UserApply.Services;

namespace TCSOFT.DMS.UserApplyAPI.Controllers
{
    public class UsersController : ApiController
    {
        IUserApplyServices _IUserServices = null;
        public UsersController()
        {
            _IUserServices = new UserApplyServices();
        }
        /// <summary>
        ///  申请用户/申请批次用户(含全部)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ApplyUser(BatchApplyOperateDTO dto)
        {
            ResultDTO<List<UserApplyOperateDTO>> resultdto = new ResultDTO<List<UserApplyOperateDTO>>();
            try
            {
                resultdto.SubmitResult = _IUserServices.ApplyUser(dto);
                resultdto.Object = dto.BatchApplyUser;
            }
            catch (Exception ex)
            {
                resultdto.SubmitResult = false;
                resultdto.Message = ex.Message;
            }

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(resultdto),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
    }
}
