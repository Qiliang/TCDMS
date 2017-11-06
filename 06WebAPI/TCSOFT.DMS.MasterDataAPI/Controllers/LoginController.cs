using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace TCSOFT.DMS.MasterDataAPI.Controllers
{
    using MasterData.DTO;
    using MasterData.IServices;
    using MasterData.Services;
    using Common;
    /// <summary>
    /// 登录服务
    /// </summary>
    public class LoginController : ApiController
    {
        /// <summary>
        /// 定义登录接口
        /// </summary>
        ILoginServices _ILoginServices = null;
        /// <summary>
        /// 构造并实现登录接口
        /// </summary>
        public LoginController()
        {
            _ILoginServices = new LoginServices();
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="logins"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Login(string logins)
        {
            LoginDTO logindto = TransformHelper.ConvertBase64JsonStringToDTO<LoginDTO>(logins);
            UserLoginDTO ulogin = _ILoginServices.Login(logindto);

            HttpResponseMessage result = new HttpResponseMessage { 
                Content = new StringContent(JsonConvert.SerializeObject(ulogin), 
                    System.Text.Encoding.GetEncoding("UTF-8"), 
                    "application/json") };

            return result;
        }

        /// <summary>
        /// 检测手机号是否存在
        /// </summary>
        /// <param name="PhoneNumber">手机号</param>
        /// <param name="validecode">权限码(后续扩展用)</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage CheckPhoneNumber(string PhoneNumber, string validecode)
        {
            short shtResult = _ILoginServices.CheckPhoneNumber(PhoneNumber);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(shtResult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
        /// <summary>
        /// 保存密码
        /// </summary>
        /// <param name="mldto">手机密码相关信息</param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage SaveDymicPassword(MoblieLoginDTO mldto)
        {
            bool blResult = _ILoginServices.SaveDymicPassword(mldto.PhoneNumber, mldto.DymicPassword, mldto.ValidDate);
            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(blResult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }

        /// <summary>
        /// 保存登录信息
        /// </summary>
        /// <param name="PhoneNumber">手机号</param>
        /// <param name="SendContent">登录信息</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SaveMessageLog(string PhoneNumber, string SendContent)
        {
            bool blResult = _ILoginServices.SaveMessageLog(PhoneNumber, SendContent);
            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(blResult),
                    System.Text.Encoding.GetEncoding("UTF-8"),
                    "application/json")
            };

            return result;
        }
    }
}