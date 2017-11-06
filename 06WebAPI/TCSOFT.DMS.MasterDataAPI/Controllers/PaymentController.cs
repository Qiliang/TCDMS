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
    using MasterData.DTO.Payment;
    using Newtonsoft.Json;
    using Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using System.Data.Entity.Infrastructure;
    /// <summary>
    /// 付款条款
    /// </summary>
    public class PaymentController : ApiController
    {
         IBaseInfoServices _IBaseInfoServices = null;
        /// <summary>
        /// 付款条款
        /// </summary>
         public PaymentController()
        {
            _IBaseInfoServices = new BaseInfoServices();
        }
        #region 付款条款
        /// <summary>
        /// 得到所有付款条款信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
         public HttpResponseMessage GetPaymentList(string PaymentSearchDTO)
        {

            PaymentSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<PaymentSearchDTO>(PaymentSearchDTO);
            List<PaymentResultDTO> actionresult = new List<PaymentResultDTO>();
            actionresult = _IBaseInfoServices.GetPaymentList(dto);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 得到一条付款条款信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetPayment(int id)
        {
            ResultDTO<PaymentResultDTO> actionresult = new ResultDTO<PaymentResultDTO>();

            try
            {
                actionresult.Object = _IBaseInfoServices.GetPayment(id);
                actionresult.SubmitResult=true;
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
        /// 新增付款条款信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddPayment(PaymentOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _IBaseInfoServices.AddPayment(dto);
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
        /// 修改付款条款信息
        /// </summary>
        /// <param name="dto">UpType修改类型（1.修改 2.停启用）</param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdatePayment(PaymentOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                if (dto.UpType == 1)//正常修改
                {
                    actionresult.SubmitResult = _IBaseInfoServices.UpdatePayment(dto);
                }
                else if (dto.UpType == 2)//停启用
                {
                    actionresult.SubmitResult = _IBaseInfoServices.StartOrStopPayment(dto);
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
        /// 删除付款条款信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeletePayment(string PaymentSearchDTO)
        {
            PaymentSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<PaymentSearchDTO>(PaymentSearchDTO);
           
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _IBaseInfoServices.DeletePayment(dto);
            }
            catch (DbUpdateException)
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
