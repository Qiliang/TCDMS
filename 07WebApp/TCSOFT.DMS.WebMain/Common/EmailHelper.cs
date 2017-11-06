using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace TCSOFT.DMS.WebMain.Common
{
    using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider;
    using WebMain.Areas.MasterData.Models.Model;
    public class EmailHelper
    {
        #region 发送邮件
        private static SmtpClient _Smtp = null;
        public static void InnitEmailServer(string strHost, int intPort, string strUserName, string strPassword)
        {
            _Smtp = new SmtpClient();
            _Smtp.Host = strHost;
            _Smtp.Port = intPort;
            _Smtp.Timeout = 12000;
            _Smtp.Credentials = new NetworkCredential(strUserName, strPassword);
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="strSubject">主题</param>
        /// <param name="strBody">正文（内容）</param>
        /// <param name="listTo">收件人List</param>
        /// <param name="listCC">抄送人List</param>
        /// <param name="listBcc">密件抄送人List</param>
        /// <param name="strFrom">发件人</param>
        /// <returns></returns>
        public static bool SendMessage(string strSubject, string strBody, List<string> listTo, List<string> listCC, List<string> listBcc, string strFrom="")
        {
            bool blResult = false;

            using (MailMessage emailmsg = new MailMessage())
            {
                strFrom =WebConfiger.EmailAccount;
                //发件人
                emailmsg.From = new MailAddress(strFrom);
                //收件人
                if (listTo != null)
                {
                    listTo = listTo.Distinct().ToList();
                    foreach (string strto in listTo)
                    {
                        emailmsg.To.Add(strto);
                    }
                }
                //抄送人
                if (listCC != null)
                {
                    listCC = listCC.Distinct().ToList();
                    foreach (string strcc in listCC)
                    {
                        emailmsg.CC.Add(strcc);
                    }
                }
                //密件抄送人
                if (listBcc != null)
                {
                    listBcc = listBcc.Distinct().ToList();
                    foreach (string strbcc in listBcc)
                    {
                        emailmsg.Bcc.Add(strbcc);
                    }
                }
                //主题
                emailmsg.SubjectEncoding = UTF8Encoding.UTF8;
                emailmsg.Subject = strSubject;
                //正文（内容）
                emailmsg.BodyEncoding = UTF8Encoding.UTF8;
                emailmsg.Body = strBody;
                //是否HTML
                emailmsg.IsBodyHtml = true;
                try
                {
                    _Smtp.Send(emailmsg);
                    blResult = true;
                }
                catch (Exception ex)
                {
                    Common.Logger.WriteLog("发送邮件错误：" + ex.Message);
                }
            }

            return blResult;
        }
        #endregion
        //#region 新用户申请及审核
        ///// <summary>
        ///// 用户申请
        ///// </summary>
        ///// <param name="strCurrentUserEmail">当前用户Email</param>
        ///// <param name="model">用户</param>
        ///// <returns></returns>
        //public static bool SendUserApply(UserApplyModel model)
        //{
        //    bool blResult = false;

        //    string strSubject = "新用户申请";
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("系统管理员 你好： <br/>");
        //    sb.Append("新申请用户{0}，请审核。 <br/>");
        //    sb.Append("姓名：{0} <br/>");
        //    sb.Append("手机号：{1} <br/>");
        //    sb.Append("邮箱：{2} <br/>");
        //    sb.Append("用户类型：{3} <br/>");
        //    sb.Append("经销商：{4} <br/>");
        //    sb.Append("申请模块： <br/>");//
        //    sb.Append("<b>携手网用户管理系统</b>");
        //    string strBody = String.Format(sb.ToString(), model.UserApplyName, model.UserApplyTelNumber, model.UserApplyEmail, model.UserApplyTypeName, model.DistributorNameList);

        //    //取得系统管理员邮箱
        //    List<string> strSysEmail = UserAuthorityProvider.GetUserSysEmail();
        //    //发送给系统管理员
        //    blResult = SendMessage(strSubject, strBody, strSysEmail, null, null);

        //    return blResult;
        //}
        ///// <summary>
        ///// 新用户申请审核（通过）
        ///// </summary>
        ///// <returns></returns>
        //public static bool SendUserAuditAdopt(UserApplyModel model)
        //{
        //    bool blResult = false;

        //    string strSubject = "新用户申请通过";
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("你好： <br/>");
        //    sb.Append("你所提交的用户申请已通过，特此通知。 <br/>");
        //    sb.Append("姓名：{0} <br/>");
        //    sb.Append("手机号：{1} <br/>");
        //    sb.Append("邮箱：{2} <br/>");
        //    sb.Append("用户类型：{3} <br/>");
        //    sb.Append("经销商：{4} <br/>");
        //    sb.Append("申请模块： <br/>");//
        //    sb.Append("<b>携手网用户管理系统</b>");
        //    string strBody = String.Format(sb.ToString(), model.UserApplyName, model.UserApplyTelNumber, model.UserApplyEmail, model.UserApplyTypeName, model.DistributorNameList);

        //    //取得对应权限模块的模块管理员邮箱
        //    List<string> strModelSysEmail = UserAuthorityProvider.GetUserModelSysEmail(model);
        //    //发送给对应权限的模块管理员及新用户申请人
        //    blResult = SendMessage(strSubject, strBody, strModelSysEmail, new List<string> { model.UserApplyEmail }, null);

        //    return blResult;
        //}
        ///// <summary>
        ///// 新用户申请审核（拒绝）
        ///// </summary>
        ///// <returns></returns>
        //public static bool SendUserAuditRefuse(UserApplyModel model)
        //{
        //    bool blResult = false;

        //    string strSubject = "新用户申请被拒绝";
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("你好： <br/>");
        //    sb.Append("你所提交的用户申请被拒绝，请参考详细的备注： <br/>");
        //    sb.Append("备注：{5} <br/>");
        //    sb.Append("姓名：{0} <br/>");
        //    sb.Append("手机号：{1} <br/>");
        //    sb.Append("邮箱：{2} <br/>");
        //    sb.Append("用户类型：{3} <br/>");
        //    sb.Append("经销商：{4} <br/>");
        //    sb.Append("申请模块： <br/>");//
        //    sb.Append("<b>携手网用户管理系统</b>");
        //    string strBody = String.Format(sb.ToString(), model.UserApplyName, model.UserApplyTelNumber, model.UserApplyEmail, model.UserApplyTypeName, model.DistributorNameList, model.AuditFalseReason);

        //    //发送给新用户申请人
        //    blResult = SendMessage(strSubject, strBody, new List<string> { model.UserApplyEmail }, null, null);

        //    return blResult;
        //}
        //#endregion
        //#region 变更权限申请及审核
        ///// <summary>
        ///// 变更权限申请
        ///// </summary>
        ///// <returns></returns>
        //public static bool SendUserChangeApply(UserApplyModel model)
        //{
        //    bool blResult = false;

        //    string strSubject = "变更权限申请";
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("模块管理员 你好： <br/>");
        //    sb.Append("{0}用户变更权限，请审核。 <br/>");
        //    sb.Append("姓名：{0} <br/>");
        //    sb.Append("手机号：{1} <br/>");
        //    sb.Append("邮箱：{2} <br/>");
        //    sb.Append("用户类型：{3} <br/>");
        //    sb.Append("经销商：{4} <br/>");
        //    sb.Append("变更后的模块： <br/>");//
        //    sb.Append("<b>携手网用户管理系统</b>");
        //    string strBody = String.Format(sb.ToString(), model.UserApplyName, model.UserApplyTelNumber, model.UserApplyEmail, model.UserApplyTypeName, model.DistributorNameList);

        //    //取得权限变更了的模块管理员邮箱
        //    List<string> strModelSysEmail = UserAuthorityProvider.GetUserChangeModelSysEmail(model);
        //    //发送给权限变更了的模块管理员
        //    blResult = SendMessage(strSubject, strBody, strModelSysEmail, null, null);

        //    return blResult;
        //}
        ///// <summary>
        ///// 变更权限申请审核（通过）
        ///// </summary>
        ///// <returns></returns>
        //public static bool SendUserChangeAuditAdopt(UserApplyModel model)
        //{
        //    bool blResult = false;

        //    string strSubject = "变更权限申请通过";
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("用户{0} 你好： <br/>");
        //    sb.Append("你所提交的变更权限通过，特此通知。 <br/>");
        //    sb.Append("姓名：{0} <br/>");
        //    sb.Append("手机号：{1} <br/>");
        //    sb.Append("邮箱：{2} <br/>");
        //    sb.Append("用户类型：{3} <br/>");
        //    sb.Append("经销商：{4} <br/>");
        //    sb.Append("变更后的模块： <br/>");//
        //    sb.Append("<b>携手网用户管理系统</b>");
        //    string strBody = String.Format(sb.ToString(), model.UserApplyName, model.UserApplyTelNumber, model.UserApplyEmail, model.UserApplyTypeName, model.DistributorNameList);

        //    //取得系统管理员邮箱
        //    List<string> strSysEmail = UserAuthorityProvider.GetUserSysEmail();
        //    //发送给系统管理员及变更权限申请人
        //    blResult = SendMessage(strSubject, strBody, strSysEmail, new List<string> { model.UserApplyEmail }, null);

        //    return blResult;
        //}
        ///// <summary>
        ///// 变更权限申请审核（拒绝）
        ///// </summary>
        ///// <returns></returns>
        //public static bool SendUserChangeAuditRefuse(UserApplyModel model)
        //{
        //    bool blResult = false;

        //    string strSubject = "变更权限申请拒绝";
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("用户{0} 你好： <br/>");
        //    sb.Append("你所提交的变更权限申请被拒绝，请参考详细的备注： <br/>");
        //    sb.Append("备注：{5} <br/>");
        //    sb.Append("姓名：{0} <br/>");
        //    sb.Append("手机号：{1} <br/>");
        //    sb.Append("邮箱：{2} <br/>");
        //    sb.Append("用户类型：{3} <br/>");
        //    sb.Append("经销商：{4} <br/>");
        //    sb.Append("变更后的模块： <br/>");//
        //    sb.Append("<b>携手网用户管理系统</b>");
        //    string strBody = String.Format(sb.ToString(), model.UserApplyName, model.UserApplyTelNumber, model.UserApplyEmail, model.UserApplyTypeName, model.DistributorNameList, model.AuditFalseReason);

        //    //发送给变更权限申请人
        //    blResult = SendMessage(strSubject, strBody, new List<string> { model.UserApplyEmail }, null, null);

        //    return blResult;
        //}
        //#endregion
    }
}