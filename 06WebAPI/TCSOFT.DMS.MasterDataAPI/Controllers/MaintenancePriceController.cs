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
    /// 维修产品价格
    /// </summary>
    public class MaintenancePriceController : ApiController
    {
        IProductServices _IProductServices = null;
        public MaintenancePriceController()
        {
            _IProductServices = new ProductServices();
        }
        #region 维修产品价格
        /// <summary>
        /// 得到所有维修产品价格信息(含模糊查询)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetMaintenancePrice(string ProductPriceInfoSearchDTO)
        {
            ProductPriceInfoSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<ProductPriceInfoSearchDTO>(ProductPriceInfoSearchDTO);
            ResultDTO<List<ProductPriceInfoResultDTO>> actionresult = new ResultDTO<List<ProductPriceInfoResultDTO>>();
            try
            {
                actionresult.Object = _IProductServices.GetMaintenancePrice(dto);
                actionresult.SubmitResult = true;
                actionresult.rows = dto.rows;
                actionresult.page = dto.page;
                actionresult.Count = dto.Count;
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
        /// 维修产品价格修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateMaintenancePrice(ProductPriceInfoOperateDTO dto)
        {
            ResultDTO<object> resultdto = new ResultDTO<object>();

            try
            {
                resultdto.SubmitResult = _IProductServices.UpdateMaintenancePrice(dto);
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
        /// 维修产品价格删除
        /// </summary>
        /// <param name="ProductPriceInfoOperateDTO"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteMaintenancePrice(string ProductPriceInfoOperateDTO)
        {
            ResultDTO<object> resultdto = new ResultDTO<object>();

            try
            {
                ProductPriceInfoOperateDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<ProductPriceInfoOperateDTO>(ProductPriceInfoOperateDTO);
                resultdto.SubmitResult = _IProductServices.DeleteMaintenancePrice(dto);
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
