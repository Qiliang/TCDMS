using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using Newtonsoft.Json;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using TCSOFT.DMS.MasterData.DTO.Customer;
    using TCSOFT.DMS.MasterData.IServices;
    using TCSOFT.DMS.MasterData.Services;
    public class CustomerInfoController : ApiController
    {
        ICustomerServices _ICustomerServices = null;
        /// <summary>
        /// 客户信息
        /// </summary>
        public CustomerInfoController()
        {
            _ICustomerServices = new CustomerServices();
        }
        #region 客户信息
        /// <summary>
        /// 得到所有客户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCustomerList(string CustomerSearchDTO)
        {

            CustomerSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<CustomerSearchDTO>(CustomerSearchDTO);
            
            ResultDTO<List<CustomerResultDTO>> actionresult = new ResultDTO<List<CustomerResultDTO>>();

            try
            {
                if (dto.QueryType == 0)//查询客户信息
                {
                    actionresult.Object = _ICustomerServices.GetCustomerList(dto);
                }
                else if (dto.QueryType == 1)//查询相似客户
                {
                    actionresult.Object = _ICustomerServices.GetSimilarCustomerList(dto);
                }
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
        /// 新增客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddCustomer(CustomerOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _ICustomerServices.AddCustomer(dto);
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
        /// 修改客户信息
        /// </summary>
        /// <param name="dto">UpType修改类型（1.修改 2.停启用）</param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateCustomer(CustomerOperateDTO dto)
        {

            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                if (dto.UpType == 1)//正常修改
                {
                    actionresult.SubmitResult = _ICustomerServices.UpdateCustomer(dto);
                }
                else if (dto.UpType == 2)//停启用
                {
                    actionresult.SubmitResult = _ICustomerServices.ChangeStatusCustomer(dto);
                }
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
        /// 删除客户信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteCustomer(string CustomerOperateDTO)
        {
            CustomerOperateDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<CustomerOperateDTO>(CustomerOperateDTO);
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _ICustomerServices.DeleteCustomer(dto);
            }
            catch (DbUpdateException ex)
            {
                actionresult.SubmitResult = false;
                actionresult.Message = "此条信息已使用不可删除！";
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
        #endregion
    }
}
