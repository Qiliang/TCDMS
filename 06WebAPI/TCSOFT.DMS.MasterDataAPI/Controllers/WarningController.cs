using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.MasterData.IServices;
using TCSOFT.DMS.MasterData.Services;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO.Common;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    /// <summary>
    /// 提醒管理
    /// </summary>
    public class WarningController : ApiController
    {
        /// <summary>
        /// 提醒管理
        /// </summary>
        ICommonServices _ICommonServices = null;
        /// <summary>
        /// 提醒管理
        /// </summary>
        public WarningController()
        {
            _ICommonServices = new CommonServices();
        }
        #region
        /// <summary>
        /// 得到提醒信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetWarningInfo(string WarningSearchDTO)
        {
            WarningSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<WarningSearchDTO>(WarningSearchDTO);
            ResultDTO<List<WarningDTO>> actionresult = new ResultDTO<List<WarningDTO>>();

            actionresult.Object = _ICommonServices.GetWarningInfo(dto);
            actionresult.SubmitResult = true;
            actionresult.rows = dto.rows;
            actionresult.page = dto.page;
            actionresult.Count = dto.Count;

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 新增提醒管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddWarningInfo(WarningDTO dto)
        {
            ResultDTO<object> resultdto = new ResultDTO<object>();
            try
            {
                resultdto.SubmitResult = _ICommonServices.AddWarningInfo(dto);
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
        /// 删除一条提醒信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteWarningInfo(string WarningSearchDTO)
        {
            WarningSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<WarningSearchDTO>(WarningSearchDTO);
            var actionresult = _ICommonServices.DeleteWarningInfo(dto);

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