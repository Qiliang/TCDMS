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
    using TCSOFT.DMS.MasterData.DTO.Message;
    using TCSOFT.DMS.MasterData.IServices;
    using TCSOFT.DMS.MasterData.Services;
    /// <summary>
    /// 短信统计
    /// </summary>
    public class MessageStatController : ApiController
    {
        ISystemServices _ISystemServices = null;
        /// <summary>
        /// 短信统计
        /// </summary>
        public MessageStatController() 
        {
            _ISystemServices = new SystemServices();
        }
        /// <summary>
        /// 得到短信统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetMessageStatList(string MessageSearchDTO)
        {
            MessageSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<MessageSearchDTO>(MessageSearchDTO);
            ResultDTO<List<MessageResultDTO>> actionresult = new ResultDTO<List<MessageResultDTO>>();

            try
            {
                actionresult.Object = _ISystemServices.GetMessageStatList(dto);
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
        /// 新增短信统计
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddMessageStat(List<MessageOperateDTO> dtolist)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _ISystemServices.AddMessageStat(dtolist);
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
        /// 删除短信统计
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteMessageStat(string MessageResultDTO)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                MessageResultDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<MessageResultDTO>(MessageResultDTO);
                actionresult.SubmitResult = _ISystemServices.DeleteMessageStat(dto);
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
