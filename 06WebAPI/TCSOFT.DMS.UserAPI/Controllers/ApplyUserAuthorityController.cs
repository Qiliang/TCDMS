using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.UserApply.DTO.User.UserApply;
using TCSOFT.DMS.UserApply.IServices;
using TCSOFT.DMS.UserApply.Services;

namespace TCSOFT.DMS.UserApplyAPI.Controllers
{
    public class ApplyUserAuthorityController : ApiController
    {
        IUserApplyServices _IUserServices = null;
        public ApplyUserAuthorityController()
        {
            _IUserServices = new UserApplyServices();
        }

        ///// <summary>
        ///// 查询申请的用户的权限
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public HttpResponseMessage GetApplyUserAut(string UserApplySearchDTO)
        //{
        //    UserApplySearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<UserApplySearchDTO>(UserApplySearchDTO);
        //    ResultDTO<List<UserApplyAuthority>> resultdto = new ResultDTO<List<UserApplyAuthority>>();
        //    List<UserApplyAuthority> user = null;

        //    user = _IUserServices.GetApplyUserAuthority(dto);

        //    resultdto.Object = user;

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
