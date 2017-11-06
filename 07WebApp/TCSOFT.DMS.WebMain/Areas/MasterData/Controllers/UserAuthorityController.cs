using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterData.DTO.Role;
using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Controllers
{
    using DMS.WebMain.Areas.MasterData.Models.Provider;
    using TCSOFT.DMS.MasterData.DTO;
    using TCSOFT.DMS.WebMain.Models.Model;
    using Common;
    using TCSOFT.DMS.WebMain.Filter;
    using Models.Model;
    using TCSOFT.DMS.WebMain.Models.Provider;
    using TCSOFT.DMS.MasterData.DTO.Distributor.Distributor;
    using TCSOFT.DMS.MasterData.DTO.ImportExcel;
    using TCSOFT.DMS.MasterData.DTO.Message;
    using System.Text;
    using TCSOFT.DMS.UserApply.DTO.User.UserApply;
    using TCSOFT.DMS.MasterData.DTO.User;
    public class UserAuthorityController : BaseController
    {
        // GET: MasterData/UserAuthority
        [AuthorityFilter(AuthorityID = "095006003")]
        public ActionResult RoleInfo()
        {
            ViewBag.CrruentAuthority = GetAuthority("095006003");
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            ViewBag.UserType = user.UserType;
            return View();
        }
        [AuthorityFilter(AuthorityID = "095006004")]
        public ActionResult DepartmentInfo()
        {
            ViewBag.CrruentAuthority = GetAuthority("095006004");

            return View();
        }
        [AuthorityFilter(AuthorityID = "095006002")]
        public ActionResult UserAudit()
        {
            ViewBag.CrruentAuthority = GetAuthority("095006002");

            return View();
        }

        [AuthorityFilter(AuthorityID = "095006001")]
        public ActionResult UserInfo()
        {
            ViewBag.CrruentAuthority = GetAuthority("095006001");
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            ViewBag.UserType = user.UserType;
            return View();
        }
        public ActionResult GetAllAuth(string userid, int type, int showroletype)
        {
            List<WebMain.Models.Model.AuthorityTreeModel> result = null;

            result = TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider.CommonProvider.GetAuthority(userid, type, showroletype);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #region 用户管理
        /// <summary>
        /// 得到所有用户信息(含模糊查询)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetUser(UserSearchDTO dto)
        {
            ResultData<List<UserResultDTO>> result = null;

            result = UserAuthorityProvider.GetUser(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetOneUser(int id)
        {
            ResultData<UserResultDTO> result = new ResultData<UserResultDTO>();

            try
            {
                if (id == 1)
                {
                    throw new Exception("系统初始化用户不予修改");
                }
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
        /// 用户信息新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddUser(UserOperateModel dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            try
            {
                dto.CreateUser = user.FullName;
                dto.CreateTime = DateTime.Now;
                dto.IsActive = true;

                result = UserAuthorityProvider.AddUser(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 用户信息修改/停启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateStopEnableUser(UserOperateModel dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            try
            {
                dto.ModifyUser = user.FullName;
                dto.ModifyTime = DateTime.Now;
                if (dto.IsActive == null)
                {
                }
                else
                {
                    if (dto.IsActive == true)
                    {
                        dto.NoActiveTime = null;
                    }
                    else
                    {
                        dto.NoActiveTime = DateTime.Now;
                    }
                }
                result = UserAuthorityProvider.UpdateStopEnableUser(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 用户信息删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteUser(UserOperate dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            try
            {
                dto.ModifyUser = user.FullName;
                if (dto.UserID == 1)
                {
                    throw new Exception("系统初始化用户不予删除");
                }
                result = UserAuthorityProvider.DeleteUser(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到经销商信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDistributorList(DistributorSearchDTO dto)
        {
            ResultData<List<DistributorResultDTO>> result = null;
            dto.page = 1;
            dto.rows = 10000000;
            result = ProductManagementProvider.GetDistributorList(dto);

            return Json(result.Object, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 导出用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportUser(UserSearchDTO dto)
        {
            string result = null;

            List<UserResultDTO> pp = null;
            dto.page = 1;
            dto.rows = 10000000;
            pp = UserAuthorityProvider.GetUser(dto).Object;

            string strTemplateFile = Server.MapPath(@"~/TempLate/UserTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            pp.ForEach(g =>
            {
                Models.Model.Excel.ExcelUser er = new Models.Model.Excel.ExcelUser();
                er.状态 = g.IsActivestr;
                er.用户编号 = g.UserCode;
                er.用户名称 = g.FullName;
                er.手机号 = g.PhoneNumber;
                er.邮箱 = g.Email;
                er.角色 = g.UserRoleName;
                er.经销商 = g.UserDistributorstr;
                er.到期日 = g.StopTime != null ? g.StopTime.Value.ToString("yyyy-MM-dd") : "";
                er.停用日期 = g.NoActiveTime != null ? g.NoActiveTime.Value.ToString("yyyy-MM-dd") : "";
                string quanx = "";
                g.UserAuthority.Where(p=>p.StructureID.Length==3).ToList().ForEach(a => 
                {
                    quanx += a.StructureName+"[";
                    g.UserAuthority.Where(p => p.StructureID.Length == 6&&p.StructureID.StartsWith(a.StructureID)).ToList().ForEach(b =>
                    {
                        quanx += b.StructureName + "(";
                        g.UserAuthority.Where(p => p.StructureID.Length == 9 && p.StructureID.StartsWith(b.StructureID)).ToList().ForEach(c =>
                        {
                            quanx += c.StructureName + ",";
                        });
                        quanx +=  "),";
                    });
                    quanx += "],";
                });
                er.权限 = quanx;

                ratelist.Add(er);
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        public FileContentResult DownloadUser(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("用户信息" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
        //导入
        public ActionResult ImportUser()
        {
            string strErrorPath = null;

            HttpFileCollectionBase httfiles = Request.Files;
            if (httfiles.Count > 0)
            {
                HttpPostedFileBase httpfile = httfiles[0];
                try
                {
                    List<string[]> arrstrmapplst = new List<string[]> { 
                        new string[]{"用户编号","UserCode"},
                        new string[]{"用户名称","FullName"},
                        new string[]{"手机号","PhoneNumber"},
                        new string[]{"邮箱","Email"},
                        new string[]{"角色","RoleNamestr"},
                        new string[]{"经销商","DistributorNamestr"},
                        new string[]{"到期日","StopTime"},
                        new string[]{"检测情况","CheckInfo"}
                    };
                    string strGenarateDir = Server.MapPath(@"~/TempFile");
                    string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
                    string strExportFile = strGenarateDir + "\\" + strGenarateFile;
                    List<ExcelUser> rplst = ExcelHelper.Import<ExcelUser>(httpfile.InputStream, "Sheet1", arrstrmapplst, CheckUserInfo, strExportFile);
                    if (rplst == null)
                    {
                        strErrorPath = strGenarateFile;
                    }
                    else
                    {
                        var boolD = UserAuthorityProvider.ImportUser(rplst);
                        if (!boolD.SubmitResult)
                        {
                            Logger.WriteLog(boolD.Message.ToString());
                            strErrorPath = "导入失败";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex.ToString());
                    strErrorPath = "导入失败";
                }
            }

            return Json(strErrorPath);
        }
        private bool CheckUserInfo(object obj)
        {
            bool result = true;
            List<ExcelUser> exceldto = (List<ExcelUser>)obj;
            UserSearchDTO dto = new UserSearchDTO();
            dto.rows = 100000000;
            dto.page = 1;
            var UserInfoList = UserAuthorityProvider.GetUser(dto);
            DistributorSearchDTO disdto = new DistributorSearchDTO();
            disdto.page = 1;
            disdto.rows = 1000000000;
            var distributorlist = DistributorProvider.GetDistributorList(disdto);//所有经销商
            RoleSearchDTO roleSearch = new RoleSearchDTO();
            var rolelist = UserAuthorityProvider.GetRoleList(roleSearch);
            string strimporter = ((UserLoginDTO)Session["UserLoginInfo"]).FullName;
            foreach (var p in exceldto)
            {
                StringBuilder sb = new StringBuilder();
                if (String.IsNullOrEmpty(p.UserCode))
                {
                    sb.Append("用户编号不可为空！ ");
                }
                else
                {
                    var UserID = UserInfoList.Object.Where(m => m.UserCode == p.UserCode).Select(m => m.UserID).FirstOrDefault();
                    if (UserID != null)
                    {
                        p.UserID = UserID;
                        p.UpLogic = 2;
                    }
                    else
                    {
                        p.UpLogic = 1;
                    }
                }
                if (String.IsNullOrEmpty(p.Email))
                {
                    sb.Append("用户邮箱不可为空！ ");
                }
                if (String.IsNullOrEmpty(p.PhoneNumber))
                {
                    sb.Append("用户手机号不可为空！ ");
                }
                else
                {
                    //手机号在此不做唯一性判断。
                    //var PhoneNumber = UserInfoList.Object.Where(m => m.PhoneNumber == p.PhoneNumber).Select(m => m.PhoneNumber).FirstOrDefault();
                    //if (PhoneNumber != null)
                    //{
                    //    sb.Append("用户手机号不可重复");
                    //}
                }
                if (String.IsNullOrEmpty(p.DistributorNamestr))
                {
                    //sb.Append("所属经销商不可为空!");
                }
                else
                {
                    foreach (var dis in p.DistributorNamelist)
                    {
                        var exist = distributorlist.Object.Where(m => m.DistributorName == dis).FirstOrDefault();
                        if (exist == null)
                        {
                            sb.Append("经销商名称填写错误！错误名称为" + dis + "请检查！");
                        }
                        else
                        {

                        }
                    }
                }
                if (String.IsNullOrEmpty(p.RoleNamestr))
                {
                    //sb.Append("用户角色不可为空！ ");
                }
                else
                {
                    foreach (var role in p.RoleNamelist)
                    {
                        var exist = rolelist.Where(m => m.RoleName == role).FirstOrDefault();
                        if (exist == null)
                        {
                            sb.Append("角色" + role + "不存在！");
                        }
                    }
                }
                if (String.IsNullOrEmpty(p.StopTime))
                {
                     sb.Append("使用的截止日期不可为空！ ");
                }
                p.Importer = strimporter;
                if (sb.Length > 0)
                {
                    p.CheckInfo = sb.ToString();
                    result = false;
                }
            }

            return result;
        }
        #endregion
        #region 用户审核
        /// <summary>
        /// 得到所有用户申请信息(含模糊查询)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetUserApply(UserApplySearchDTO dto)
        {
            ResultData<List<UserApplyResultDTOModel>> result = null;
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            dto.RoleIDlist = user.CurrentRoleIDList;
            result = UserAuthorityProvider.GetUserApply(dto);

            return Json(result.Object, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条用户申请信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetOneUserApply(UserApplySearchDTO dto)
        {
            ResultData<UserApplyResultDTOModel> result = new ResultData<UserApplyResultDTOModel>();
            DistributorSearchDTO disdto = new DistributorSearchDTO();
            try
            {
                string strSaveDir = this.Server.MapPath("~/Attachments");
                result = UserAuthorityProvider.GetOneUserApply(dto);
                result.SubmitResult = true;
                string ViewdisNameStr = "";

                if (!string.IsNullOrEmpty(result.Object.DistributorIDList))
                {
                    //查询经销商ID字符串转List
                    string disString = string.Empty;
                    string Disstr = result.Object.DistributorIDList;
                    List<string> DisList = new List<string>();
                    Disstr.Split(',').ToList().ForEach(g =>
                    {
                        disString = g.Trim();
                        if (!string.IsNullOrEmpty(disString))
                        {
                            DisList.Add(disString);
                        }
                    });
                    //根据经销商ID的List查询到经销商的姓名，并且拼接成字符串
                    foreach (var q in DisList)
                    {
                        Guid guid = new Guid(q);
                        disdto.DistributorID = guid;
                        disdto.rows = 10000;
                        disdto.page = 1;
                        var OneDisName = DistributorProvider.GetOneDistributor(disdto);
                        var DisName = OneDisName.Object.DistributorName;
                        ViewdisNameStr += DisName + ",";
                    }
                }

                result.Object.DistributorIDList = ViewdisNameStr;

                if (result.Object.BatchID != null)
                {
                    AttachFileSearchDTO attdto = new AttachFileSearchDTO();
                    attdto.BelongModule = 2;
                    attdto.BelongModulePrimaryKey = result.Object.BatchID.Value.ToString();
                    var att = UserAuthorityProvider.GetAttachFileList(attdto);
                    if (att != null)
                    {
                        result.Object.AttName = att.AttachFileName;
                        result.Object.AttSrcName = att.AttachFileSrcName;
                        result.Object.AttExtentionName = att.AttachFileExtentionName;
                        result.Object.IsAtt = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 用户申请审核（通过）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AuditUserApplyAdopt(UserApplyOperateDTO dto)
        {
            ResultData<UserApplyOperateDTO> result = new ResultData<UserApplyOperateDTO>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            try
            {
                dto.CreateUser = user.FullName;
                dto.RoleIDlist = user.CurrentRoleIDList;
                dto.AuditStatus = 1;
                result = UserAuthorityProvider.AuditUserApplyAdopt(dto);
                if (result.SubmitResult)
                {
                    result.Object.StopTime = DateTime.Now.AddYears(1);
                    UserAuthorityProvider.AuditUserApplyAdoptAut(result.Object);

                    //通过的模块名称
                    var aut = result.Object.ApplyUserAuthority.Select(s => s.StructureID).ToList();
                    var modelname = ModelRoleModel.ModelRolelist.Where(m => aut.Contains(m.ModelID)).Select(s => s.ModelName).ToList();
                    string modelstr = string.Join(",", modelname);

                    //取得申请人邮箱
                    UserApplySearchDTO batchdto = new UserApplySearchDTO();
                    batchdto.BatchID = result.Object.BatchID;
                    batchdto.Query = 1;
                    batchdto.page = 1;
                    batchdto.rows = 1;
                    var pp = UserAuthorityProvider.GetBatchUser(batchdto);

                    //发送邮件通知申请人
                    EmailHelper.SendMessage("用户审核通过", string.Format(WebConfiger.UserAuditPassEmailMessage, result.Object.UserApplyName, dto.Distributor, modelstr), new List<string> { pp.Object.ApplyUserEamil }, null, null);
                    // 发送短信通知申请人
                    MobileMessage.SendMessage(new List<string> { pp.Object.ApplyUserPhone }, String.Format(WebConfiger.UserAuditPassShortMessage, modelstr));
                }

            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 用户申请审核（拒绝）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AuditUserApplyRefuse(UserApplyOperateDTO dto)
        {
            ResultData<UserApplyOperateDTO> result = new ResultData<UserApplyOperateDTO>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            try
            {
                dto.ModifyUser = user.FullName;
                dto.RoleIDlist = user.CurrentRoleIDList;
                dto.AuditUserID = user.UserID;
                dto.AuditStatus= 2;
                result = UserAuthorityProvider.AuditUserApplyRefuse(dto);
                if (result.SubmitResult) 
                {
                    //通过的模块名称
                    var aut=result.Object.ApplyUserAuthority.Select(s=>s.StructureID).ToList();
                    var modelname = ModelRoleModel.ModelRolelist.Where(m => aut.Contains(m.ModelID)).Select(s => s.ModelName).ToList();
                    string modelstr = string.Join(",", modelname);

                    //取得申请人邮箱
                    UserApplySearchDTO batchdto = new UserApplySearchDTO();
                    batchdto.BatchID = result.Object.BatchID;
                    batchdto.Query = 1;
                    batchdto.page = 1;
                    batchdto.rows = 1;
                    var pp = UserAuthorityProvider.GetBatchUser(batchdto);

                    //发送邮件通知申请人
                    EmailHelper.SendMessage("用户审核拒绝", string.Format(WebConfiger.UserAuditRefuseEmailMessage, result.Object.UserApplyName, dto.Distributor, modelstr, dto.AuditFalseReason), new List<string> { pp.Object.ApplyUserEamil }, null, null);
                    //发送短信通知申请人
                    MobileMessage.SendMessage(new List<string> { pp.Object.ApplyUserPhone }, String.Format(WebConfiger.UserAuditRefuseShortMessage, modelstr, dto.AuditFalseReason));
                }
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 已授权用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetUsersByAuthorited(UsersByAuthoritedSearchDTO dto)
        {
            ResultData<List<AuthModuleUserModel>> result = null;
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            dto.RoleIDlist = user.CurrentRoleIDList;
            var pp = new List<TCSOFT.DMS.MasterData.DTO.User.UserApplyAuthority>();
            dto.ApplyUserAuthority.Where(w => w.StructureID.Length == 3).ToList().ForEach(f =>
            {
                if (pp.Where(p => p.StructureID == f.StructureID).FirstOrDefault() == null)
                {
                    pp.Add(f);
                }
            });
            dto.ApplyUserAuthority = pp;
            result = UserAuthorityProvider.GetUsersByAuthorited(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetOneUserApplyAtt(string AttName, string AttSrcName, string AttExtentionName)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/Attachments");
            string strExportFile = strGenarateDir + "\\" + AttName + AttExtentionName;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode(AttSrcName + AttExtentionName));

            return fileresult;
        }
        /// <summary>
        /// 获取申请用户权限
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserApplyAuthorityInfo(UserApplySearchDTO dto)
        {
            List<AuthorityListModel> result = new List<AuthorityListModel>();

            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            var rolelis = user.CurrentRoleIDList;
            var modelid = ModelRoleModel.ModelRolelist.Where(m => rolelis.Contains(m.RoleID) && (m.RoleID >= 2 && m.RoleID <= 13)).Select(s => s.ModelID).ToList();
            dto.Query = 2;
            var pp = UserAuthorityProvider.GetOneUserApply(dto).Object;

            List<StructureDTO> strcdtolevelone = null;
            List<StructureDTO> strcdtoleveltwo = null;
            List<StructureDTO> strcdtolevelthree = null;

            strcdtolevelone = GlobalStaticData.StructureInfo.Where(p => modelid.Contains(p.StructureID) && p.ParentStructureID == null).ToList();
            strcdtoleveltwo = GlobalStaticData.StructureInfo.Where(p => modelid.Contains(p.StructureID.Substring(0,3)) && p.StructureID.Length == 6).ToList();
            strcdtolevelthree = GlobalStaticData.StructureInfo.Where(p => modelid.Contains(p.StructureID.Substring(0, 3)) && p.StructureID.Length == 9).ToList();
            
            foreach (var p in strcdtolevelone)
            {
                var tow = strcdtoleveltwo.Where(g => g.ParentStructureID == p.StructureID);
                if (tow.Count() == 0)
                {
                    AuthorityListModel alm = new AuthorityListModel();
                    result.Add(alm);
                    alm.LevelOne = p;
                    if (pp.ApplyUserAuthority.Where(x => x.StructureID == p.StructureID).FirstOrDefault() != null)
                    {
                        alm.IsChecked = true;
                    }
                    else
                    {
                        alm.IsChecked = false;
                    }
                }
                foreach (var t in tow)
                {
                    var three = strcdtolevelthree.Where(g => g.ParentStructureID == t.StructureID);
                    if (three.Count() == 0)
                    {
                        AuthorityListModel alm = new AuthorityListModel();
                        result.Add(alm);
                        alm.LevelOne = p;
                        alm.LevelTWO = t;
                        alm.IsChecked = false;
                        
                        if (pp.ApplyUserAuthority.Where(x => x.StructureID == t.StructureID).FirstOrDefault()!=null)
                        {
                            alm.IsChecked = true;
                        }
                        else
                        {
                            alm.IsChecked = false;
                        }
                    }
                    foreach (var w in three)
                    {
                        AuthorityListModel alm = new AuthorityListModel();
                        result.Add(alm);
                        alm.LevelOne = p;
                        alm.LevelTWO = t;
                        alm.LevelThree = w;
                        if (pp.ApplyUserAuthority.Where(x => x.StructureID == w.StructureID).FirstOrDefault() != null)
                        {
                            alm.IsChecked = true;
                        }
                        else
                        {
                            alm.IsChecked = false;
                        }
                    }

                }
            }

            return Json(new { rows = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 角色管理
        /// <summary>
        /// 得到所有角色信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRoleList(RoleSearchDTO dto)
        {
            var result = UserAuthorityProvider.GetRoleList(dto);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到所有角色信息(用户管理)
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllRoleList(int? id)
        {
            var result = UserAuthorityProvider.GetAllRoleList(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条角色信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRole(int id)
        {
            ResultData<RoleResultDTO> result = new ResultData<RoleResultDTO>();

            try
            {
                result = UserAuthorityProvider.GetRole(id);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增角色信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AddRole(RoleOperateModel dto)
        {
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            dto.IsActive = true;
            ResultData<object> result = new ResultData<object>();

            try
            {
                result = UserAuthorityProvider.AddRole(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateRole(RoleOperateModel dto)
        {
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.IsActive = true;
            ResultData<object> result = new ResultData<object>();
            try
            {
                result = UserAuthorityProvider.UpdateRole(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteRole(RoleSearchDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            try
            {
                result = UserAuthorityProvider.DeleteRole(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 导出角色管理
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportRole(RoleSearchDTO dto)
        {
            string result = null;

            List<RoleResultDTO> pp = null;
            pp = UserAuthorityProvider.GetRoleList(dto);

            string strTemplateFile = Server.MapPath(@"~/TempLate/RoleTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            //角色
            pp.ForEach(g =>
            {
                //一级权限
                var aa = g.RoleAuthority.Where(w => w.StructureID.Length == 3).ToList();
                if (aa.Count == 0)
                {
                    Models.Model.Excel.ExcelRole er = new Models.Model.Excel.ExcelRole();
                    er.角色名称 = g.RoleName;
                    er.角色类别 = g.RoleTypeStr;
                    ratelist.Add(er);
                }
                aa.ForEach(a =>
                {
                    //二级权限
                    var bb = g.RoleAuthority.Where(w => w.StructureID.Length == 6 && w.StructureID.StartsWith(a.StructureID)).ToList();
                    if (bb.Count == 0)
                    {
                        Models.Model.Excel.ExcelRole er = new Models.Model.Excel.ExcelRole();
                        er.角色名称 = g.RoleName;
                        er.角色类别 = g.RoleTypeStr;
                        er.一级模块权限 = a.StructureName;
                        ratelist.Add(er);
                    }
                    bb.ForEach(b =>
                    {
                        //三级权限
                        var cc = g.RoleAuthority.Where(w => w.StructureID.Length == 9 && w.StructureID.StartsWith(b.StructureID)).ToList();
                        if (cc.Count == 0)
                        {
                            Models.Model.Excel.ExcelRole er = new Models.Model.Excel.ExcelRole();
                            er.角色名称 = g.RoleName;
                            er.角色类别 = g.RoleTypeStr;
                            er.一级模块权限 = a.StructureName;
                            er.二级模块权限 = b.StructureName;
                            ratelist.Add(er);
                        }
                        cc.ForEach(c =>
                        {
                            //三级权限功能按钮
                            Models.Model.Excel.ExcelRole er = new Models.Model.Excel.ExcelRole();
                            er.角色名称 = g.RoleName;
                            er.角色类别 = g.RoleTypeStr;
                            er.一级模块权限 = a.StructureName;
                            er.二级模块权限 = b.StructureName;
                            er.三级模块权限 = c.StructureName;
                            er.功能权限 = string.Join(",", GlobalStaticData.ButtonInfo.Where(w => (c.RoleButtonAuthority | w.ButtonID) == c.RoleButtonAuthority).Select(s => s.ButtonValue));
                            ratelist.Add(er);
                        });
                    });
                });
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        public FileContentResult DownloadRole(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("角色管理" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
        #endregion
        #region 部门管理
        /// <summary>
        /// 得到所有部门信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDepartmentList()
        {
            var result = UserAuthorityProvider.GetDepartmentList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条部门信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDepartment(int id)
        {
            ResultData<DepartmentResultDTO> result = new ResultData<DepartmentResultDTO>();
            try
            {
                result = UserAuthorityProvider.GetDepartment(id);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增部门信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AddDepartment(DepartmentOperateDTO dto)
        {
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            ResultData<object> result = new ResultData<object>();
            try
            {
                result = UserAuthorityProvider.AddDepartment(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateDepartment(DepartmentOperateDTO dto)
        {
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            ResultData<object> result = new ResultData<object>();
            try
            {
                result = UserAuthorityProvider.UpdateDepartment(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteDepartment(DepartmentSearchDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            try
            {
                result = UserAuthorityProvider.DeleteDepartment(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 初始化上级部门
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDepartmentTree()
        {
            var result = UserAuthorityProvider.GetDepartmentTree();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        /// <summary>
        /// 得到所有权限
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllAuthority(string roleid, int showroletype)
        {
            var result = TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider.CommonProvider.GetAuthority(roleid, 2, showroletype);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}