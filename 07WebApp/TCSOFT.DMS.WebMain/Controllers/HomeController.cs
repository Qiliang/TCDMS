using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TCSOFT.DMS.WebMain.Controllers
{
    using Common;
    using Models.Model;
    using Models.Provider;
    using MasterData.DTO;
    using Filter;
    using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model;
    using System.IO;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider;
    using TCSOFT.DMS.MasterData.DTO.Message;
    using TCSOFT.DMS.MasterData.DTO.User;
    using TCSOFT.DMS.UserApply.DTO.User.UserApply;
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [AuthorityFilter]
        public ActionResult Main()
        {
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            ViewBag.UserType = user.UserType;
            ViewBag.FullName = user.FullName;
            ViewBag.PhoneNumber = user.PhoneNumber;
            ViewBag.Email = user.Email;
            ViewBag.Distributorstr = user.Distributorstr;
            AboutWebSiteModel verlist = new AboutWebSiteModel();
            verlist.CurrentAboutVerInfo = Common.AboutWebSiteHelper.AboutWebSiteList;
            ViewBag.Version = verlist;
            var pp = GlobalStaticData.StructureInfo.Where(p => p.ParentStructureID == null && p.IsVisible == true && p.StructureID.Length == 3 && user.CurrentAuthorityList.Exists(g => g.StructureID == p.StructureID)).ToList();

            return View(pp);
        }

        public ActionResult Login(LoginModel lngmodel)
        {
            ResultData<UserLoginDTO> result = new ResultData<UserLoginDTO>();
            //if (lngmodel.ValidateCode != (string)Session["ValidateCode"])
            //{
            //    result.SubmitResult = false;
            //    result.Message = "图形码输入错误！";
            //}
            //else
            //{
                var vresult = HomeProvider.Login(lngmodel);
                if (vresult != null)
                {
                    result.SubmitResult = true;
                    result.Object = vresult;
                    Session["UserLoginInfo"] = vresult;
                }
                else
                {
                    result.SubmitResult = false;
                    result.Message = "手机验证码错误！";
                }
            //}

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="types">0:贝克曼 1：经销商</param>
        /// <returns></returns>
        public ActionResult GetAuthorityInfo(string types)
        {
            List<AuthorityListModel> result = new List<AuthorityListModel>();

            List<StructureDTO> strcdto = GlobalStaticData.StructureInfo.Where(p => p.StructureID.StartsWith(types) && p.StructureID.Length < 7).ToList();
            List<StructureDTO> strcdtolevelone = strcdto.Where(p => p.ParentStructureID == null).ToList();
            foreach (var p in strcdtolevelone)
            {
                foreach (var t in strcdto.Where(g => g.ParentStructureID == p.StructureID))
                {
                    AuthorityListModel alm = new AuthorityListModel();
                    result.Add(alm);
                    alm.LevelOne = p;
                    alm.LevelTWO = t;
                    alm.IsChecked = false;
                }
            }

            return Json(new { rows = result }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 取得当前用户权限
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserAuthorityInfo()
        {
            List<AuthorityListModel> result = new List<AuthorityListModel>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            List<StructureDTO> strcdto = null;
            switch (user.UserType)
            {
                case 0:
                    strcdto = GlobalStaticData.StructureInfo.Where(p => p.StructureID.Length < 7).ToList();
                    break;
                case 1:
                    strcdto = strcdto = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("0") || p.StructureID.StartsWith("9")) && p.StructureID.Length < 7).ToList();
                    break;
                case 2:
                    strcdto = strcdto = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("1") || p.StructureID.StartsWith("9")) && p.StructureID.Length < 7).ToList();
                    break;
            }
            List<StructureDTO> strcdtolevelone = strcdto.Where(p => p.ParentStructureID == null).ToList();
            foreach (var p in strcdtolevelone)
            {
                foreach (var t in strcdto.Where(g => g.ParentStructureID == p.StructureID))
                {
                    AuthorityListModel alm = new AuthorityListModel();
                    result.Add(alm);
                    alm.LevelOne = p;
                    alm.LevelTWO = t;
                    if (user.CurrentAuthorityList.Where(x => x.StructureID == t.StructureID).FirstOrDefault() != null)
                    {
                        alm.IsChecked = true;
                    }
                    else
                    {
                        alm.IsChecked = false;
                    }
                }
            }

            return Json(new { rows = result }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetValidateCode()
        {
            RandomCode randomCode = new RandomCode();
            string code = randomCode.CreateValidateCode(6);
            Session["ValidateCode"] = code;
            byte[] bytes = randomCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
        /// <summary>
        /// 获取手机短信
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="ValidateCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SendMobileMessage(string PhoneNumber, string ValidateCode)
        {
            ResultData<object> result = new ResultData<object>();
            if (Session["ValidateCode"] == null || Session["ValidateCode"].ToString() != ValidateCode)
            {
                result.SubmitResult = false;
                result.Message = "图形码不正确!";
                return Json(result);
            }
            //检测手机号是否存在
            short shtStatuscode = 0;
            if (!HomeProvider.CheckPhoneNumber(PhoneNumber, ref shtStatuscode))
            {
                result.SubmitResult = false;
                switch (shtStatuscode)
                {
                    case 1:
                        result.Message = "1";
                        break;
                    case 2:
                        result.Message = WebConfiger.NoAuthMessage;
                        break;
                    case 3:
                        result.Message = "该手机号已停用！";
                        break;
                    case 4:
                        result.Message = "该手机号已到期！";
                        break;
                }

                return Json(result);
            }

            // 检测是否有权限

            string strDymicPassword = new RandomCode().CreateValidateCode(6);
            string strMessage = WebConfiger.ShortMessage;
            strMessage = String.Format(strMessage, strDymicPassword);
            string strResult = MobileMessage.SendMessage(new List<string> { PhoneNumber }, strMessage);

            if (String.IsNullOrEmpty(strResult))
            {
                // 发完，成功发送进库保存304秒（融入4秒误差）
                result.SubmitResult = HomeProvider.SaveDymicPassword(new MoblieLoginDTO { PhoneNumber = PhoneNumber, DymicPassword = strDymicPassword, ValidDate = 304 });
                HomeProvider.SaveMessageLog(PhoneNumber);
            }
            else
            {
                result.SubmitResult = false;
                result.Message = strResult;
            }

            return Json(result);
        }

        public ActionResult Logout()
        {
            // 记录登录日志
            Session.Clear();
            return new RedirectToRouteResult(new RouteValueDictionary(new
            {
                controller = "Home",
                action = "Index"
            }));
        }

        /// <summary>
        /// 用户申请
        /// </summary>
        /// <param name="uam"></param>
        /// <returns></returns>
        public ActionResult Apply(UserApplyModel uam)
        {
            ResultData<object> result = new ResultData<object>();
            short shtStatuscode = -1;
            if (HomeProvider.CheckPhoneNumber(uam.UserApplyTelNumber, ref shtStatuscode))
            {
                result.SubmitResult = false;
                result.Message = "手机号已存在，不可重复申请！";

                return Json(result);
            }

            uam.ApplyAuth = uam.ApplyAuth.Where(p => p.IsChecked).ToList();
            uam.UserApplyTime = DateTime.Now;
            uam.AuditStatus = 0;
            if (UserApplyProvider.AuthApply(uam))
            {
                List<MasterData.DTO.Common.AdminDTO> lstadmin = UserApplyProvider.GetAdminInfo(new MasterData.DTO.Common.AdminSearchDTO { RoleIdList = new List<int> { 1 } });
                // 发送短信通知系统管理员
                string UserApplyShortMessage = String.Format(WebConfiger.UserApplyShortMessage, uam.UserApplyName, uam.DistributorNamestr);
                if (string.IsNullOrEmpty(uam.DistributorNamestr))
                {
                    UserApplyShortMessage = UserApplyShortMessage.Replace("经销商：", "");
                }
                MobileMessage.SendMessage(lstadmin.Select(g => g.PhoneNumber).ToList(), UserApplyShortMessage);
                //记录短信日志
                var useridlist = lstadmin.Select(g => g.UserID).ToList();
                if (useridlist.Count > 0)
                {
                    List<MessageOperateDTO> msgdtolist = new List<MessageOperateDTO>();
                    foreach (var uid in useridlist)
                    {
                        msgdtolist.Add(new MessageOperateDTO
                        {
                            UserID = uid,
                            SendTime = DateTime.Now,
                            MessageType = 1
                        });
                    }
                    TCSOFT.DMS.WebMain.Models.Provider.CommonProvider.AddMessageStat(msgdtolist);
                }
                // 发送邮件通知系统管理员
                string UserApplyEmailMessage = String.Format(WebConfiger.UserApplyEmailMessage, uam.UserApplyName, uam.DistributorNamestr);
                if (string.IsNullOrEmpty(uam.DistributorNamestr))
                {
                    UserApplyEmailMessage = UserApplyEmailMessage.Replace("经销商：", "");
                }
                EmailHelper.SendMessage("新用户申请", UserApplyEmailMessage, lstadmin.Select(g => g.Email).ToList(), null, null);
                result.SubmitResult = true;
                result.Message = "申请成功！";
            }
            else
            {
                result.SubmitResult = false;
                result.Message = "申请失败！";
            }

            return Json(result);
        }

        /// <summary>
        /// 客户权限变更申请
        /// </summary>
        /// <param name="ChangeAuth"></param>
        /// <returns></returns>
        public ActionResult ChangeAuthority(UserApplyModel uam)
        {
            ResultData<object> result = new ResultData<object>();
            uam.UserChangeID = ((UserLoginDTO)Session["UserLoginInfo"]).UserID;
            uam.ApplyAuth = uam.ApplyAuth.Where(p => p.IsChecked).ToList();
            uam.UserApplyTime = DateTime.Now;
            uam.AuditStatus = 0;
            if (UserApplyProvider.ChangeAuthority(uam))
            {
                // 发送短信通知系统管理员
                // 发送邮件通知系统管理员
                result.SubmitResult = true;
                result.Message = "变更申请成功！";
            }
            else
            {
                result.SubmitResult = false;
                result.Message = "变更申请失败！";
            }

            return Json(result);
        }

        /// <summary>
        /// 提交软件反馈
        /// </summary>
        /// <param name="ChangeAuth"></param>
        /// <returns></returns>
        public ActionResult SubmitFeedback(FeedbackOperateDTO dto)
        {
            bool result = true;
            ResultData<int> feedbackresult = new ResultData<int>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.FeedbackDate = DateTime.Now;
            dto.FeedbackStaus = 0;
            dto.UserID = user.UserID;
            try
            {
                feedbackresult = SystemProvider.AddFeedback(dto);
                if (feedbackresult.SubmitResult)
                {
                    List<MasterData.DTO.Common.AdminDTO> lstadmin = UserApplyProvider.GetAdminInfo(new MasterData.DTO.Common.AdminSearchDTO { RoleIdList = new List<int> { 99 } });

                    EmailHelper.SendMessage("问题反馈", WebConfiger.ProblemFeedbackMessage, lstadmin.Select(g => g.Email).Distinct().ToList(), null, null);
                }
            }
            catch (Exception ex)
            {
                feedbackresult.SubmitResult = false;
                feedbackresult.Message = ex.Message;
                result = false;
            }
            if (Request.Files.Count > 0 && result == true)
            {
                HttpPostedFileBase Filedata = Request.Files[0];
                string FileName = Guid.NewGuid().ToString();//保存的文件名
                string FileExtenSrcName = Filedata.FileName.Substring(Filedata.FileName.LastIndexOf("\\") + 1);//原文件名带扩展名
                string FileSrcName = FileExtenSrcName.Substring(0, FileExtenSrcName.LastIndexOf("."));//原文件名不带扩展名
                string FilePath = null;
                string FileExtenName = Path.GetExtension(Filedata.FileName); // 文件扩展名

                string strSaveDir = this.Server.MapPath("~/Attachments/Feedback");//存储目录
                if (!System.IO.Directory.Exists(strSaveDir))
                {
                    System.IO.Directory.CreateDirectory(strSaveDir);
                }
                FilePath = strSaveDir + "\\" + FileName;
                Filedata.SaveAs(FilePath);

                List<AttachFileOperateDTO> attachlist = new List<AttachFileOperateDTO>();
                AttachFileOperateDTO attach = new AttachFileOperateDTO();
                attach.BelongModulePrimaryKey = feedbackresult.Object.ToString();
                attach.AttachFileID = Guid.NewGuid();
                attach.AttachFileSrcName = FileSrcName;
                attach.BelongModule = 1;
                attach.AttachFileExtentionName = FileExtenName;
                attach.AttachFileName = FileName;
                attach.CreateTime = DateTime.Now;
                attach.CreateUser = user.FullName;
                attachlist.Add(attach);
                ResultData<object> attachresult = new ResultData<object>();
                attachresult = HomeProvider.AddAttachFileList(attachlist);
                if (!attachresult.SubmitResult)
                {
                    result = false;
                }
            }

            return Json(result);
        }
        /// <summary>
        /// 取得所有模块信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetAllModule()
        {

            List<StructureDTO> result = null;

            result= GlobalStaticData.StructureInfo.Where(p => p.ParentStructureID == null).ToList();

            //根据文档需求，此处需要重新根据用户拥有的权限ID来显示反馈的模块，然后根据返回的模块选择具体的功能Bind。
            var user = (TCSOFT.DMS.MasterData.DTO.UserLoginDTO)Session["UserLoginInfo"];
            var RTresult = user.CurrentAuthorityList;
            var UserStructureID=user.CurrentAuthorityList.Where(t => t.StructureID.Length < 4).ToList().Select(t=>t.StructureID);
            List<string> dto = new List<string>();

            result = result.Where(p => UserStructureID.Contains(p.StructureID)).ToList();
            return Json(result);

        }
        /// <summary>
        /// 取得反馈模块信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetSecondLevelModule(string ParentStructureID)
        {
            List<StructureDTO> result = null;

            result = GlobalStaticData.StructureInfo.Where(p => p.ParentStructureID == ParentStructureID).ToList();
            var user = (TCSOFT.DMS.MasterData.DTO.UserLoginDTO)Session["UserLoginInfo"];
            var RTresult = user.CurrentAuthorityList;
            var UserStructureID = user.CurrentAuthorityList.Where(t => t.StructureID.Substring(0, 3).ToString() == ParentStructureID&&t.StructureID.Length>=4&&t.StructureID.Length<7).Select(t=>t.StructureID).ToList();
            result = result.Where(p => UserStructureID.Contains(p.StructureID)).ToList();
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #region 提醒管理
        /// <summary>
        /// 得到提醒信息(界面显示5条)
        /// </summary>
        /// <returns></returns>
        public ActionResult GetWarningInfo(WarningSearchDTO dto)
        {
            dto.rows = 5;
            dto.page = 1;
            dto.WarningID = null;
            dto.MappingID = null;
            ResultData<List<WarningDTO>> result = new ResultData<List<WarningDTO>>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.UserID = user.UserID;
            result = HomeProvider.GetWarningInfo(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到提醒信息所有
        /// </summary>
        /// <returns></returns>
        public ActionResult GetWarningAllInfo(WarningSearchDTO dto)
        {
            ResultData<List<WarningDTO>> result = new ResultData<List<WarningDTO>>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.UserID = user.UserID;
            result = HomeProvider.GetWarningInfo(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到提醒信息pop（一条）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetWarningOneInfo(WarningSearchDTO dto)
        {
            dto.rows = 1;
            dto.page = 1;
            ResultData<List<WarningDTO>> result = new ResultData<List<WarningDTO>>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.UserID = user.UserID;
            result = HomeProvider.GetWarningInfo(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除一条提醒信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteWarningInfo(WarningSearchDTO dto)
        {
            ResultData<object> result = new ResultData<object>();

            try
            {
                result.SubmitResult = HomeProvider.DeleteWarningInfo(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion
        /// <summary>
        /// word文档下载，下载路径，下载的类型，下载的名字，可更改。
        /// </summary>
        /// <returns></returns>

        public FilePathResult Download()
        {
            return File("/TempLate/FAQ.docx", "docx", "常见问题.doc");
        }
    }

}
