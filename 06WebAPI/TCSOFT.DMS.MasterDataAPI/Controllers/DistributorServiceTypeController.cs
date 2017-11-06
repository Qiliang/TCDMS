using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using MasterData.IServices;
    using MasterData.Services;
    using MasterData.DTO.Distributor.DistributorServiceType;
    using DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    /// <summary>
    /// 经销商服务类型
    /// </summary>
    public class DistributorServiceTypeController : ApiController
    {
        IDistributorServices _IDistributorServices = null;
        public DistributorServiceTypeController() 
        {
            _IDistributorServices = new DistributorServices();
        }
        #region 经销商服务类型
        /// <summary>
        /// 得到所有经销商服务类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetDistributorServiceType(string DistributorServiceTypeSearchDTO)
        {
            List<DistributorServiceTypeResultDTO> DStyperesult = new List<DistributorServiceTypeResultDTO>();
            DistributorServiceTypeSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<DistributorServiceTypeSearchDTO>(DistributorServiceTypeSearchDTO);
  
            DStyperesult = _IDistributorServices.GetDistributorServiceType(dto);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(DStyperesult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 经销商服务类型新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddDistributorServiceType(DistributorServiceTypeOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _IDistributorServices.AddDistributorServiceType(dto);
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
        /// 经销商服务类型修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateDistributorServiceType(DistributorServiceTypeOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _IDistributorServices.UpdateDistributorServiceType(dto);
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
        /// 经销商服务类型删除
        /// </summary>
        /// <param name="DistributorServiceTypeOperateDTO"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteDistributorServiceType(string DistributorServiceTypeOperateDTO)
        {
            DistributorServiceTypeOperateDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<DistributorServiceTypeOperateDTO>(DistributorServiceTypeOperateDTO);
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _IDistributorServices.DeleteDistributorServiceType(dto);
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
