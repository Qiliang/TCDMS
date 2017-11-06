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
    using DMS.Common;
    using DMS.MasterData.DTO.Product.ProductModel;
    using TCSOFT.DMS.MasterData.DTO.Common;
    /// <summary>
    /// 产品型号
    /// </summary>
    public class ProductModelController : ApiController
    {
        IProductServices _IProductServices = null;
        public ProductModelController()
        {
            _IProductServices = new ProductServices();
        }
        #region 产品型号(仪器型号)
        /// <summary>
        /// 得到所有产品型号信息(含模糊查询)
        /// </summary>
        /// <param name="ProductModelSearchDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetProductModel(string ProductModelSearchDTO)
        {
            ProductModelSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<ProductModelSearchDTO>(ProductModelSearchDTO);
            List<ProductModelResultDTO> user = _IProductServices.GetProductModel(dto);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(user),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 得到一条产品型号信息
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetOneProductModel(int id)
        {
            ResultDTO<ProductModelResultDTO> resultdto = new ResultDTO<ProductModelResultDTO>();

            try
            {
                resultdto.Object = _IProductServices.GetOneProductModel(id);
                resultdto.SubmitResult = true;
            }
            catch (Exception ex)
            {
                resultdto.SubmitResult = false;
                resultdto.Message = ex.Message;
            }

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(resultdto),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 产品型号新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddProductModel(ProductModelOperateDTO dto)
        {
            ResultDTO<ProductModelResultDTO> resultdto = new ResultDTO<ProductModelResultDTO>();

            try
            {
                resultdto.SubmitResult = _IProductServices.AddProductModel(dto);
            }
            catch (Exception ex)
            {
                resultdto.SubmitResult = false;
                resultdto.Message = ex.Message;
            }

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(resultdto),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 产品型号修改/停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateStopEnableProductModel(ProductModelOperateDTO dto)
        {
            ResultDTO<ProductModelResultDTO> resultdto = new ResultDTO<ProductModelResultDTO>();

            try
            {
                if (dto.UpType == 1)//正常修改
                {
                    resultdto.SubmitResult = _IProductServices.UpdateProductModel(dto);
                }
                if (dto.UpType == 2)//停启用
                {
                    resultdto.SubmitResult = _IProductServices.StopEnableProductModel(dto);
                }
            }
            catch (Exception ex)
            {
                resultdto.SubmitResult = false;
                resultdto.Message = ex.Message;
            }

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(resultdto),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 产品型号删除
        /// </summary>
        /// <param name="ProductModelOperateDTO"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteProductModel(string ProductModelOperateDTO)
        {
            ResultDTO<ProductModelResultDTO> resultdto = new ResultDTO<ProductModelResultDTO>();

            try
            {
                ProductModelOperateDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<ProductModelOperateDTO>(ProductModelOperateDTO);
                resultdto.SubmitResult = _IProductServices.DeleteProductModel(dto);
            }
            catch (Exception ex)
            {
                resultdto.SubmitResult = false;
                resultdto.Message = ex.Message;
            }

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(resultdto),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        #endregion
    }
}
