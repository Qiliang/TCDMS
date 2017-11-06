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
    /// <summary>
    /// 维修产品清单
    /// </summary>
    public class MaintenanceInfoController : ApiController
    {
        IProductServices _IProductServices = null;
        /// <summary>
        ///  维修产品清单
        /// </summary>
        public MaintenanceInfoController()
        {
            _IProductServices = new ProductServices();
        }
        #region 维修产品清单
        /// <summary>
        /// 得到所有维修产品清单信息(含模糊查询)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetMaintenanceInfo(string ProductInfoSearchDTO)
        {
            ProductInfoSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<ProductInfoSearchDTO>(ProductInfoSearchDTO);
            ResultDTO<List<ProductInfoResultDTO>> actionresult = new ResultDTO<List<ProductInfoResultDTO>>();

            try
            {
                actionresult.Object = _IProductServices.GetMaintenanceInfo(dto);
                actionresult.SubmitResult = true;
                actionresult.rows = dto.rows;
                actionresult.page = dto.page;
                actionresult.Count= dto.Count;
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
        /// 维修产品清单新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddMaintenanceInfo(ProductInfoOperateDTO dto)
        {
            ResultDTO<object> resultdto = new ResultDTO<object>();

            try
            {
                resultdto.SubmitResult = _IProductServices.AddMaintenanceInfo(dto);
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
        /// 维修产品清单修改/停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateStopEnableMaintenanceInfo(ProductInfoOperateDTO dto)
        {
            ResultDTO<object> resultdto = new ResultDTO<object>();

            try
            {
                if (dto.UpType == 1)//正常修改
                {
                    resultdto.SubmitResult = _IProductServices.UpdateMaintenanceInfo(dto);
                }
                if (dto.UpType == 2)//停启用
                {
                    resultdto.SubmitResult = _IProductServices.StopEnableMaintenanceInfo(dto);
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
        /// 维修产品清单删除
        /// </summary>
        /// <param name="ProductInfoOperateDTO"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteMaintenanceInfo(string ProductInfoOperateDTO)
        {
            ResultDTO<object> resultdto = new ResultDTO<object>();

            try
            {
                ProductInfoOperateDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<ProductInfoOperateDTO>(ProductInfoOperateDTO);
                resultdto.SubmitResult = _IProductServices.DeleteMaintenanceInfo(dto);
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
