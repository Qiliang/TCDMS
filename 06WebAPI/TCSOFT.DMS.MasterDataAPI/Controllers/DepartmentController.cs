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
    using System.Data.Entity.Infrastructure;
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    /// <summary>
    /// 部门信息
    /// </summary>
    public class DepartmentController : ApiController
    {
         IUserAuthorityServices _IUserAuthorityServices = null;
        /// <summary>
         /// 部门信息
        /// </summary>
         public DepartmentController()
        {
            _IUserAuthorityServices = new UserAuthorityServices();
        }
        #region 部门信息
        /// <summary>
        /// 得到所有部门信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetDepartmentList()
        {
            List<DepartmentResultDTO> actionresult = new List<DepartmentResultDTO>();
            actionresult = _IUserAuthorityServices.GetDepartmentList();

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 得到一条部门信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetDepartment(int id)
        {
            ResultDTO<DepartmentResultDTO> actionresult = new ResultDTO<DepartmentResultDTO>();
            try
            {
                actionresult.Object = _IUserAuthorityServices.GetDepartment(id);
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
        /// 新增部门信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddDepartment(DepartmentOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult = _IUserAuthorityServices.AddDepartment(dto);
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
        /// 修改部门信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateDepartment(DepartmentOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult = _IUserAuthorityServices.UpdateDepartment(dto);
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
        /// 删除部门信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteDepartment(string DepartmentSearchDTO)
        {
            DepartmentSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<DepartmentSearchDTO>(DepartmentSearchDTO);
            
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult = _IUserAuthorityServices.DeleteDepartment(dto);
            }
            catch (DbUpdateException)
            {
                actionresult.SubmitResult = false;
                actionresult.Message = "此条信息已使用不可删除！";
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
        /// 得到所有部门信息
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetDepartmentlist(int i)
        {
            List<DepartmentResultDTO> actionresult = new List<DepartmentResultDTO>();
            actionresult = _IUserAuthorityServices.GetDepartment();

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
