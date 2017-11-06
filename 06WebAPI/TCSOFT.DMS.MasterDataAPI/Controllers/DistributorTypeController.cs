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
    using MasterData.DTO.Distributor.DistributorType;
    using DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    /// <summary>
    /// 经销商类别
    /// </summary>
    public class DistributorTypeController : ApiController
    {
        IDistributorServices _IDistributorServices = null;
        /// <summary>
        /// 经销商类别
        /// </summary>
        public DistributorTypeController() 
        {
            _IDistributorServices = new DistributorServices();
        }
        #region
        /// <summary>
        /// 得到所有经销商类别
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetDepartmentList(string DistributorTypeSearchDTO)
        {
            List<DistributorTypeResultDTO> Dtyperesult = new List<DistributorTypeResultDTO>();
            DistributorTypeSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<DistributorTypeSearchDTO>(DistributorTypeSearchDTO);
            Dtyperesult = _IDistributorServices.GetDistributorType(dto);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(Dtyperesult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 经销商类别新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddDistributorType(DistributorTypeOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _IDistributorServices.AddDistributorType(dto);
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
        /// 经销商类别修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateDistributorType(DistributorTypeOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _IDistributorServices.UpdateDistributorType(dto);
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
        /// 经销商类别删除
        /// </summary>
        /// <param name="DistributorTypeOperateDTO"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteDistributorType(string DistributorTypeOperateDTO)
        {
            DistributorTypeOperateDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<DistributorTypeOperateDTO>(DistributorTypeOperateDTO);
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _IDistributorServices.DeleteDistributorType(dto);
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
