using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using Newtonsoft.Json;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductType;
    using TCSOFT.DMS.MasterData.IServices;
    using TCSOFT.DMS.MasterData.Services;
    public class QueryProductTypeBaseInfoController : ApiController
    {
        IProductServices _IProductServices = null;
        public QueryProductTypeBaseInfoController()
        {
            _IProductServices = new ProductServices();
        }

        /// <summary>
         /// 得到所有产品类型基本信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetProductTypeBaseInfo()
        {
            List<ProductTypeBaseDTO> actionresult = null;
            actionresult = _IProductServices.GetProductTypeBaseInfo();

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
