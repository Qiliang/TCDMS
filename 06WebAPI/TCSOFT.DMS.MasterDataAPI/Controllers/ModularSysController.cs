using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using MasterData.IServices;
    using MasterData.Services;
    using Newtonsoft.Json;
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.System.ModularSysEmail;
    using TCSOFT.DMS.MasterData.DTO.Common;
    /// <summary>
    /// 模块管理员配置
    /// </summary>
    public class ModularSysController : ApiController
    {
        ISystemServices _ISystemServices = null;
        /// <summary>
        /// 模块管理员配置
        /// </summary>
        public ModularSysController()
        {
            _ISystemServices = new SystemServices();
        }
        #region
        /// <summary>
        /// 得到所有模块模块管理员信息
        /// </summary>
        /// <param name="ModularSearchDTO"></param>
        /// <returns></returns>
       [HttpGet]
        public HttpResponseMessage GetModularList(string ModularSearchDTO)
        {
            ModularSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<ModularSearchDTO>(ModularSearchDTO);
            List<ModularResultDTO> user = _ISystemServices.GetModularList(dto);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(user),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
       /// <summary>
       /// 修改模块管理员邮箱
       /// </summary>
       /// <param name="dto"></param>
       /// <returns></returns>
       [HttpPut]
       public HttpResponseMessage UpdateModularInfo(ModularOperateDTO dto)
       {
           ResultDTO<object> actionresult = new ResultDTO<object>();
           try
           {
               actionresult.SubmitResult = _ISystemServices.UpdateModularInfo(dto);
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