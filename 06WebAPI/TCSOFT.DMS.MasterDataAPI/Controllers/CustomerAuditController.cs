using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using TCSOFT.DMS.MasterData.DTO.CustomerAudit;
    using TCSOFT.DMS.MasterData.IServices;
    using TCSOFT.DMS.MasterData.Services;
    /// <summary>
    /// 客户审核
    /// </summary>
    public class CustomerAuditController : ApiController
    {
        ICustomerServices _ICustomerServices = null;
        /// <summary>
        /// 客户审核
        /// </summary>
        public CustomerAuditController()
        {
            _ICustomerServices = new CustomerServices();
        }
        #region 客户审核
        /// <summary>
        /// 得到客户审核列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCustomerAuditList(string CustomerAuditSearchDTO)
        {

            CustomerAuditSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<CustomerAuditSearchDTO>(CustomerAuditSearchDTO);
            ResultDTO<List<CustomerAuditResultDTO>> actionresult = new ResultDTO<List<CustomerAuditResultDTO>>();

            try
            {
                actionresult.Object = _ICustomerServices.GetCustomerAuditList(dto);
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
        /// 审核
        /// </summary>
        /// <param name="dto">Status（1.审核失败 2.审核成功）</param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage AuditCustomer(CustomerAuditOperateDTO dto)
        {

            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                if (dto.Status == 1)//审核失败
                {
                    actionresult.SubmitResult = _ICustomerServices.CustomerAuditFail(dto);
                }
                else if (dto.Status == 2)//审核成功
                {
                    actionresult.SubmitResult = _ICustomerServices.CustomerAuditSuccess(dto);
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
        #endregion
    }
}
