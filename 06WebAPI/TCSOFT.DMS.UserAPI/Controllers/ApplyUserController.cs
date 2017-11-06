using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCSOFT.DMS.Common;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.UserApply.DTO.User.UserApply;
using TCSOFT.DMS.UserApply.IServices;
using TCSOFT.DMS.UserApply.Services;

namespace TCSOFT.DMS.UserApplyAPI.Controllers
{
    public class ApplyUserController : ApiController
    {
        IUserApplyServices _IUserServices = null;
        public ApplyUserController()
        {
            _IUserServices = new UserApplyServices();
        }

        /// <summary>
        /// 查询申请的批次
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetApplyBatchUser(string UserApplySearchDTO)
        {
            UserApplySearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<UserApplySearchDTO>(UserApplySearchDTO);
            ResultDTO<List<UserApplyBatchResultDTO>> resultdto = new ResultDTO<List<UserApplyBatchResultDTO>>();

            try
            {
                if (dto.Query == 1)
                {
                    resultdto.Object = _IUserServices.GetApplyBatchUser(dto);
                    resultdto.SubmitResult = true;
                    resultdto.Count = dto.Count;
                }
                else if (dto.Query == 2)
                {
                    resultdto.Object = new List<UserApplyBatchResultDTO>() {
                        new UserApplyBatchResultDTO(){
                            UserApplyUserList=_IUserServices.GetApplyUser(dto)
                        }
                    };
                    resultdto.SubmitResult = true;
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
        /// 保存用户/保存批次用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddApplyUser(BatchApplyOperateDTO dto)
        {
            ResultDTO<object> resultdto = new ResultDTO<object>();
            try
            {
                resultdto.SubmitResult = _IUserServices.AddApplyUser(dto);
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
    }
}
