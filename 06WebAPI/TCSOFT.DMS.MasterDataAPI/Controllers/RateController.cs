using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using MasterData.IServices;
    using MasterData.Services;
    using Newtonsoft.Json;
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.RateDTO;
    /// <summary>
    /// 汇率信息
    /// </summary>
    public class RateController : ApiController
    {
        IBaseInfoServices _IBaseInfoServices = null;
        /// <summary>
        /// 汇率信息
        /// </summary>
        public RateController()
        {
            _IBaseInfoServices = new BaseInfoServices();
        }
        #region 汇率
        /// <summary>
        /// 得到所有汇率信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetRateList()
        {
            List<RateResultDTO> actionresult = new List<RateResultDTO>();
            actionresult = _IBaseInfoServices.GetRateList();

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 得到一条汇率信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetOneRate(int id)
        {
            RateResultDTO actionresult = null;
            actionresult = _IBaseInfoServices.GetRate(id);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 新增汇率信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddRate(RateOperateDTO dto)
        {
            var actionresult = _IBaseInfoServices.AddRate(dto);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 修改汇率信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateRate(RateOperateDTO dto)
        {
            var actionresult = _IBaseInfoServices.UpdateRate(dto);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 删除汇率信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteRate(string RateSearchDTO )
        {
            RateSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<RateSearchDTO>(RateSearchDTO);
            var actionresult = _IBaseInfoServices.DeleteRate(dto);

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
