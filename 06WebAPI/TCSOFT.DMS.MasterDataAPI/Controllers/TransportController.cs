using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using DMS.MasterData.IServices;
    using DMS.MasterData.Services;
    using TCSOFT.DMS.MasterData.DTO.Transport;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using TCSOFT.DMS.Common;
    /// <summary>
    /// 运输方式
    /// </summary>
    public class TransportController : ApiController
    {
        IBaseInfoServices _IBaseInfoServices = null;
        public TransportController()
        {
            _IBaseInfoServices = new BaseInfoServices();
        }
        #region 运输方式
        /// <summary>
        /// 得到所有运输方式信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetTransport(string TransportSearchDTO )
        {
            TransportSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<TransportSearchDTO>(TransportSearchDTO);
            List<TransportResultDTO> resultdto = _IBaseInfoServices.GetTransport(dto);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(resultdto),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 得到一条运输方式信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetOneTransport(int id)
        {
            ResultDTO<TransportResultDTO> actionresult = new ResultDTO<TransportResultDTO>();
            try
            {
                actionresult.Object = _IBaseInfoServices.GetOneTransport(id);
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
        /// 运输方式新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddTransport(TransportOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult = _IBaseInfoServices.AddTransport(dto);
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
        /// 运输方式修改/停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateStopEnableTransport(TransportOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                if (dto.TransportStatus == null)
                {
                    //修改
                    actionresult.SubmitResult = _IBaseInfoServices.UpdateTransport(dto);
                }
                else
                {
                    //停启用
                    actionresult.SubmitResult = _IBaseInfoServices.StopEnableTransport(dto);
                }
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
