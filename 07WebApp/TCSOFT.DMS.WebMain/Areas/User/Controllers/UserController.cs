using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TCSOFT.DMS.MasterData.DTO;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterData.DTO.Distributor.Distributor;
using TCSOFT.DMS.MasterData.DTO.Message;
using TCSOFT.DMS.MasterData.DTO.Role;
using TCSOFT.DMS.MasterData.DTO.User;
using TCSOFT.DMS.UserApply.DTO.ImportExcel;
using TCSOFT.DMS.UserApply.DTO.User.UserApply;
using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider;
using TCSOFT.DMS.WebMain.Areas.User.Models.Model;
using TCSOFT.DMS.WebMain.Areas.User.Models.Provider;
using TCSOFT.DMS.WebMain.Common;
using TCSOFT.DMS.WebMain.Models.Model;
using TCSOFT.DMS.WebMain.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.User.Controllers
{
    public class UserController : Controller
    {
        #region
        // GET: User/User
        public ActionResult CreateUser()
        {
            return View();
        }
        public ActionResult ExistingUser()
        {
            return View();
        }
        public ActionResult DisableUser()
        {
            return View();
        }
        #endregion

        #region 用户申请
        /// <summary>
        /// 得到申请批次信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetUserBatcApply(UserApplySearchDTO dto)
        {
            ResultData<List<UserApplyBatchchResultModel>> result = null;
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.Query = 1;
            dto.DistributorID = user.DistributorIDlist != null ? user.DistributorIDlist.FirstOrDefault() : null;

            result = ApplyUserProvider.GetApplyBatchUser(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 申请用户保存
        /// </summary>
        /// <param name="uam"></param>
        /// <returns></returns>
        public ActionResult UserApply(UserApplyModel uam, Guid? BatchID)
        {
            ResultData<object> result = new ResultData<object>();
            short shtStatuscode = -1;
            if (HomeProvider.CheckPhoneNumber(uam.UserApplyTelNumber, ref shtStatuscode))
            {
                result.SubmitResult = false;
                result.Message = "手机号已存在，不可重复申请！";

                return Json(result);
            }
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            uam.DistributorIDList = user.DistributorIDlist != null ? user.DistributorIDlist.Select(s => s.Value.ToString()).FirstOrDefault() : null;
            uam.UserApplyType = short.Parse(user.UserType.ToString());
            uam.ApplyAuth = uam.ApplyAuth.Where(p => p.IsChecked).ToList();
            uam.UserApplyTime = DateTime.Now;
            uam.AuditStatus = 3;
            uam.CreateUser = user.FullName;
            uam.CreateTime = DateTime.Now;

            BatchApplyOperateDTO ba = new BatchApplyOperateDTO();
            ba.BatchApplyUser = new List<UserApplyOperateDTO> { uam };
            ba.BatchID = BatchID != null ? BatchID : Guid.NewGuid();
            ba.BatchName = uam.UserApplyName;
            ba.ApplyUser = uam.UserApplyName;
            ba.ApplyUserEamil = uam.UserApplyEmail;
            ba.ApplyUserPhone = uam.UserApplyTelNumber;
            ba.DistributorID = uam.DistributorIDList;
            ba.ApplyTime = uam.UserApplyTime;
            ba.Status = 2;
            ba.AuditStatus = 3;
            ba.CreateUser = user.FullName;
            ba.CreateTime = DateTime.Now;

            result = ApplyUserProvider.AddApplyUser(ba);

            return Json(result);
        }
        /// <summary>
        /// 申请用户批次保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult BachApply(List<UserApplyModel> model, string BatchName, Guid? AttachBachID)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            BatchApplyOperateDTO ba = new BatchApplyOperateDTO();

            ba.BatchID = AttachBachID == null ? Guid.NewGuid() : AttachBachID;
            ba.BatchApplyUser = new List<UserApplyOperateDTO>();

            string disid = user.DistributorIDlist != null ? user.DistributorIDlist.Select(s => s.Value.ToString()).FirstOrDefault() : null;
            foreach (var uam in model)
            {
                uam.UserApplyType = short.Parse(user.UserType.ToString());
                if (uam.ApplyAuth != null)
                {
                    uam.ApplyAuth = uam.ApplyAuth.Where(p => p.IsChecked).ToList();
                }
                uam.UserApplyType = short.Parse(user.UserType.ToString());
                uam.DistributorIDList = disid;
                uam.UserApplyTime = DateTime.Now;
                uam.AuditStatus = 3;
                uam.CreateUser = user.FullName;
                uam.CreateTime = DateTime.Now;
                ba.BatchApplyUser.Add(uam);
            }

            ba.AuditStatus = 3;
            ba.BatchName = BatchName;
            ba.ApplyUser = user.FullName;
            ba.ApplyUserEamil = user.Email;
            ba.ApplyUserPhone = user.PhoneNumber;
            ba.DistributorID = disid;
            ba.ApplyTime = DateTime.Now;
            ba.Status = 1;
            ba.AuditStatus = 3;
            ba.CreateUser = user.FullName;
            ba.CreateTime = DateTime.Now;
            result = ApplyUserProvider.AddApplyUser(ba);

            return Json(result);
        }
        /// <summary>
        /// 得到一个用户申请信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetOneUserApply(UserApplySearchDTO dto)
        {
            ResultData<UserApplyUserResultDTO> result = null;
            dto.Query = 2;
            result = ApplyUserProvider.GetOneUserApply(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一个批次用户申请信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetOneBachUserApply(UserApplySearchDTO dto)
        {
            ResultData<List<UserApplyUserResultDTO>> result = null;
            dto.Query = 2;
            result = ApplyUserProvider.GetOneBachUserApply(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 用户申请/批次申请
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Apply(BatchApplyOperateDTO dto)
        {
            // 1、根据传入批次ID，查找对应申请人员邮箱、手机号，同时返回每个人对应的权限
            // 2、根据权限查找对应权限管理员的邮箱、手机号
            // 3、根据申请人匹配对应的管理员邮箱手机号
            ResultData<List<UserApplyOperateDTO>> result = new ResultData<List<UserApplyOperateDTO>>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.AuditStatus = 0;
            dto.BatchIDlist = new List<Guid?>() { dto.BatchID };
            result = ApplyUserProvider.ApplyUser(dto);

            //取得对应权限管理员的邮箱、手机号
            var pp = result.Object.SelectMany(w => w.ApplyUserAuthority.Select(s => s.StructureID)).Distinct().ToList();
            var roel = ModelRoleDTO.ModelRolelist.Where(w => pp.Contains(w.ModelID)).Select(s => s.RoleID).Distinct().ToList();
            List<AdminDTO> lstadmin = UserApplyProvider.GetAdminInfo(new AdminSearchDTO { RoleIdList = roel });

            //发邮件/短信
            foreach (var uaerapply in result.Object)
            {
                var sw = ModelRoleDTO.ModelRolelist.Where(p => uaerapply.ApplyUserAuthority.Select(s => s.StructureID).Contains(p.ModelID)).Select(s => s.RoleID).ToList();
                var sys = lstadmin.Where(w => sw.Contains(w.RoleID)).ToList();

                var email = sys.Select(s => s.Email).Distinct().ToList();
                var phone = sys.Select(s => s.PhoneNumber).Distinct().ToList();
                var disname = user.DistributorIDlist != null ? user.DistributorNamelist.FirstOrDefault() : null;
                string UserApplyEmailMessage = String.Format(WebConfiger.UserApplyEmailMessage, uaerapply.UserApplyName, disname);
                EmailHelper.SendMessage("新用户申请", UserApplyEmailMessage, email, null, null);
                string UserApplyShortMessage = String.Format(WebConfiger.UserApplyShortMessage, uaerapply.UserApplyName, disname);
                MobileMessage.SendMessage(phone, UserApplyShortMessage);
            }
            var useridlist = lstadmin.Select(g => g.UserID).Distinct().ToList();
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

            return Json(result);
        }
        /// <summary>
        /// 用户全部申请/批次全部申请
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult WholeApply(List<UserApplyResultModel> model)
        {
            ResultData<List<UserApplyOperateDTO>> result = new ResultData<List<UserApplyOperateDTO>>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            BatchApplyOperateDTO dto = new BatchApplyOperateDTO();
            if (model != null)
            {
                dto.BatchIDlist = model.Where(w => w.AuditStatus == 3).Select(s => s.BatchID).ToList();
            }
            dto.AuditStatus = 0;
            if (dto.BatchIDlist == null || dto.BatchIDlist.Count() == 0)
            {
                result.SubmitResult = true;
            }
            else
            {
                result = ApplyUserProvider.ApplyUser(dto);

                //取得对应权限管理员的邮箱、手机号
                var pp = result.Object.SelectMany(w => w.ApplyUserAuthority.Select(s => s.StructureID)).Distinct().ToList();
                var roel = ModelRoleDTO.ModelRolelist.Where(w => pp.Contains(w.ModelID)).Select(s => s.RoleID).Distinct().ToList();
                List<AdminDTO> lstadmin = UserApplyProvider.GetAdminInfo(new AdminSearchDTO { RoleIdList = roel });
                var disname = user.DistributorIDlist != null ? user.DistributorNamelist.FirstOrDefault() : null;
                //发邮件/短信
                foreach (var uaerapply in result.Object)
                {
                    var sw = ModelRoleDTO.ModelRolelist.Where(p => uaerapply.ApplyUserAuthority.Select(s => s.StructureID).Contains(p.ModelID)).Select(s => s.RoleID);
                    var sys = lstadmin.Where(w => sw.Contains(w.RoleID)).ToList();

                    var email = sys.Select(s => s.Email).Distinct().ToList();
                    var phone = sys.Select(s => s.PhoneNumber).Distinct().ToList();

                    string UserApplyEmailMessage = String.Format(WebConfiger.UserApplyEmailMessage, uaerapply.UserApplyName, disname);
                    EmailHelper.SendMessage("新用户申请", UserApplyEmailMessage, email, null, null);
                    string UserApplyShortMessage = String.Format(WebConfiger.UserApplyShortMessage, uaerapply.UserApplyName, disname);
                    MobileMessage.SendMessage(phone, UserApplyShortMessage);
                }
                var useridlist = lstadmin.Select(g => g.UserID).Distinct().ToList();
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
            }

            return Json(result);
        }
        /// <summary>
        /// 上传用户名单附件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult AddAttachFileList(Guid? BatchIDFile)
        {
            ResultData<object> result = new ResultData<object>();

            HttpPostedFileBase Filedata = Request.Files[0];
            Guid Batch = BatchIDFile != null ? BatchIDFile.Value : Guid.NewGuid();
            string FilePath = null;
            string extName = Path.GetExtension(Filedata.FileName); // 文件扩展名
            var arrfilename = Filedata.FileName.Split('\\');
            var name = arrfilename[arrfilename.Length - 1].Replace(extName, "");

            string strSaveDir = this.Server.MapPath("~/Attachments");
            IsExists(strSaveDir);
            FilePath = strSaveDir + "\\" + Batch.ToString() + extName;
            Filedata.SaveAs(FilePath);

            List<AttachFileOperateDTO> dtolist = new List<AttachFileOperateDTO>() 
            {
                new AttachFileOperateDTO(){ 
                    AttachFileID = Guid.NewGuid(),
                    AttachFileExtentionName = extName, 
                    AttachFileName = Batch.ToString(),
                    AttachFileSrcName = name,
                    BelongModule = 2,
                    BelongModulePrimaryKey = Batch.ToString()
                }
            };
            AttachFileOperateDTO dto = new AttachFileOperateDTO();
            dto.BelongModulePrimaryKey = Batch.ToString();
            dto.BelongModule = 2;
            ApplyUserProvider.DelAttachFileList(dto);
            result = ApplyUserProvider.AddAttachFileList(dtolist);
            if (result.SubmitResult)
            {
                result.Object = Batch;
            }

            return Json(result);
        }
        private void IsExists(string strSaveDir)
        {
            if (!System.IO.Directory.Exists(strSaveDir))
            {
                System.IO.Directory.CreateDirectory(strSaveDir);
            }
        }
        /// <summary>
        /// 得到所有角色信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRoleList(RoleSearchDTO dto)
        {
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.RoleType = user.UserType;
            var result = ApplyUserProvider.GetRoleList(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 已有用户
        /// <summary>
        /// 得到启用用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetEnableUser(UserSearchDTO dto)
        {
            ResultData<List<UserModel>> result = null;
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            if (user.UserType == 2)
            {
                dto.UserType = (short)user.UserType;
            }
            dto.DistributorIDList = user.DistributorIDlist != null ? user.DistributorIDlist : null;
            dto.QueryType = 2;
            result = ExistUserProvider.GetEnableUser(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条启用用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetOneEnableUser(UserSearchDTO dto)
        {
            ResultData<UserModel> result = null;
            dto.page = 1;
            dto.rows = 1;
            result = ExistUserProvider.GetOneEnableUser(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 用户信息停用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult StopUser(UserOperate dto)
        {
            ResultData<object> result = new ResultData<object>();

            try
            {
                dto.IsActive = false;
                dto.ModifyTime = DateTime.Now;
                result = ExistUserProvider.StopUser(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 变更权限
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ChangeUserAut(UserApplyModel dto, int? Userid)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            try
            {
                dto.DistributorIDList = user.DistributorIDlist != null ? user.DistributorIDlist.Select(s => s.Value.ToString()).FirstOrDefault() : null;
                dto.UserApplyType = short.Parse(user.UserType.ToString());
                dto.ApplyAuth = dto.ApplyAuth.Where(p => p.IsChecked).ToList();
                dto.UserApplyTime = DateTime.Now;
                dto.AuditStatus = 0;

                BatchApplyOperateDTO ba = new BatchApplyOperateDTO();
                ba.BatchApplyUser = new List<UserApplyOperateDTO> { dto };
                ba.BatchID = Guid.NewGuid();
                ba.BatchName = dto.UserApplyName;
                ba.ApplyUser = dto.UserApplyName;
                ba.ApplyUserEamil = dto.UserApplyEmail;
                ba.ApplyUserPhone = dto.UserApplyTelNumber;
                ba.DistributorID = dto.DistributorIDList;
                ba.ApplyTime = dto.UserApplyTime;
                ba.Status = 2;
                ba.AuditStatus = 0;

                //取得变更模块
                var UserAut = ExistUserProvider.GetUserAuthorityInfo(dto.UserChangeID.ToString(), 1, null);
                var chengid = (dto.ApplyUserAuthority.Select(s => s.StructureID).Except(UserAut.Select(s => s.StructureID))).Union(
                    UserAut.Select(s => s.StructureID).Except(dto.ApplyUserAuthority.Select(s => s.StructureID))).ToList();
                chengid = chengid.Select(s => s.Substring(0, 3)).Distinct().ToList();
                //模块ID
                var rloe = ModelRoleModel.ModelRolelist.Where(m => chengid.Contains(m.ModelID)).Select(s => s.RoleID).ToList();
                if (chengid.Count() == 0)
                {
                    throw new Exception("没有变更权限无法申请");
                }
                else
                {
                    dto.AuditRoleIDList = ",";
                    foreach (var r in rloe)
                    {
                        dto.AuditRoleIDList += r.ToString();
                        dto.AuditRoleIDList += ",";
                    }
                }
                result = ApplyUserProvider.AddApplyUser(ba);

                if (result.SubmitResult)
                {

                    //取得模块管理员邮箱
                    List<AdminDTO> lstadmin = UserApplyProvider.GetAdminInfo(new AdminSearchDTO { RoleIdList = rloe });
                    var phone = lstadmin.Select(t => t.PhoneNumber).Distinct().ToList();
                    var email = lstadmin.Select(t => t.Email).Distinct().ToList();
                    var disname = user.DistributorIDlist != null ? user.DistributorNamelist.FirstOrDefault() : null;

                    string UserApplyEmailMessage = String.Format(WebConfiger.UserApplyEmailMessage, dto.UserApplyName, disname);
                    EmailHelper.SendMessage("新用户申请", UserApplyEmailMessage, email, null, null);
                    string UserApplyShortMessage = String.Format(WebConfiger.UserApplyShortMessage, dto.UserApplyName, disname);
                    MobileMessage.SendMessage(phone, UserApplyShortMessage);

                    var useridlist = lstadmin.Select(g => g.UserID).Distinct().ToList();
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
                }
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 停用用户
        /// <summary>
        /// 得到停用用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetStopUser(UserSearchDTO dto)
        {
            ResultData<List<UserModel>> result = null;
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            if (user.UserType == 2)
            {
                dto.UserType = (short)user.UserType;
            }
            dto.DistributorIDList = user.DistributorIDlist != null ? user.DistributorIDlist : null;
            dto.QueryType = 3;
            result = StopUserProvider.GetStopUser(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 用户启用
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult EnableUser(UserOperate dto)
        {
            ResultData<object> result = new ResultData<object>();

            try
            {
                dto.IsActive = true;
                result = StopUserProvider.EnableUser(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 获取权限
        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public ActionResult GetAuthorityInfo(string types)
        {
            List<AuthorityListModel> result = new List<AuthorityListModel>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            types = user.UserType.ToString();

            List<StructureDTO> strcdtolevelone = null;
            List<StructureDTO> strcdtoleveltwo = null;
            List<StructureDTO> strcdtolecelthree = null;
            switch (user.UserType)
            {
                case 0:
                    strcdtolevelone = GlobalStaticData.StructureInfo.Where(p => p.ParentStructureID == null).ToList();
                    strcdtoleveltwo = GlobalStaticData.StructureInfo.Where(p => p.StructureID.Length < 7).ToList();
                    strcdtolecelthree = GlobalStaticData.StructureInfo.Where(p => p.StructureID.Length == 9).ToList();
                    break;
                case 1:
                    strcdtolevelone = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("0") || p.StructureID.StartsWith("9")) && p.ParentStructureID == null).ToList();
                    strcdtoleveltwo = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("0") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 6).ToList();
                    strcdtolecelthree = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("0") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 9).ToList();

                    break;
                case 2:
                    strcdtolevelone = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("1") || p.StructureID.StartsWith("9")) && p.ParentStructureID == null).ToList();
                    strcdtoleveltwo = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("1") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 6).ToList();
                    strcdtolecelthree = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("1") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 9).ToList();
                    break;
            }
            foreach (var p in strcdtolevelone)
            {
                var tow = strcdtoleveltwo.Where(g => g.ParentStructureID == p.StructureID).ToList();
                if (tow.Count() == 0)
                {
                    AuthorityListModel alm = new AuthorityListModel();
                    result.Add(alm);
                    alm.LevelOne = p;
                    alm.IsChecked = false;
                }
                foreach (var t in tow)
                {
                    var three = strcdtolecelthree.Where(g => g.ParentStructureID == t.StructureID).ToList();
                    if (three.Count() == 0)
                    {
                        AuthorityListModel alm = new AuthorityListModel();
                        result.Add(alm);
                        alm.LevelOne = p;
                        alm.LevelTWO = t;
                        alm.IsChecked = false;
                    }
                    foreach (var w in three)
                    {
                        AuthorityListModel alm = new AuthorityListModel();
                        result.Add(alm);
                        alm.LevelOne = p;
                        alm.LevelTWO = t;
                        alm.LevelThree = w;
                        alm.IsChecked = false;
                    }
                }
            }

            return Json(new { rows = result }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserAuthorityInfo(int? userid)
        {
            List<AuthorityListModel> result = new List<AuthorityListModel>();

            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            var pp = ExistUserProvider.GetUserAuthorityInfo(userid.Value.ToString(), 1, null);

            List<StructureDTO> strcdtolevelone = null;
            List<StructureDTO> strcdtoleveltwo = null;
            List<StructureDTO> strcdtolecelthree = null;
            switch (user.UserType)
            {
                case 0:
                    strcdtolevelone = GlobalStaticData.StructureInfo.Where(p => p.ParentStructureID == null).ToList();
                    strcdtoleveltwo = GlobalStaticData.StructureInfo.Where(p => p.StructureID.Length < 7).ToList();
                    strcdtolecelthree = GlobalStaticData.StructureInfo.Where(p => p.StructureID.Length == 9).ToList();
                    break;
                case 1:
                    strcdtolevelone = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("0") || p.StructureID.StartsWith("9")) && p.ParentStructureID == null).ToList();
                    strcdtoleveltwo = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("0") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 6).ToList();
                    strcdtolecelthree = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("0") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 9).ToList();

                    break;
                case 2:
                    strcdtolevelone = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("1") || p.StructureID.StartsWith("9")) && p.ParentStructureID == null).ToList();
                    strcdtoleveltwo = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("1") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 6).ToList();
                    strcdtolecelthree = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("1") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 9).ToList();
                    break;
            }
            foreach (var p in strcdtolevelone)
            {
                var tow = strcdtoleveltwo.Where(g => g.ParentStructureID == p.StructureID);
                if (tow.Count() == 0)
                {
                    AuthorityListModel alm = new AuthorityListModel();
                    result.Add(alm);
                    alm.LevelOne = p;
                    if (pp.Where(x => x.StructureID == p.StructureID).FirstOrDefault() != null)
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
                    var three = strcdtolecelthree.Where(g => g.ParentStructureID == t.StructureID);
                    if (three.Count() == 0)
                    {
                        AuthorityListModel alm = new AuthorityListModel();
                        result.Add(alm);
                        alm.LevelOne = p;
                        alm.LevelTWO = t;
                        alm.IsChecked = false;
                        if (pp.Where(x => x.StructureID == t.StructureID).FirstOrDefault() != null)
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
                        if (pp.Where(x => x.StructureID == w.StructureID).FirstOrDefault() != null)
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
        /// <summary>
        /// 获取单个用户的神情权限List
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetUserAuthList(List<TCSOFT.DMS.UserApply.DTO.User.UserApply.UserApplyAuthority> ApplyUserAuthority)
        {
            List<AuthorityListModel> result = new List<AuthorityListModel>();

            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            List<StructureDTO> strcdtolevelone = null;
            List<StructureDTO> strcdtoleveltwo = null;
            List<StructureDTO> strcdtolecelthree = null;
            switch (user.UserType)
            {
                case 0:
                    strcdtolevelone = GlobalStaticData.StructureInfo.Where(p => p.ParentStructureID == null).ToList();
                    strcdtoleveltwo = GlobalStaticData.StructureInfo.Where(p => p.StructureID.Length < 7).ToList();
                    strcdtolecelthree = GlobalStaticData.StructureInfo.Where(p => p.StructureID.Length == 9).ToList();
                    break;
                case 1:
                    strcdtolevelone = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("0") || p.StructureID.StartsWith("9")) && p.ParentStructureID == null).ToList();
                    strcdtoleveltwo = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("0") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 6).ToList();
                    strcdtolecelthree = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("0") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 9).ToList();

                    break;
                case 2:
                    strcdtolevelone = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("1") || p.StructureID.StartsWith("9")) && p.ParentStructureID == null).ToList();
                    strcdtoleveltwo = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("1") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 6).ToList();
                    strcdtolecelthree = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("1") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 9).ToList();
                    break;
            }
            foreach (var p in strcdtolevelone)
            {
                var tow = strcdtoleveltwo.Where(g => g.ParentStructureID == p.StructureID);
                if (tow.Count() == 0)
                {
                    AuthorityListModel alm = new AuthorityListModel();
                    result.Add(alm);
                    alm.LevelOne = p;
                    if (ApplyUserAuthority.Where(x => x.StructureID == p.StructureID).FirstOrDefault() != null)
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
                    var three = strcdtolecelthree.Where(g => g.ParentStructureID == t.StructureID);
                    if (three.Count() == 0)
                    {
                        AuthorityListModel alm = new AuthorityListModel();
                        result.Add(alm);
                        alm.LevelOne = p;
                        alm.LevelTWO = t;
                        alm.IsChecked = false;
                        if (ApplyUserAuthority.Where(x => x.StructureID == t.StructureID).FirstOrDefault() != null)
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
                        if (ApplyUserAuthority.Where(x => x.StructureID == w.StructureID).FirstOrDefault() != null)
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
        /// <summary>
        /// 获取申请用户权限
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserApplyAuthorityInfo(UserApplySearchDTO dto)
        {
            List<AuthorityListModel> result = new List<AuthorityListModel>();

            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.Query = 2;
            var pp = ApplyUserProvider.GetOneUserApply(dto).Object;

            List<StructureDTO> strcdtolevelone = null;
            List<StructureDTO> strcdtoleveltwo = null;
            List<StructureDTO> strcdtolecelthree = null;
            switch (user.UserType)
            {
                case 0:
                    strcdtolevelone = GlobalStaticData.StructureInfo.Where(p => p.ParentStructureID == null).ToList();
                    strcdtoleveltwo = GlobalStaticData.StructureInfo.Where(p => p.StructureID.Length < 7).ToList();
                    strcdtolecelthree = GlobalStaticData.StructureInfo.Where(p => p.StructureID.Length == 9).ToList();
                    break;
                case 1:
                    strcdtolevelone = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("0") || p.StructureID.StartsWith("9")) && p.ParentStructureID == null).ToList();
                    strcdtoleveltwo = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("0") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 6).ToList();
                    strcdtolecelthree = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("0") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 9).ToList();

                    break;
                case 2:
                    strcdtolevelone = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("1") || p.StructureID.StartsWith("9")) && p.ParentStructureID == null).ToList();
                    strcdtoleveltwo = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("1") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 6).ToList();
                    strcdtolecelthree = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("1") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 9).ToList();
                    break;
            }
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
                    var three = strcdtolecelthree.Where(g => g.ParentStructureID == t.StructureID);
                    if (three.Count() == 0)
                    {
                        AuthorityListModel alm = new AuthorityListModel();
                        result.Add(alm);
                        alm.LevelOne = p;
                        alm.LevelTWO = t;
                        alm.IsChecked = false;
                        if (pp.ApplyUserAuthority.Where(x => x.StructureID == t.StructureID).FirstOrDefault() != null)
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
        /// <summary>
        /// 获取模板权限（角色）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRoleAuthorityInfo(int? roleid)
        {
            List<AuthorityListModel> result = new List<AuthorityListModel>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            var pp = ApplyUserProvider.GetRole(roleid);

            List<StructureDTO> strcdtolevelone = null;
            List<StructureDTO> strcdtoleveltwo = null;
            List<StructureDTO> strcdtolecelthree = null;
            switch (user.UserType)
            {
                case 0:
                    strcdtolevelone = GlobalStaticData.StructureInfo.Where(p => p.ParentStructureID == null).ToList();
                    strcdtoleveltwo = GlobalStaticData.StructureInfo.Where(p => p.StructureID.Length < 7).ToList();
                    strcdtolecelthree = GlobalStaticData.StructureInfo.Where(p => p.StructureID.Length == 9).ToList();
                    break;
                case 1:
                    strcdtolevelone = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("0") || p.StructureID.StartsWith("9")) && p.ParentStructureID == null).ToList();
                    strcdtoleveltwo = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("0") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 6).ToList();
                    strcdtolecelthree = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("0") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 9).ToList();

                    break;
                case 2:
                    strcdtolevelone = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("1") || p.StructureID.StartsWith("9")) && p.ParentStructureID == null).ToList();
                    strcdtoleveltwo = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("1") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 6).ToList();
                    strcdtolecelthree = GlobalStaticData.StructureInfo.Where(p => (p.StructureID.StartsWith("1") || p.StructureID.StartsWith("9")) && p.StructureID.Length == 9).ToList();
                    break;
            }
            foreach (var p in strcdtolevelone)
            {
                var tow = strcdtoleveltwo.Where(g => g.ParentStructureID == p.StructureID);
                if (tow.Count() == 0)
                {
                    AuthorityListModel alm = new AuthorityListModel();
                    result.Add(alm);
                    alm.LevelOne = p;
                    if (pp.RoleAuthority.Where(x => x.StructureID == p.StructureID).FirstOrDefault() != null)
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
                    var three = strcdtolecelthree.Where(g => g.ParentStructureID == t.StructureID);
                    if (three.Count() == 0)
                    {
                        AuthorityListModel alm = new AuthorityListModel();
                        result.Add(alm);
                        alm.LevelOne = p;
                        alm.LevelTWO = t;
                        alm.IsChecked = false;
                        if (pp.RoleAuthority.Where(x => x.StructureID == t.StructureID).FirstOrDefault() != null)
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
                        if (pp.RoleAuthority.Where(x => x.StructureID == w.StructureID).FirstOrDefault() != null)
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
        //导入
        /// <summary>
        /// 用户信息导入，17/08/01 derry
        /// </summary>
        /// <returns></returns>
        public ActionResult User_InfoFile()
        {
            string strErrorPath = null;
            HttpFileCollectionBase httfiles = Request.Files;
            if (httfiles.Count > 0)
            {
                HttpPostedFileBase httpfile = httfiles[1];
                try
                {
                    List<string[]> arrstrmapplst = new List<string[]>
                     {
                     new string[]{"申请用户名称","UserApplyName"},
                     new string[]{"申请手机号","UserPhone"},
                     new string[]{"申请邮箱","UserEmail"},
                     new string[]{"经销商","DistriButorIDStr"},
                     new string[]{"模板名称","UserModule"},
                     new string[]{"检测情况","CheckInfo"}
                     };
                    string strGenarateDir = Server.MapPath(@"~/TempFile");
                    string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
                    string strExportFile = strGenarateDir + "\\" + strGenarateFile;
                    List<ExcelUserApply> rplst = ExcelHelper.Import<ExcelUserApply>(httpfile.InputStream, "Sheet1", arrstrmapplst, CheckUserApplyInfo, strExportFile);

                    if (rplst == null)
                    {
                        strErrorPath = strGenarateFile;
                    }
                    else
                    {
                        //上传附件
                        HttpPostedFileBase httpfile0 = httfiles[0];
                        Guid Batch = Guid.NewGuid();
                        string FilePath = null;
                        string extName = Path.GetExtension(httpfile0.FileName); // 文件扩展名
                        var arrfilename = httpfile0.FileName.Split('\\');
                        var name = arrfilename[arrfilename.Length - 1].Replace(extName, "");

                        string strSaveDir = this.Server.MapPath("~/Attachments");
                        IsExists(strSaveDir);
                        FilePath = strSaveDir + "\\" + Batch.ToString() + extName;
                        httpfile0.SaveAs(FilePath);

                        List<AttachFileOperateDTO> dtolist = new List<AttachFileOperateDTO>() 
                        {
                            new AttachFileOperateDTO(){ 
                                AttachFileID = Guid.NewGuid(),
                                AttachFileExtentionName = extName, 
                                AttachFileName = Batch.ToString(),
                                AttachFileSrcName = name,
                                BelongModule = 2,
                                BelongModulePrimaryKey = Batch.ToString()
                            }
                        };

                        ApplyUserProvider.AddAttachFileList(dtolist);

                        ExcelBatch d = new ExcelBatch();
                        d.BatchID = Batch;
                        d.BatchName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        d.ApplyUserEamil = ((UserLoginDTO)Session["UserLoginInfo"]).Email;
                        d.ApplyUserPhone = ((UserLoginDTO)Session["UserLoginInfo"]).PhoneNumber;
                        d.Status = 1;
                        d.AuditStatus = 3;
                        d.ApplyUser = ((UserLoginDTO)Session["UserLoginInfo"]).FullName;
                        d.ExcelUserApply = rplst;
                        var boolD = ApplyUserProvider.ImportUserApplyData(new List<ExcelBatch>() { d });
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
        /// <summary>
        /// 导入验证
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool CheckUserApplyInfo(object obj)
        {
            string strimporter = ((UserLoginDTO)Session["UserLoginInfo"]).FullName;
            string UserType = ((UserLoginDTO)Session["UserLoginInfo"]).UserType.ToString();
            List<ExcelUserApply> exceldto = (List<ExcelUserApply>)obj;
            //取得经销商IDList
            DistributorSearchDTO disdto = new DistributorSearchDTO();
            disdto.page = 1;
            disdto.rows = 10;
            var DisList = DistributorProvider.GetDistributorList(disdto);
            //取得模块IDlist
            RoleSearchDTO dto = new RoleSearchDTO();
            var AllRole = UserAuthorityProvider.GetRoleList(dto);

            bool result = true;
            foreach (var p in exceldto)
            {
                StringBuilder sb = new StringBuilder();

                if (string.IsNullOrEmpty(p.UserApplyName))
                {
                    sb.Append("用户名不可为空");
                }
                if (string.IsNullOrEmpty(p.UserEmail))
                {
                    sb.Append("用户邮箱不可为空");
                }
                if (string.IsNullOrEmpty(p.UserPhone))
                {
                    sb.Append("用户手机号不可为空");
                }
                if (string.IsNullOrEmpty(p.DistriButorIDStr))
                {
                    sb.Append("经销商不可为空");
                }
                else
                {
                    var DisidList = DisList.Object.Where(m => m.DistributorName == p.DistriButorIDStr).Select(m => m.DistributorID).FirstOrDefault();
                    if (DisidList != null)
                    {
                        p.DistriButorIDStr = DisidList.ToString();
                    }
                    else
                    {
                        sb.Append("经销商信息不存在！");
                    }
                }

                if (string.IsNullOrEmpty(p.UserModule))
                {
                    sb.Append("用户模块不可为空");
                }
                else
                {
                    p.userapplyAut = new List<UserApplyAut>();
                    p.Userroleidstr = ",";
                    foreach (var r in p.UserModuleList)
                    {
                        var exist = AllRole.Where(m => m.RoleName == r).FirstOrDefault();
                        if (exist == null)
                        {
                            sb.Append("模块为" + r + "d不存在！");
                        }
                        else
                        {
                            p.Userroleidstr += exist.RoleID + ",";
                            p.userapplyAut.AddRange(exist.RoleAuthority.Select(s => new UserApplyAut { StructureID = s.StructureID, ButtonAuthority = s.RoleButtonAuthority }).ToList());
                        }
                    }
                    p.userapplyAut = p.userapplyAut.Distinct().ToList();
                }
                p.UserApplyType = UserType;
                p.AuditStatus = 3;

                if (sb.Length > 0)
                {
                    result = false;
                    p.CheckInfo = sb.ToString();
                }
                p.Importer = strimporter;
            }
            return result;

        }
        public FileContentResult DownloadUserApply(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("用户批次申请" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
    }

}