using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using MasterData.IServices;
    using MasterData.Services;
    using Newtonsoft.Json;
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using TCSOFT.DMS.MasterData.DTO.Role;
    /// <summary>
    /// 角色信息
    /// </summary>
    public class RoleController : ApiController
    {
        IUserAuthorityServices _IUserAuthorityServices = null;
        /// <summary>
        /// 角色信息
        /// </summary>
        public RoleController()
        {
            _IUserAuthorityServices = new UserAuthorityServices();
        }
        #region 角色
        /// <summary>
        /// 得到所有角色信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetRoleList(string RoleSearchDTO)
        {
            RoleSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<RoleSearchDTO>(RoleSearchDTO);
            List<RoleResultDTO> actionresult = new List<RoleResultDTO>();
            actionresult = _IUserAuthorityServices.GetRoleList(dto);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 得到一条角色信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetRole(int id)
        {
            ResultDTO<RoleResultDTO> actionresult = new ResultDTO<RoleResultDTO>();
            try
            {
                actionresult.Object = _IUserAuthorityServices.GetRole(id);
                actionresult.SubmitResult = true;
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
        /// <summary>
        /// 新增角色信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddRole(RoleOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult = _IUserAuthorityServices.AddRole(dto);
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
        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateRole(RoleOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult = _IUserAuthorityServices.UpdateRole(dto);
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
        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteRole(string RoleSearchDTO )
        {
            RoleSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<RoleSearchDTO>(RoleSearchDTO);
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult = _IUserAuthorityServices.DeleteRole(dto);
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
        #endregion
    }
}
