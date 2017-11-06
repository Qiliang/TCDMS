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
    using TCSOFT.DMS.MasterData.DTO.Distributor.Distributor;
    using TCSOFT.DMS.MasterData.IServices;
    using TCSOFT.DMS.MasterData.Services;
    /// <summary>
    /// 经销商信息查询
    /// </summary>
    public class QueryDistributorBaseInfoController : ApiController
    {
        IDistributorServices _IDistributorServices = null;
        /// <summary>
        /// 经销商信息查询
        /// </summary>
        public QueryDistributorBaseInfoController() 
        {
            _IDistributorServices = new DistributorServices();
        }
        
        /// <summary>
        /// 得到经销商信息(开头字符为查询条件)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetDistributorBaseInfoByName(string DistributorName)
        {
            List<DistributorBaseDTO> actionresult = null;
            actionresult = _IDistributorServices.GetDistributorBaseInfoByName(DistributorName);

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
