using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterData.DTO.Product.ProductType;
using TCSOFT.DMS.MasterData.IServices;
using TCSOFT.DMS.MasterData.Services;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    /// <summary>
    /// 产品类型
    /// </summary>
    public class ProductTypeController : ApiController
    {
        IProductServices _IIProductServices = null;
        /// <summary>
        /// 产品类型
        /// </summary>
        public ProductTypeController()
        {
            _IIProductServices = new ProductServices();
        }
        #region 产品类型
        /// <summary>
        /// 得到产品类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetProductTypeList(string ProductTypeSearchDTO)
        {

            ProductTypeSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<ProductTypeSearchDTO>(ProductTypeSearchDTO);
            List<ProductTypeResultDTO> actionresult = new List<ProductTypeResultDTO>();
            actionresult = _IIProductServices.GetProductTypeList(dto);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 得到一条产品类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetProductType(int id)
        {
            ResultDTO<ProductTypeResultDTO> actionresult = new ResultDTO<ProductTypeResultDTO>();
            try
            {
                actionresult.Object = _IIProductServices.GetProductType(id);
                actionresult.SubmitResult = true;
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
        /// 新增产品类型
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddProductType(ProductTypeOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult =_IIProductServices.AddProductType(dto);
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
        /// 修改产品类型
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateProductType(ProductTypeOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult = _IIProductServices.UpdateProductType(dto);
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
        /// 删除产品类型
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteProductType(string ProductTypeSearchDTO)
        {
            ProductTypeSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<ProductTypeSearchDTO>(ProductTypeSearchDTO);
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult = _IIProductServices.DeleteProductType(dto);
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
          