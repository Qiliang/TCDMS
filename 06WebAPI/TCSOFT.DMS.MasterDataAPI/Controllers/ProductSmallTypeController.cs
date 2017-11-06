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
    using TCSOFT.DMS.MasterData.DTO.Product.ProductSmallType;
    /// <summary>
    /// 产品小类
    /// </summary>
    public class ProductSmallTypeController : ApiController
    {
        IProductServices _IProductServices = null;
        public ProductSmallTypeController()
        {
            _IProductServices = new ProductServices();
        }
        #region 产品小类
        /// <summary>
        /// 得到所有产品小类信息(含模糊查询)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetProductSmallType(string ProductSmallTypeSearchDTO)
        {
            ProductSmallTypeSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<ProductSmallTypeSearchDTO>(ProductSmallTypeSearchDTO);
            List<ProductSmallTypeResultDTO> user = _IProductServices.GetProductSmallType(dto);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(user),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 得到一条产品小类信息
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetOneProductSmallType(int id)
        {
            ResultDTO<ProductSmallTypeResultDTO> resultdto = new ResultDTO<ProductSmallTypeResultDTO>();

            try
            {
                resultdto.SubmitResult = true;
                resultdto.Object = _IProductServices.GetOneProductSmallType(id);
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
        /// 产品小类新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddProductSmallType(ProductSmallTypeOperateDTO dto)
        {
            ResultDTO<object> resultdto = new ResultDTO<object>();

            try
            {
                resultdto.SubmitResult = _IProductServices.AddProductSmallType(dto);
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
        /// 产品小类修改/停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateStopEnableProductSmallType(ProductSmallTypeOperateDTO dto)
        {
            ResultDTO<object> resultdto = new ResultDTO<object>();

            try
            {
                if (dto.UpType == 1)//正常修改
                {
                    resultdto.SubmitResult = _IProductServices.UpdateProductSmallType(dto);
                }
                if (dto.UpType == 2)//停启用
                {
                    resultdto.SubmitResult = _IProductServices.StopEnableProductSmallType(dto);
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
        /// 产品小类删除
        /// </summary>
        /// <param name="UserOperate"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteProductSmallType(string ProductSmallTypeOperateDTO)
        {
            ResultDTO<object> resultdto = new ResultDTO<object>();

            try
            {
                ProductSmallTypeOperateDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<ProductSmallTypeOperateDTO>(ProductSmallTypeOperateDTO);
                resultdto.SubmitResult = _IProductServices.DeleteProductSmallType(dto);
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
