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
    using MasterData.DTO.Distributor.Distributor;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using System.Data.Entity.Infrastructure;
    /// <summary>
    /// 经销商管理
    /// </summary>
    public class DistributorManagermentController : ApiController
    {
        IDistributorServices _IDistributorServices = null;
        /// <summary>
        /// 经销商管理
        /// </summary>
        public DistributorManagermentController() 
        {
            _IDistributorServices = new DistributorServices();
        }
        #region 经销商管理
        /// <summary>
        /// 得到经销商信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetDistributorList(string DistributorSearchDTO)
        {
            DistributorSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<DistributorSearchDTO>(DistributorSearchDTO);
            ResultDTO<List<DistributorResultDTO>> actionresult = new ResultDTO<List<DistributorResultDTO>>();
            actionresult.Object = _IDistributorServices.GetDistributorList(dto);
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
        /// 新增经销商信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddDistributor(DistributorOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                actionresult.SubmitResult =  _IDistributorServices.AddDistributor(dto);
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
        /// 修改经销商
        /// </summary>
        /// <param name="dto">UpType修改类型（1.修改 2.停启用）</param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateDistributor(DistributorOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                if (dto.UpType == 1)//正常修改
                {
                    actionresult.SubmitResult = _IDistributorServices.UpdateDistributor(dto);
                }
                else if (dto.UpType == 2)//停启用
                {
                    actionresult.SubmitResult = _IDistributorServices.StartOrStopDistributor(dto);
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
        public HttpResponseMessage DeleteDistributor(string DistributorOperateDTO)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();
            try
            {
                DistributorOperateDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<DistributorOperateDTO>(DistributorOperateDTO);
                actionresult.SubmitResult = _IDistributorServices.DeleteDistributor(dto);
            }
            catch (DbUpdateException)
            {
                actionresult.SubmitResult = false;
                actionresult.Message = "此条信息已被使用，不可删除！";
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
