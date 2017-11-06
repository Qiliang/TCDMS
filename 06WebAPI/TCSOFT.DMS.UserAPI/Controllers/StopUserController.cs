using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.UserApply.DTO.User;
using TCSOFT.DMS.UserApply.IServices;
using TCSOFT.DMS.UserApply.Services;

namespace TCSOFT.DMS.UserApplyAPI.Controllers
{
    public class StopUserController : ApiController
    {
        IUserApplyServices _IUserServices = null;
        public StopUserController()
        {
            _IUserServices = new UserApplyServices();
        }

        ///// <summary>
        ///// 得到停用用户信息
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public HttpResponseMessage GetStopUser(string UserSearchDTO)
        //{
        //    UserSearchDTO dto = TCSOFT.DMS.Common.TransformHelper.ConvertBase64JsonStringToDTO<UserSearchDTO>(UserSearchDTO);
        //    ResultDTO<List<UserResultDTO>> resultdto = new ResultDTO<List<UserResultDTO>>();
        //    List<UserResultDTO> user = _IUserServices.GetStopUser(dto);
        //    resultdto.Object = user;
        //    resultdto.Count = dto.Count;

        //    HttpResponseMessage result = new HttpResponseMessage
        //    {
        //        Content = new StringContent(JsonConvert.SerializeObject(resultdto),
        //            System.Text.Encoding.GetEncoding("UTF-8"),
        //            "application/json")
        //    };

        //    return result;
        //}
        ///// <summary>
        /////  用户启用
        ///// </summary>
        ///// <param name="dto"></param>
        ///// <returns></returns>
        //[HttpPut]
        //public HttpResponseMessage EnableUser(UserDTO dto)
        //{
        //    ResultDTO<object> resultdto = new ResultDTO<object>();
        //    try
        //    {
        //        resultdto.SubmitResult = _IUserServices.EnableUser(dto);
        //    }
        //    catch (Exception ex)
        //    {
        //        resultdto.SubmitResult = false;
        //        resultdto.Message = ex.Message;
        //    }

        //    HttpResponseMessage result = new HttpResponseMessage
        //    {
        //        Content = new StringContent(JsonConvert.SerializeObject(resultdto),
        //            System.Text.Encoding.GetEncoding("UTF-8"),
        //            "application/json")
        //    };

        //    return result;
        //}
    }
}
