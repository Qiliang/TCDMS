using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCSOFT.DMS.MasterData.DTO;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterData.DTO.Message;
using TCSOFT.DMS.MasterData.DTO.System.ModularSysEmail;
using TCSOFT.DMS.MasterData.DTO.System.OperationSysEmail;
using TCSOFT.DMS.MasterData.DTO.User;
using TCSOFT.DMS.MasterData.DTO.UsersStat;
using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model;
using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider;
using TCSOFT.DMS.WebMain.Filter;
using TCSOFT.DMS.WebMain.Models.Model;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Controllers
{
    public class SystemController : BaseController
    {
        [AuthorityFilter(AuthorityID = "095007001")]
        public ActionResult ModularSysEmail()
        {
            ViewBag.CrruentAuthority = GetAuthority("095007001");
            return View();
        }
        [AuthorityFilter(AuthorityID = "095007002")]
        public ActionResult CustomerSysEmail()
        {
            ViewBag.CrruentAuthority = GetAuthority("095007002");
            return View();
        }
        [AuthorityFilter(AuthorityID = "095007003")]
        public ActionResult OperationSysEmail()
        {
            ViewBag.CrruentAuthority = GetAuthority("095007003");
            return View();
        }
        [AuthorityFilter(AuthorityID = "095007004")]
        public ActionResult MessageStatistics()
        {
            ViewBag.CrruentAuthority = GetAuthority("095007004");
            return View();
        }
        [AuthorityFilter(AuthorityID = "095007005")]
        public ActionResult UsersStatistics()
        {
            ViewBag.CrruentAuthority = GetAuthority("095007005");

            return View();
        }
        [AuthorityFilter(AuthorityID = "095007006")]
        public ActionResult FeedbackManagement()
        {
            ViewBag.CrruentAuthority = GetAuthority("095007006");

            return View();
        }
        [AuthorityFilter(AuthorityID = "095007007")]
        public ActionResult LogManagement()
        {
            ViewBag.CrruentAuthority = GetAuthority("095007007");

            return View();
        }
        #region 客户管理员配置
        /// <summary>
        /// 得到所有客户模块管理员人员
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCustomerAdminList()
        {
            UserSearchDTO dto = new UserSearchDTO();
            dto.RoleIDlist = new List<int?>() { 98 };

            dto.page = 1;
            dto.rows = 10000000;
            ResultData<List<UserResultDTO>> result = null;

            result = UserAuthorityProvider.GetUser(dto);

            return Json(result.Object, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 保存客户模块管理员人员
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCustomerAdmin(UserOperate dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            try
            {
                dto.ModifyUser = user.FullName;
                dto.ModifyTime = DateTime.Now;
                dto.Uptype = 3;
                result = SystemProvider.AddCustomerAdmin(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除客户模块管理员人员
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteCustomerAdmin(UserOperate dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            try
            {
                dto.ModifyUser = user.FullName;
                dto.ModifyTime = DateTime.Now;
                dto.Uptype = 4;
                result = SystemProvider.AddCustomerAdmin(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 模块管理员配置
        /// <summary>
        /// 查询所有模块信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetModularList(UserSearchDTO dto)
        {
            List<CustomerSysEamilModel> result = null;
            dto.RoleIDlist = new List<int?> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

            result = SystemProvider.GetModularList(dto).Object;

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 模块管理员配置修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateModularInfo(UserOperate dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.Uptype = 5;
            try
            {
                result = SystemProvider.UpdateModularInfo(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 运维管理员配置
        /// <summary>
        /// 得到所有运维模块管理员人员
        /// </summary>
        /// <returns></returns>
        public ActionResult GetOperationList()
        {
            UserSearchDTO dto = new UserSearchDTO();
            dto.RoleIDlist = new List<int?>() { 99 };

            dto.page = 1;
            dto.rows = 10000000;
            ResultData<List<UserResultDTO>> result = null;

            result = UserAuthorityProvider.GetUser(dto);

            return Json(result.Object, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条运维信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetOneOperationInfo(int id)
        {
            ResultData<UserResultDTO> result = new ResultData<UserResultDTO>();

            try
            {
                result = UserAuthorityProvider.GetOneUser(id);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 运维管理员配置修改保存
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateOperationInfo(OperationOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            try
            {
                result = SystemProvider.UpdateOperationInfo(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 短信统计
        /// <summary>
        /// 得到短信统计
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMessageStatList(MessageSearchDTO dto)
        {
            ResultData<List<MessageStatModel>> result = new ResultData<List<MessageStatModel>>();

            result = SystemProvider.GetMessageStatList(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除短信统计
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteMessageStat(MessageResultDTO dto)
        {
            ResultData<object> result = new ResultData<object>();

            try
            {
                result = SystemProvider.DeleteMessageStat(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 导出短信统计
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportMessageStat(MessageSearchDTO dto)
        {
            string result = null;
            dto.page = 1;
            dto.rows = 10000000;
            List<MessageStatModel> pp = null;
            pp = SystemProvider.GetMessageStatList(dto).Object;

            string strTemplateFile = Server.MapPath(@"~/TempLate/MessageStatTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            pp.ForEach(g =>
            {
                Models.Model.Excel.ExcelMessageStat er = new Models.Model.Excel.ExcelMessageStat();
                er.部门 = g.DepartName;
                er.用户名称 = g.FullName;
                er.用户类型 = g.UserTypeName;
                er.手机号 = g.PhoneNumber;
                er.经销商 = g.UserDistributorstr;
                er.短信分类 = g.MessageTypeStr;
                er.发送日期 = g.SendTime.HasValue ? g.SendTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
                ratelist.Add(er);
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        public FileContentResult DownloadMessageStat(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("短信统计" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
        #endregion

        #region 用户统计
        /// <summary>
        /// 得到用户统计
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUsersStatList(UsersStatSearchDTO dto)
        {
            ResultData<List<UsersStatModel>> result = new ResultData<List<UsersStatModel>>();

            result = SystemProvider.GetUsersStatList(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除用户统计信息
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteUsersStat(UsersStatResultDTO dto)
        {
            ResultData<object> result = new ResultData<object>();

            try
            {
                result = SystemProvider.DeleteUsersStat(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 导出用户统计
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportUsersStat(UsersStatSearchDTO dto)
        {
            string result = null;
            dto.page = 1;
            dto.rows = 10000000;
            List<UsersStatModel> pp = null;
            pp = SystemProvider.GetUsersStatList(dto).Object;

            string strTemplateFile = Server.MapPath(@"~/TempLate/UsersStatTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            pp.ForEach(g =>
            {
                Models.Model.Excel.ExcelUsersStat er = new Models.Model.Excel.ExcelUsersStat();
                er.部门 = g.DepartName;
                er.用户名称 = g.FullName;
                er.用户类型 = g.UserTypeName;
                er.手机号 = g.PhoneNumber;
                er.经销商 = g.UserDistributorstr;
                er.使用模块 = g.UseModel;
                er.使用时间=g.UseModelTime.HasValue?g.UseModelTime.Value.ToString("yyyy-MM-dd HH:mm:ss"):null;
                ratelist.Add(er);
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        public FileContentResult DownloadUsersStat(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("用户统计" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
        #endregion

        #region 反馈信息
        /// <summary>
        /// 得到反馈信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetFeedbackList(FeedbackSearchDTO dto)
        {
            ResultData<List<FeedbackModel>> result = new ResultData<List<FeedbackModel>>();

            result = SystemProvider.GetFeedbackList(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改反馈信息
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateFeedback(FeedbackOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.DealDatetime = DateTime.Now;
            dto.DealUser = user.FullName;
            dto.FeedbackStaus = 1;
            try
            {
                result = SystemProvider.UpdateFeedback(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 下载附件
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DownloadFeedbackAttachment(AttachFileResultDTO dto)
        {
            string strSaveDir = this.Server.MapPath("~/Attachments/Feedback");
            string File = string.Empty;
            byte[] FileByte = null;
            
            File = System.IO.Directory.GetFiles(strSaveDir, dto.AttachFileName, System.IO.SearchOption.TopDirectoryOnly).FirstOrDefault();
            using (FileStream fsRead = new FileStream(File, FileMode.Open))
            {
                int fsLen = (int)fsRead.Length;
                byte[] heByte = new byte[fsLen];
                int r = fsRead.Read(heByte, 0, heByte.Length);
                FileByte = heByte;

                fsRead.Flush();
            }
            FileResult FCR = new FileContentResult(FileByte, dto.AttachFileExtentionName);
            FCR.FileDownloadName = dto.AttachFileSrcName + dto.AttachFileExtentionName;

            return FCR;
        }
        /// <summary>
        /// 反馈附件是否存在
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExistFeedbackAttachment(AttachFileResultDTO dto)
        {
            bool result = false;
            string strSaveDir = this.Server.MapPath("~/Attachments/Feedback");
            string Path=strSaveDir+"\\"+dto.AttachFileName;
            result=System.IO.File.Exists(Path);

            return Json(result);
        }
        /// <summary>
        /// 导出反馈
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportFeedback(FeedbackSearchDTO dto)
        {
            dto.page = 1;
            dto.rows = 10000000;
            List<FeedbackModel> resultFeedback = null;
            string result = null;
            resultFeedback = SystemProvider.GetFeedbackList(dto).Object;

            string strTemplateFile = Server.MapPath(@"~/TempLate/FeedbackTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();

            resultFeedback.ForEach(g =>
            {
                Models.Model.Excel.ExcelFeedback er = new Models.Model.Excel.ExcelFeedback();
                er.状态 = g.FeedbackStausStr;
                if (g.AttachFile != null)
                {
                    er.附件 = g.AttachFile.AttachFileSrcName+g.AttachFileExtentionName;
                }
                er.反馈日期 = g.FeedbackDate.ToString();
                er.反馈人 = g.FullName;
                er.反馈系统 = g.FeedbackSystem;
                er.反馈模块 = g.FeedbackModel;
                er.反馈内容 = g.FeedbackContent;
                er.经销商 = g.UserDistributorstr;
                er.部门 = g.DepartName;
                er.反馈人手机 = g.PhoneNumber;
                er.反馈人邮箱 = g.Email;
                ratelist.Add(er);
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        public FileContentResult DownloadFeedback(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("反馈信息" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
        #endregion

        #region 日志管理
        /// <summary>
        /// 得到日志信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetLog(LogSearchDTO dto)
        {
            ResultData<List<LogDTO>> result = new ResultData<List<LogDTO>>();

            result = SystemProvider.GetLog(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}