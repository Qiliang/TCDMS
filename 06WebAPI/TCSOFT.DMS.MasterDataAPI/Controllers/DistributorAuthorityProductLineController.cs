using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorAuthority;
using TCSOFT.DMS.MasterData.IServices;
using TCSOFT.DMS.MasterData.Services;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    public class DistributorAuthorityProductLineController : ApiController
    {
        IDistributorServices _IDistributorServices = null;
        /// <summary>
        /// 经销商授权产品线
        /// </summary>
        public DistributorAuthorityProductLineController() 
        {
            _IDistributorServices = new DistributorServices();
        }
        #region 经销商授权产品线
        /// <summary>
        /// 得到经销商授权产品线信息
        /// </summary>
        /// <param name="DistributorAuthoritySearchDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetDistributorAuthorityProductLine(string DistributorAuthoritySearchDTO)
        {

            DistributorAuthoritySearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<DistributorAuthoritySearchDTO>(DistributorAuthoritySearchDTO);
            ResultDTO<List<DistributorProductLineResultDTO>> actionresult = new ResultDTO<List<DistributorProductLineResultDTO>>();
            actionresult.Object = _IDistributorServices.GetDistributorAuthorityProductLine(dto);
            actionresult.Count = dto.Count;
            actionresult.rows = dto.rows;

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
