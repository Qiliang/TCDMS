using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using Newtonsoft.Json;
using TCSOFT.DMS.MasterData.DTO.Product.ProductLine;
using TCSOFT.DMS.MasterData.IServices;
using TCSOFT.DMS.MasterData.Services;
    public class QueryProductLineBaseInfoController : ApiController
    {
        IProductServices _IProductServices = null;
        public QueryProductLineBaseInfoController()
        {
            _IProductServices = new ProductServices();
        }

        /// <summary>
        /// 得到所有产品线基本信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetProductLineBaseInfo()
        {
            List<ProductLineBaseDTO> actionresult = null;
            actionresult = _IProductServices.GetProductLineBaseInfo();

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
