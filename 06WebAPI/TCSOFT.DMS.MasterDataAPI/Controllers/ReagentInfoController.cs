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
    using TCSOFT.DMS.MasterData.DTO.Common;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductInfo;
    using TCSOFT.DMS.MasterData.DTO.Product.ReagentInfo;
    /// <summary>
    /// 试剂产品
    /// </summary>
    public class ReagentInfoController : ApiController
    {
        IProductServices _IIProductServices = null;
        /// <summary>
        /// 试剂产品
        /// </summary>
        public ReagentInfoController()
        {
            _IIProductServices = new ProductServices();
        }
        #region 试剂产品
        /// <summary>
        /// 得到试剂产品
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetReagentInfoList(string ProductInfoSearchDTO)
        {

            ProductInfoSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<ProductInfoSearchDTO>(ProductInfoSearchDTO);
            ResultDTO<List<ProductInfoResultDTO>> actionresult = new ResultDTO<List<ProductInfoResultDTO>>();
            actionresult.Object = _IIProductServices.GetReagentInfoList(dto);
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
        /// <summary>
        /// 新增试剂产品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddReagentInfo(ProductInfoOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult = _IIProductServices.AddReagentInfo(dto);
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
        /// <summary>
        /// 修改试剂产品
        /// </summary>
        /// <param name="dto">UpType修改类型（1.修改 2.停启用）</param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateReagentInfo(ProductInfoOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                if (dto.UpType == 1)//正常修改
                {
                    actionresult.SubmitResult = _IIProductServices.UpdateReagentInfo(dto);
                }
                else if (dto.UpType == 2)//停启用
                {
                    actionresult.SubmitResult = _IIProductServices.StartOrStopReagentInfo(dto);
                }
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
        /// <summary>
        /// 删除试剂产品
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteReagentInfo(string ProductInfoOperateDTO)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                ProductInfoOperateDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<ProductInfoOperateDTO>(ProductInfoOperateDTO);
                actionresult.SubmitResult = _IIProductServices.DeleteReagentInfo(dto);
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
