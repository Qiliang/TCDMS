using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;


namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using MasterData.DTO;
    using MasterData.IServices;
    using MasterData.Services;
    using MasterData.DTO.Area;
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    /// <summary>
    /// 行政区划控制器
    /// </summary>
    public class RegionController : ApiController
    {
         IRegionServices _IRegionServices = null;
        /// <summary>
         /// 行政区划控制器
        /// </summary>
        public RegionController()
        {
            _IRegionServices = new RegionServices();
        }
        #region 行政区划
        /// <summary>
        /// 得到所有行政区划
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetRegionList()
        {
            List<RegionResultDTO> RegionList = _IRegionServices.GetRegionList();

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(RegionList),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 新增行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddRegion(RegionOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _IRegionServices.AddRegion(dto);
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
        /// 修改行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateRegion(RegionOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _IRegionServices.UpdateRegion(dto);
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
        /// 删除行政区划
        /// </summary>
        /// <param name="RegionSearchDTO"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteRegion(string RegionSearchDTO)
        {
            RegionSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<RegionSearchDTO>(RegionSearchDTO);
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _IRegionServices.DeleteRegion(dto);
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
        #endregion
    }
}
