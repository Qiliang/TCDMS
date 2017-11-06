using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using MasterData.DTO.Area;
    using DMS.Common;
    using MasterData.IServices;
    using MasterData.Services;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using System.Data.Entity.Infrastructure;
    
    public class AreaController : ApiController
    {
        IRegionServices _IRegionServices = null;
        public AreaController()
        {
            _IRegionServices = new RegionServices();
        }
        #region 大小区
        /// <summary>
        /// 大小区显示/小区省份显示
        /// </summary>
        /// <param name="AreaSearchDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAreaTree(string AreaSearchDTO)
        {
            AreaSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<AreaSearchDTO>(AreaSearchDTO);
            List<AreaResultDTO> arealist = null;

            arealist = _IRegionServices.GetAreaTree(dto);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(arealist),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 大小区新增/小区省份新增
        /// </summary>
        /// <param name="AreaOperateDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddArea(AreaOperateDTO AreaOperateDTO)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                if (AreaOperateDTO.RegionIDList == null)
                {
                    actionresult.SubmitResult= _IRegionServices.AddArea(AreaOperateDTO);
                }
                else
                {
                    actionresult.SubmitResult = _IRegionServices.AddAreaRegion(AreaOperateDTO);
                }
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
        /// 大小区修改/小区省份修改
        /// </summary>
        /// <param name="AreaOperateDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateArea(AreaOperateDTO AreaOperateDTO)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                if (AreaOperateDTO.AreaRegionID == null)
                {
                    actionresult.SubmitResult = _IRegionServices.UpdateArea(AreaOperateDTO);
                }
                else
                {
                    actionresult.SubmitResult = _IRegionServices.UpdateAreaRegion(AreaOperateDTO);
                }
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
        /// 大小区删除/小区省份删除
        /// </summary>
        /// <param name="AreaOperateDTO"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteArea(string AreaOperateDTO)
        {
            AreaOperateDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<AreaOperateDTO>(AreaOperateDTO);
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                if (dto.AreaRegionID == null)
                {
                    actionresult.SubmitResult = _IRegionServices.DeleteArea(dto);
                }
                else
                {
                    actionresult.SubmitResult = _IRegionServices.DeleteAreaRegion(dto);
                }
            }
            catch (DbUpdateException) 
            {
                actionresult.SubmitResult = false;
                actionresult.Message = "此条信息已使用不可删除！";
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
        /// 大区
        /// </summary>
        /// <param name="AreaSearchDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetArea()
        {
            List<AreaResultDTO> arealist = null;

            arealist = _IRegionServices.GetArea();

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(arealist),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        #endregion
    }
}
