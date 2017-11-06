using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.UserApply.DTO.Common;
using TCSOFT.DMS.UserApply.DTO.User.UserApply;
using TCSOFT.DMS.UserApply.IServices;
using TCSOFT.DMS.UserApply.Services;

namespace TCSOFT.DMS.UserApplyAPI.Controllers
{
    public class ApplyUserAuditController : ApiController
    {
        IUserApplyServices _IUserServices = null;
        public ApplyUserAuditController()
        {
            _IUserServices = new UserApplyServices();
        }

        ///// <summary>
        ///// 得到所有用户申请信息
        ///// </summary>
        ///// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetUserApply(string UserApplySearchDTO)
        {
            UserApplySearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<UserApplySearchDTO>(UserApplySearchDTO);
            ResultDTO<List<UserApplyUserResultDTO>> resultdto = new ResultDTO<List<UserApplyUserResultDTO>>();
            List<UserApplyUserResultDTO> user = null;

            user = _IUserServices.GetUserApply(dto);

            resultdto.Object = user;
            resultdto.SubmitResult = true;

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(resultdto),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ApplyUserAudit(UserApplyOperateDTO dto)
        {
            ResultDTO<UserApplyOperateDTO> resultdto = new ResultDTO<UserApplyOperateDTO>();
            try
            {
                if (dto.AuditStatus  == 1) //通过
                {
                    resultdto.SubmitResult = _IUserServices.AuditUserApplyEgis(dto);
                    resultdto.Object = dto;
                }
                else if (dto.AuditStatus == 2)//拒绝
                {
                    resultdto.SubmitResult = _IUserServices.AuditUserApplyRefuse(dto);
                    resultdto.Object = dto;
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


        ///// <summary>
        ///// 得到所有用户申请信息
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public HttpResponseMessage GetUserApply(string UserApplySearchDTO)
        //{
        //    UserApplySearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<UserApplySearchDTO>(UserApplySearchDTO);
        //    ResultDTO<List<UserApplyUserResultDTO>> resultdto = new ResultDTO<List<UserApplyUserResultDTO>>();
        //    List<UserApplyUserResultDTO> user = null;

        //    user = _IUserServices.GetUserApply(dto);

        //    resultdto.Object = user;
        //    resultdto.SubmitResult = true;

        //    HttpResponseMessage result = new HttpResponseMessage
        //    {
        //        Content = new StringContent(JsonConvert.SerializeObject(resultdto),
        //            System.Text.Encoding.GetEncoding("UTF-8"),
        //            "application/json")
        //    };

        //    return result;
        //}
        ///// <summary>
        ///// 审核
        ///// </summary>
        ///// <param name="dto"></param>
        ///// <returns></returns>
        //[HttpPut]
        //public HttpResponseMessage ApplyUserAudit(UserApplyOperateDTO dto)
        //{
        //    ResultDTO<UserApplyOperateDTO> resultdto = new ResultDTO<UserApplyOperateDTO>();
        //    try
        //    {
        //        if (dto.Audit == 1) //通过
        //        {
        //            resultdto.SubmitResult = _IUserServices.AuditUserApplyAdopt(dto);
        //            resultdto.Object = dto;
        //        }
        //        else if (dto.Audit == 2)//拒绝
        //        {
        //            resultdto.SubmitResult = _IUserServices.AuditUserApplyRefuse(dto);
        //            resultdto.Object = dto;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultdto.SubmitResult = false;
        //        resultdto.Message = ex.Message;
        //    }

        //    HttpResponseMessage result = new HttpResponseMessage
        //    {
        //        Content = new StringContent(JsonConvert.SerializeObject(resultdto),
        //            System.Text.Encoding.GetEncoding("UTF-8"),
        //            "application/json")
        //    };

        //    return result;
        //}
    }
}
