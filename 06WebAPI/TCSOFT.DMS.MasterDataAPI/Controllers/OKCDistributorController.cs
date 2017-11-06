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
    public class OKCDistributorController : ApiController
    {
        IProductServices _IIProductServices = null;
        /// <summary>
        /// OKC经销商及最终客户
        /// </summary>
        public OKCDistributorController()
        {
            _IIProductServices = new ProductServices();
        }
        #region OKC经销商及最终客户
        /// <summary>
        /// 得到OKC经销商及最终客户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetOKCDistributor(string OKCPriceInfoSearchDTO)
        {

            OKCPriceInfoSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<OKCPriceInfoSearchDTO>(OKCPriceInfoSearchDTO);
            ResultDTO<List<OKCDistributorResult>> actionresult = new ResultDTO<List<OKCDistributorResult>>();
            actionresult.Object = _IIProductServices.GetOKCDistributor(dto);
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
