using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterData.DTO.Product.OKCPriceInfo;
using TCSOFT.DMS.MasterData.IServices;
using TCSOFT.DMS.MasterData.Services;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    
    /// <summary>
    /// OKC产品特价
    /// </summary>
    public class OKCPriceInfoController : ApiController
    {
        IProductServices _IIProductServices = null;
        /// <summary>
        /// OKC产品特价
        /// </summary>
        public OKCPriceInfoController()
        {
            _IIProductServices = new ProductServices();
        }
        #region OKC产品特价
        /// <summary>
        /// 得到OKC产品特价
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetOKCPrice(string OKCPriceInfoSearchDTO)
        {
            OKCPriceInfoSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<OKCPriceInfoSearchDTO>(OKCPriceInfoSearchDTO);
            ResultDTO<List<OKCProductResult>> actionresult = new ResultDTO<List<OKCProductResult>>();
            actionresult.Object = _IIProductServices.GetOKCPrice(dto);
            actionresult.SubmitResult = true;
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
