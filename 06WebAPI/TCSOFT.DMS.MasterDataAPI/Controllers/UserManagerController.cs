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
    using MasterData.DTO.User;
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using System.Data.Entity.Infrastructure;
    public class UserManagerController : ApiController
    {
        IUserAuthorityServices _lUserAuthorityServices = null;
        public UserManagerController()
        {
            _lUserAuthorityServices = new UserAuthorityServices();
        }

        /// <summary>
        /// 得到所有用户信息(含模糊查询)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetUser(string UserSearchDTO)
        {
           UserSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<UserSearchDTO>(UserSearchDTO);
           ResultDTO<List<UserResultDTO>> resultdto = new ResultDTO<List<UserResultDTO>>();
           List<UserResultDTO> user = _lUserAuthorityServices.GetUser(dto);
           resultdto.Object = user;
           resultdto.Count = dto.Count;
           resultdto.rows = dto.rows;

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(resultdto),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 得到一条用户信息
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetOneUser(int id)
        {
            ResultDTO<UserResultDTO> resultdto = new ResultDTO<UserResultDTO>();
            try
            {
                resultdto.Object = _lUserAuthorityServices.GetOneUser(id);
                resultdto.SubmitResult = true;
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
        /// <summary>
        /// 用户信息新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddUser(UserOperate dto)
        {
            ResultDTO<object> resultdto = new ResultDTO<object>();
            try 
            {
                resultdto.SubmitResult = _lUserAuthorityServices.AddUser(dto);
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
        /// <summary>
        /// 用户信息修改/停启用
        /// </summary>
        /// <param name="dto">Uptype（3.新增客户管理员  4.删除客户管理员  5.修改模块管理员邮箱）</param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateStopEnableUser(UserOperate dto)
        {
            ResultDTO<object> resultdto = new ResultDTO<object>();
            try
            {
                if (dto.Uptype == 3)//新增客户管理员 
                {
                    resultdto.SubmitResult = _lUserAuthorityServices.AddCustomerAdmin(dto);
                }
                else if (dto.Uptype == 4)//删除客户管理员
                {
                    resultdto.SubmitResult = _lUserAuthorityServices.DeleteCustomerAdmin(dto);
                }
                else if (dto.Uptype == 5) //修改模块管理员邮箱
                {
                    resultdto.SubmitResult = _lUserAuthorityServices.UpdateModularAdmin(dto);
                }
                else if (dto.IsActive == null)
                {
                    resultdto.SubmitResult = _lUserAuthorityServices.UpdateUser(dto);
                }
                else
                {
                    resultdto.SubmitResult = _lUserAuthorityServices.StopEnableUser(dto);
                }

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
        /// <summary>
        /// 用户信息删除
        /// </summary>
        /// <param name="UserOperate"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteUser(string UserOperate)
        {
            ResultDTO<UserResultDTO> resultdto = new ResultDTO<UserResultDTO>();
            try
            {
                UserOperate dto = TransformHelper.ConvertBase64JsonStringToDTO<UserOperate>(UserOperate);
                resultdto.SubmitResult = _lUserAuthorityServices.DeleteUser(dto);
            }
            catch (DbUpdateException)
            {
                resultdto.SubmitResult = false;
                resultdto.Message = "此条信息已使用不可删除！";
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
