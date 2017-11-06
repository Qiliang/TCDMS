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
    using System.Data.Entity.Infrastructure;
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductLine;
    /// <summary>
    /// 产品线
    /// </summary>
    public class ProductLineController : ApiController
    {
        IProductServices _IProductServices = null;
        public ProductLineController()
        {
            _IProductServices = new ProductServices();
        }
        #region 产品线
        /// <summary>
        /// 得到所有产品线信息(含模糊查询)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetProductLine(string ProductLineSearchDTO)
        {
            ProductLineSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<ProductLineSearchDTO>(ProductLineSearchDTO);
            List<ProductLineResultDTO> user = _IProductServices.GetProductLine(dto);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(user),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 得到一条产品线信息
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetOneProductLine(int id)
        {
            ResultDTO<ProductLineResultDTO> resultdto = new ResultDTO<ProductLineResultDTO>();

            try
            {
                resultdto.Object = _IProductServices.GetOneProductLine(id);
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
        /// 产品线新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddProductLine(ProductLineOperateDTO dto)
        {
            ResultDTO<object> resultdto = new ResultDTO<object>();

            try
            {
                resultdto.SubmitResult = _IProductServices.AddProductLine(dto);
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
        /// 产品线修改/停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateStopEnableProductLine(ProductLineOperateDTO dto)
        {
            ResultDTO<object> resultdto = new ResultDTO<object>();

            try
            {
                if (dto.UpType == 1)//正常修改
                {
                    resultdto.SubmitResult = _IProductServices.UpdateProductLine(dto);
                }
                if (dto.UpType == 2)//停启用
                {
                    resultdto.SubmitResult = _IProductServices.StopEnableProductLine(dto);
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
        /// 产品线删除
        /// </summary>
        /// <param name="ProductLineOperateDTO"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteProductLine(string ProductLineOperateDTO)
        {
            ResultDTO<object> resultdto = new ResultDTO<object>();

            try
            {
                ProductLineOperateDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<ProductLineOperateDTO>(ProductLineOperateDTO);
                resultdto.SubmitResult =_IProductServices.DeleteProductLine(dto);
            }
            catch (DbUpdateException)
            {
                resultdto.SubmitResult = false;
                resultdto.Message = "此条信息已使用不可删除！";
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
