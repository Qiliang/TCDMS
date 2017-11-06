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
    using TCSOFT.DMS.MasterData.IServices;
    using TCSOFT.DMS.MasterData.Services;
    public class FeedbackController : ApiController
    {
         /// <summary>
        /// 反馈管理
        /// </summary>
        ICommonServices _ICommonServices = null;
        /// <summary>
        /// 反馈管理
        /// </summary>
        public FeedbackController()
        {
            _ICommonServices = new CommonServices();
        }
        #region 反馈管理
        /// <summary>
        /// 得到反馈管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFeedbackList(string FeedbackSearchDTO)
        {
            FeedbackSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<FeedbackSearchDTO>(FeedbackSearchDTO);
            ResultDTO<List<FeedbackResultDTO>> actionresult = new ResultDTO<List<FeedbackResultDTO>>();

            try
            {
                actionresult.Object = _ICommonServices.GetFeedbackList(dto);
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
        /// 新增反馈管理
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddFeedback(FeedbackOperateDTO dto)
        {
            ResultDTO<int> actionresult = new ResultDTO<int>();
            try
            {
                actionresult.Object = _ICommonServices.AddFeedback(dto);
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
        /// 修改反馈管理(改变状态)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateFeedback(FeedbackOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult = _ICommonServices.UpdateFeedback(dto);
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
