using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net;
using System.Web.Http;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using MasterData.IServices;
    using MasterData.Services;
    using Newtonsoft.Json;
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using TCSOFT.DMS.MasterData.DTO.System.OperationSysEmail;
    /// <summary>
    /// 运维管理员配置
    /// </summary>
    public class OperationSysController : ApiController
    {
        ISystemServices _ISystemServices = null;
        /// <summary>
        /// 运维管理员配置
        /// </summary>
        public OperationSysController() 
        {
            _ISystemServices = new SystemServices();
        }

        #region 运维管理员配置
        /// <summary>
        /// 修改模块管理员邮箱
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateOperationInfo(OperationOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult = _ISystemServices.UpdateOperationInfo(dto);
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