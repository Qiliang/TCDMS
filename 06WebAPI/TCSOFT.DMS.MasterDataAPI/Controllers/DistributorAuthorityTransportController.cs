using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorAuthority;
using TCSOFT.DMS.MasterData.IServices;
using TCSOFT.DMS.MasterData.Services;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    public class DistributorAuthorityTransportController : ApiController
    {
        IDistributorServices _IDistributorServices = null;
        /// <summary>
        /// 经销商授权运输方式
        /// </summary>
        public DistributorAuthorityTransportController() 
        {
            _IDistributorServices = new DistributorServices();
        }
        #region 经销商授权运输方式
        /// <summary>
        /// 得到经销商授权运输方式信息
        /// </summary>
        /// <param name="DistributorAuthoritySearchDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetDistributorAuthorityTransport(string DistributorAuthoritySearchDTO)
        {

            DistributorAuthoritySearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<DistributorAuthoritySearchDTO>(DistributorAuthoritySearchDTO);
            List<DistributorTransportResultDTO> actionresult = null;
            actionresult = _IDistributorServices.GetDistributorAuthorityTransport(dto);

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
