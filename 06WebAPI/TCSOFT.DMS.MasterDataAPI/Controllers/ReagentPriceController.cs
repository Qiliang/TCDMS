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
    using TCSOFT.DMS.MasterData.DTO.Product.ProductPriceInfo;
    /// <summary>
    /// 试剂价格
    /// </summary>
    public class ReagentPriceController : ApiController
    {
         IProductServices _IProductServices = null;
        /// <summary>
         /// 试剂价格
        /// </summary>
         public ReagentPriceController()
        {
            _IProductServices = new ProductServices();
        }
         #region 试剂价格
         /// <summary>
        /// 得到试剂产品
        /// </summary>
        /// <returns></returns>
        [HttpGet]
         public HttpResponseMessage GetReagentPriceList(string ProductPriceInfoSearchDTO)
        {

            ProductPriceInfoSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<ProductPriceInfoSearchDTO>(ProductPriceInfoSearchDTO);
            ResultDTO<List<ProductPriceInfoResultDTO>> actionresult = new ResultDTO<List<ProductPriceInfoResultDTO>>();
            actionresult.Object = _IProductServices.GetReagentPriceList(dto);
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
        /// 修改试剂价格
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateReagentPrice(ProductPriceInfoOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult = _IProductServices.UpdateReagentPrice(dto);
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
        /// 删除试剂价格
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteReagentPrice(string ProductPriceInfoOperateDTO)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                ProductPriceInfoOperateDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<ProductPriceInfoOperateDTO>(ProductPriceInfoOperateDTO);
                actionresult.SubmitResult = _IProductServices.DeleteReagentPrice(dto);
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
