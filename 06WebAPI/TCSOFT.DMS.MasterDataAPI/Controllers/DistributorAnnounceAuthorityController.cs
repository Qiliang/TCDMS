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
    using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorAnnounceAuthority;
    using TCSOFT.DMS.MasterData.IServices;
    using TCSOFT.DMS.MasterData.Services;
    /// <summary>
    /// 经销商公告授权
    /// </summary>
    public class DistributorAnnounceAuthorityController : ApiController
    {
        IDistributorServices _IDistributorServices = null;
        /// <summary>
        /// 经销商公告授权
        /// </summary>
        public DistributorAnnounceAuthorityController() 
        {
            _IDistributorServices = new DistributorServices();
        }
        #region 经销商公告授权
        /// <summary>
        /// 得到经销商公告授权
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetDistributorAnnounceAuthorityList(string DistributorAnnounceAuthoritySearchDTO)
        {

            DistributorAnnounceAuthoritySearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<DistributorAnnounceAuthoritySearchDTO>(DistributorAnnounceAuthoritySearchDTO);
            ResultDTO<List<DistributorAnnounceAuthorityResultDTO>> actionresult = new ResultDTO<List<DistributorAnnounceAuthorityResultDTO>>();

            try
            {
                actionresult.Object = _IDistributorServices.GetDistributorAnnounceAuthorityList(dto);
                actionresult.SubmitResult = true;
                actionresult.rows = dto.rows;
                actionresult.page = dto.page;
                actionresult.Count = dto.Count;
            }
            catch (Exception ex)
            {
                actionresult.SubmitResult = false;
                actionresult.Message = ex.Message;
            }
            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 新增经销商公告授权
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddDistributorAnnounceAuthority(DistributorAnnounceAuthorityOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult = _IDistributorServices.AddDistributorAnnounceAuthority(dto);
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
