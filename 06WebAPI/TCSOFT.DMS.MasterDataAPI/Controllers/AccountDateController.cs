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
    using MasterData.DTO.AccountDate;
    using Newtonsoft.Json;
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    /// <summary>
    /// 关账日信息
    /// </summary>
    public class AccountDateController : ApiController
    {
        IBaseInfoServices _IBaseInfoServices = null;
        /// <summary>
        /// 关账日信息信息
        /// </summary>
        public AccountDateController()
        {
            _IBaseInfoServices = new BaseInfoServices();
        }
        #region 关账日信息
        /// <summary>
        /// 得到所有关账日信息信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAccountDateList()
        {
            List<AccountDateResultDTO> actionresult = new List<AccountDateResultDTO>();
            actionresult = _IBaseInfoServices.GetAccountDateList();

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 得到一条关账日信息信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetOneAccountDate(int id)
        {
            AccountDateResultDTO actionresult = null;
            actionresult = _IBaseInfoServices.GetAccountDate(id);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(actionresult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 新增关账日信息信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddAccountDate(AccountDateOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _IBaseInfoServices.AddAccountDate(dto);
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
        /// 修改关账日信息信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateAccountDate(AccountDateOperateDTO dto)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                actionresult.SubmitResult = _IBaseInfoServices.UpdateAccountDate(dto);
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
        /// 删除关账日信息信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteAccountDate(string AccountDateSearchDTO)
        {
            ResultDTO<object> actionresult = new ResultDTO<object>();

            try
            {
                AccountDateSearchDTO dto = TransformHelper.ConvertBase64JsonStringToDTO<AccountDateSearchDTO>(AccountDateSearchDTO);
                actionresult.SubmitResult = _IBaseInfoServices.DeleteAccountDate(dto);
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
