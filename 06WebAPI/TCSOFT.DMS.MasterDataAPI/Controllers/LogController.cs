using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterData.IServices;
using TCSOFT.DMS.MasterData.Services;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    public class LogController : ApiController
    {
        /// <summary>
        /// 日志管理
        /// </summary>
        ICommonServices _ICommonServices = null;
        /// <summary>
        /// 日志管理
        /// </summary>
        public LogController()
        {
            _ICommonServices = new CommonServices();
        }
        #region
        /// <summary>
        /// 得到日志信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetLog(string LogSearchDTO)
        {
            LogSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<LogSearchDTO>(LogSearchDTO);
            ResultDTO<List<LogDTO>> actionresult = new ResultDTO<List<LogDTO>>();

            actionresult.Object = _ICommonServices.GetLog(dto);
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
        #endregion
    }
}
