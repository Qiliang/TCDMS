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
    using Common;
    using MasterData.DTO.Common;
    using MasterData.DTO.Product.OKCPriceInfo;
    public class OKCInfoController : ApiController
    {
        IProductServices _IIProductServices = null;
        /// <summary>
        /// OKC
        /// </summary>
        public OKCInfoController()
        {
            _IIProductServices = new ProductServices();
        }
        #region OKC
        /// <summary>
        /// 得到OKC信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetOKCList(string OKCPriceInfoSearchDTO )
        {
            OKCPriceInfoSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<OKCPriceInfoSearchDTO>(OKCPriceInfoSearchDTO);
            ResultDTO<List<OKCPriceInfoResultDTO>> actionresult = new ResultDTO<List<OKCPriceInfoResultDTO>>();
            actionresult.Object = _IIProductServices.GetOKCList(dto);
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
        /// 新增OKC
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddOKC(OKCPriceInfoOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                switch (dto.AddType)
                {
                    case 1://新增OKC号
                        actionresult.SubmitResult = _IIProductServices.AddOKC(dto);
                        break;
                    case 2://新增OKC产品特价
                        actionresult.SubmitResult = _IIProductServices.AddOKCProduct(dto);
                        break;
                    case 3://新增OKC经销商及最终客户
                        actionresult.SubmitResult = _IIProductServices.AddOKCDepAndCus(dto);
                        break;
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
        /// 修改OKC号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateOKC(OKCPriceInfoOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                switch (dto.UpType) 
                {
                    case 1://修改OKC号
                        actionresult.SubmitResult = _IIProductServices.UpdateOKC(dto);
                        break;
                    case 2://插入
                        actionresult.SubmitResult = _IIProductServices.OKCInfoInsert(dto);
                        break;
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
        /// 删除OKC
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteOKC(string OKCPriceInfoOperateDTO)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                OKCPriceInfoOperateDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<OKCPriceInfoOperateDTO>(OKCPriceInfoOperateDTO);
                switch (dto.DelType)
                {
                    case 1://删除OKC号
                        actionresult.SubmitResult = _IIProductServices.DeleteOKC(dto);
                        break;
                    case 2://删除OKC产品特价
                        actionresult.SubmitResult = _IIProductServices.DeleteOKCProduct(dto);
                        break;
                    case 3://删除OKC经销商及最终客户
                        actionresult.SubmitResult = _IIProductServices.DeleteOKCDepAndCus(dto);
                        break;
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
        #endregion
    }
}
