using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using MasterData.IServices;
    using Newtonsoft.Json;
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using TCSOFT.DMS.MasterData.DTO.Product.InstrumentType;
    using TCSOFT.DMS.MasterData.Services;
    /// <summary>
    /// 仪器类型
    /// </summary>
    public class InstrumentTypeController : ApiController
    {
        IProductServices _IIProductServices = null;
        /// <summary>
        /// 仪器类型
        /// </summary>
        public InstrumentTypeController()
        {
            _IIProductServices = new ProductServices();
        }
        #region 仪器类型
        /// <summary>
        /// 得到仪器类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetInstrumentTypeList()
        {
            List<InstrumentTypeResultDTO> actionresult = new List<InstrumentTypeResultDTO>();
            actionresult = _IIProductServices.GetInstrumentTypeList();

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 得到一条仪器类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetInstrumentType(int id)
        {
            ResultDTO<InstrumentTypeResultDTO> actionresult = new ResultDTO<InstrumentTypeResultDTO>();
            try
            {
                actionresult.Object = _IIProductServices.GetInstrumentType(id);
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
        /// 新增仪器类型
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddInstrumentType(InstrumentTypeOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult = _IIProductServices.AddInstrumentType(dto);
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
        /// 修改仪器类型
        /// </summary>
        /// <param name="dto">UpType修改类型（1.修改 2.停启用）</param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateInstrumentType(InstrumentTypeOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult = _IIProductServices.UpdateInstrumentType(dto);
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
        /// 删除仪器类型
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteProductType(string InstrumentTypeSearchDTO)
        {
            InstrumentTypeSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<InstrumentTypeSearchDTO>(InstrumentTypeSearchDTO);
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult = _IIProductServices.DeleteInstrumentType(dto);
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
