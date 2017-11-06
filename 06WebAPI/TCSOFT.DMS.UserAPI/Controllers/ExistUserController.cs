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
using TCSOFT.DMS.UserApply.DTO.User.UserApply;
using TCSOFT.DMS.UserApply.IServices;
using TCSOFT.DMS.UserApply.Services;

namespace TCSOFT.DMS.UserApplyAPI.Controllers
{
    public class ExistUserController : ApiController
    {
        IUserApplyServices _IUserServices = null;
        public ExistUserController()
        {
            _IUserServices = new UserApplyServices();
        }

        ///// <summary>
        ///// 得到启用用户信息
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public HttpResponseMessage GetEnableUser(string UserSearchDTO)
        //{
        //    UserSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<UserSearchDTO>(UserSearchDTO);
        //    ResultDTO<List<UserResultDTO>> resultdto = new ResultDTO<List<UserResultDTO>>();
        //    List<UserResultDTO> user = _IUserServices.GetEnableUser(dto);
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
        /////  用户信息停用
        ///// </summary>
        ///// <param name="dto"></param>
        ///// <returns></returns>
        //[HttpPut]
        //public HttpResponseMessage StopUser(UserDTO dto)
        //{
        //    ResultDTO<object> resultdto = new ResultDTO<object>();
        //    try
        //    {
        //        resultdto.SubmitResult = _IUserServices.StopUser(dto);
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
        ///// <summary>
        ///// 变更权限
        ///// </summary>
        ///// <param name="dto"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public HttpResponseMessage ChangeUserAut(UserApplyOperateDTO dto)
        //{
        //    ResultDTO<object> resultdto = new ResultDTO<object>();
        //    try
        //    {
        //        resultdto.SubmitResult = _IUserServices.ChangeUserAut(dto);
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
