using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorPriceAuthority;
using TCSOFT.DMS.MasterData.IServices;
using TCSOFT.DMS.MasterData.Services;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    public class DistributorPriceAuthorityController : ApiController
    {
        IDistributorServices _IDistributorServices = null;
        /// <summary>
        /// 经销商管理
        /// </summary>
        public DistributorPriceAuthorityController() 
        {
            _IDistributorServices = new DistributorServices();
        }

        #region 经销商价格授权
        /// <summary>
        /// 得到经销商信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetDisOKCList(string DistributorPriceAuthoritySearchDTO)
        {
            DistributorPriceAuthoritySearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<DistributorPriceAuthoritySearchDTO>(DistributorPriceAuthoritySearchDTO);
            ResultDTO<List<DistributorOKCProduct>> actionresult = new ResultDTO<List<DistributorOKCProduct>>();
            actionresult.Object = _IDistributorServices.GetDisOKCList(dto);
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
