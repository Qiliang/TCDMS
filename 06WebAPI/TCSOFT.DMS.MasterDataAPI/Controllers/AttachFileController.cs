using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using Newtonsoft.Json;
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using TCSOFT.DMS.MasterData.IServices;
    using TCSOFT.DMS.MasterData.Services;
    public class AttachFileController : ApiController
    {
        /// <summary>
        /// 附件信息
        /// </summary>
        ICommonServices _ICommonServices = null;
        /// <summary>
        /// 附件信息
        /// </summary>
        public AttachFileController()
        {
            _ICommonServices = new CommonServices();
        }
        #region
        /// <summary>
        /// 得到附件信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAttachFileList(string AttachFileSearchDTO)
        {
            List<AttachFileResultDTO> actionresult = new List<AttachFileResultDTO>();
            AttachFileSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<AttachFileSearchDTO>(AttachFileSearchDTO);
            actionresult = _ICommonServices.GetAttachFileList(dto);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 新增附件
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddAttachFileList(List<AttachFileOperateDTO> dtolist)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _ICommonServices.AddAttachFileList(dtolist);
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
        /// 删除附件
        /// </summary>
        /// <param name="AttachFileOperateDTO"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteAttachFile(string AttachFileOperateDTO)
        {
            AttachFileOperateDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<AttachFileOperateDTO>(AttachFileOperateDTO);
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _ICommonServices.DeleteAttachFile(dto);
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
        #endregion
    }
}
