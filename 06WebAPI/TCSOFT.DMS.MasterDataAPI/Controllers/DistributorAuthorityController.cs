using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using DMS.MasterData.IServices;
    using DMS.MasterData.Services;
    using DMS.Common;
    using DMS.MasterData.DTO.Common;
    using DMS.MasterData.DTO.Distributor.DistributorAuthority;
    public class DistributorAuthorityController : ApiController
    {
        IDistributorServices _IDistributorServices = null;
        /// <summary>
        /// 经销商授权
        /// </summary>
        public DistributorAuthorityController() 
        {
            _IDistributorServices = new DistributorServices();
        }
        #region 经销商授权
        /// <summary>
        /// 得到经销商授权信息
        /// </summary>
        /// <param name="DistributorAuthoritySearchDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetDistributorAuthority(string DistributorAuthoritySearchDTO)
        {

            DistributorAuthoritySearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<DistributorAuthoritySearchDTO>(DistributorAuthoritySearchDTO);
            List<DistributorAuthorityResultDTO> actionresult = null;
            actionresult = _IDistributorServices.GetDistributorAuthority(dto);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 授权经销商
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddDistributorAuthority(DistributorAuthorityOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                switch (dto.AddType) 
                {
                    case 1://授权经销商付款条款
                        actionresult.SubmitResult = _IDistributorServices.DistributorPayAuthority(dto);
                        break;
                    case 2://授权经销商运输方式
                        actionresult.SubmitResult = _IDistributorServices.DistributorTransportAuthority(dto);
                        break;
                    case 3://授权经销商产品线
                        actionresult.SubmitResult = _IDistributorServices.DistributorProductLineAuthority(dto);
                        break;
                    case 4://授权经销商授权产品线区域
                        actionresult.SubmitResult = _IDistributorServices.DistributorProductLineRegionAuthority(dto);
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
        /// 经销商授权修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdataDistributorAuthority(DistributorAuthorityOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                switch (dto.UpType)
                {
                    case 1://经销商订货权限
                        actionresult.SubmitResult = _IDistributorServices.DistributorOrderGoodsAuthority(dto);
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
        /// 删除经销商信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteDistributorAuthority(string DistributorAuthorityOperateDTO)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                DistributorAuthorityOperateDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<DistributorAuthorityOperateDTO>(DistributorAuthorityOperateDTO);
                switch (dto.DelType)
                {
                    case 1://删除经销商付款条款
                        actionresult.SubmitResult = _IDistributorServices.DeleteDistributorPayAuthority(dto);
                        break;
                    case 2://删除经销商运输方式
                        actionresult.SubmitResult = _IDistributorServices.DeleteDistributorTransportAuthority(dto);
                        break;
                    case 3://删除经销商产品线
                        actionresult.SubmitResult = _IDistributorServices.DeleteDistributorProductLineAuthority(dto);
                        break;
                    case 4://删除经销商授权产品线区域
                        actionresult.SubmitResult = _IDistributorServices.DeleteDistributorProductLineRegionAuthority(dto);
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
