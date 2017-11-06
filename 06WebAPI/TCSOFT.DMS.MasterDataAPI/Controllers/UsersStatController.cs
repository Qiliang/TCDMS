using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using Newtonsoft.Json;
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using TCSOFT.DMS.MasterData.DTO.UsersStat;
    using TCSOFT.DMS.MasterData.IServices;
    using TCSOFT.DMS.MasterData.Services;
    /// <summary>
    /// 用户统计
    /// </summary>
    public class UsersStatController : ApiController
    {
         ISystemServices _ISystemServices = null;
        /// <summary>
         /// 用户统计
        /// </summary>
         public UsersStatController() 
        {
            _ISystemServices = new SystemServices();
        }
        /// <summary>
         /// 得到用户统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
         public HttpResponseMessage GetUsersStatList(string UsersStatSearchDTO)
        {
            UsersStatSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<UsersStatSearchDTO>(UsersStatSearchDTO);
            ResultDTO<List<UsersStatResultDTO>> actionresult = new ResultDTO<List<UsersStatResultDTO>>();

            try
            {
                actionresult.Object = _ISystemServices.GetUsersStatList(dto);
                actionresult.SubmitResult = true;
                actionresult.rows = dto.rows;
                actionresult.page = dto.page;
                actionresult.Count = dto.Count;
            }
            catch (Exception ex)
            {
                actionresult.SubmitResult = false;
                actionresult.Message = ex.Message;
            }
            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 新增用户统计
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddUsersStat(UsersStatOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _ISystemServices.AddUsersStat(dto);
            }
            catch (Exception ex)
            {
                actionresult.SubmitResult = false;
                actionresult.Message = ex.Message;
            }

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 删除用户统计信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteUsersStat(string UsersStatResultDTO)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                UsersStatResultDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<UsersStatResultDTO>(UsersStatResultDTO);
                actionresult.SubmitResult = _ISystemServices.DeleteUsersStat(dto);
            }
            catch (Exception e)
            {
                actionresult.SubmitResult = false;
                actionresult.Message = e.Message;
            }

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
