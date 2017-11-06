using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Controllers
{
    using DMS.MasterData.DTO;
    using DMS.MasterData.DTO.AccountDate;
    using DMS.MasterData.DTO.RateDTO;
    using DMS.WebMain.Areas.MasterData.Models.Provider;
    using DMS.WebMain.Models.Model;
    using System.Text;
    using TCSOFT.DMS.MasterData.DTO.ImportExcel;
    using TCSOFT.DMS.MasterData.DTO.Payment;
    using TCSOFT.DMS.MasterData.DTO.Transport;
    using TCSOFT.DMS.WebMain.Common;
    using WebMain.Filter;
    public class BaseInfoController : BaseController
    {
        // GET: MasterData/BaseInfo
        [AuthorityFilter(AuthorityID = "095002003")]
        public ActionResult Payment()
        {
            ViewBag.CrruentAuthority = GetAuthority("095002003");

            return View();
        }
        [AuthorityFilter(AuthorityID = "095002002")]
        public ActionResult Transportation()
        {
            ViewBag.CrruentAuthority = GetAuthority("095002002");

            return View();
        }
        [AuthorityFilter(AuthorityID = "095002004")]
        public ActionResult ClosingDate()
        {
            ViewBag.CrruentAuthority = GetAuthority("095002004");

            return View();
        }
        [AuthorityFilter(AuthorityID = "095002001")]
        public ActionResult Rate()
        {
            ViewBag.CrruentAuthority = GetAuthority("095002001");

            return View();
        }
        #region 汇率管理
        /// <summary>
        /// 得到所有汇率信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetRateList()
        {
            List<RateResultDTO> result = null;

            result = BaseInfoProvider.GetRateList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条汇率信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetOneRate(int id)
        {
            ResultData<RateResultDTO> result = new ResultData<RateResultDTO>();

            try
            {
                result.Object = BaseInfoProvider.GetOneRate(id);
                result.SubmitResult = true;
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增汇率信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddRate(RateOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            try
            {
                dto.CreateUser = user.FullName;
                dto.CreateTime = DateTime.Now;
                result.SubmitResult = BaseInfoProvider.AddRate(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改汇率信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateRate(RateOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            try
            {
                dto.ModifyUser = user.FullName;
                dto.ModifyTime = DateTime.Now;
                result.SubmitResult = BaseInfoProvider.UpdateRate(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 导出汇率
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportRate(List<RateResultDTO> dto)
        {
            string result = null;

            string strTemplateFile = Server.MapPath(@"~/TempLate/RateTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            if (dto != null && dto.Count > 0)
            {
                dto.ForEach(g =>
                {
                    Models.Model.ExcelRate er = new Models.Model.ExcelRate();
                    er.汇率编码 = g.RateCode;
                    er.更新时间 = g.ModifyTimeDesc;
                    er.预算汇率 = g.RateBudget != null ? g.RateBudget.Value.ToString() : string.Empty;
                    er.货币 = g.Currency;
                    er.年份 = g.RateYear;
                    er.一月 = g.MonthRate != null ? g.MonthRate.Value.ToString() : string.Empty;
                    er.二月 = g.FebRate != null ? g.FebRate.Value.ToString() : string.Empty;
                    er.三月 = g.MarchRate != null ? g.MarchRate.Value.ToString() : string.Empty;
                    er.四月 = g.AprilRate != null ? g.AprilRate.Value.ToString() : string.Empty;
                    er.五月 = g.MayRate != null ? g.MayRate.Value.ToString() : string.Empty;
                    er.六月 = g.JuneRate != null ? g.JuneRate.Value.ToString() : string.Empty;
                    er.七月 = g.JulyRate != null ? g.JulyRate.Value.ToString() : string.Empty;
                    er.八月 = g.AugustRate != null ? g.AugustRate.Value.ToString() : string.Empty;
                    er.九月 = g.SepRate != null ? g.SepRate.Value.ToString() : string.Empty;
                    er.十月 = g.OctRate != null ? g.OctRate.Value.ToString() : string.Empty;
                    er.十一月 = g.NovRate != null ? g.NovRate.Value.ToString() : string.Empty;
                    er.十二月 = g.DecRate != null ? g.DecRate.Value.ToString() : string.Empty;
                    ratelist.Add(er);
                });
            }
            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }

        public FileContentResult DownloadRate(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("汇率信息" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }

        #endregion

        #region 运输方式
        /// <summary>
        /// 得到所有运输方式信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetTransportList(TransportSearchDTO dto)
        {
            List<TransportResultDTO> result = null;

            result = BaseInfoProvider.GetTransportList(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条运输方式信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetTransport(int id)
        {
            ResultData<TransportResultDTO> result = new ResultData<TransportResultDTO>();

            try
            {
                result = BaseInfoProvider.GetTransport(id);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增运输方式信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddTransport(TransportOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            try
            {
                dto.TransportStatus = true;
                dto.CreateUser = user.FullName;
                dto.CreateTime = DateTime.Now;
                result = BaseInfoProvider.AddTransport(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改运输方式信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateTransport(TransportOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            try
            {
                dto.ModifyUser = user.FullName;
                dto.ModifyTime = DateTime.Now;
                result = BaseInfoProvider.UpdateTransport(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 付款条款
        /// <summary>
        /// 查询付款条款信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetPaymentList(PaymentSearchDTO dto)
        {
            List<PaymentResultDTO> result = null;

            result = BaseInfoProvider.GetPaymentList(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条付款条款信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetPayment(int id)
        {
            ResultData<PaymentResultDTO> result = new ResultData<PaymentResultDTO>();

            try
            {
                result = BaseInfoProvider.GetPayment(id);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增付款条款信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddPayment(PaymentOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            try
            {
                dto.CreateUser = user.FullName;
                dto.CreateTime = DateTime.Now;
                result = BaseInfoProvider.AddPayment(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改付款条款信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdatePayment(PaymentOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            try
            {
                dto.UpType = 1;
                dto.ModifyUser = user.FullName;
                dto.ModifyTime = DateTime.Now;
                result = BaseInfoProvider.UpdatePayment(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除付款条款信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeletePayment(PaymentSearchDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            try
            {
                result = BaseInfoProvider.DeletePayment(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 停启用付款条款信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ChangeStatus(PaymentOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            try
            {
                dto.UpType = 2;
                dto.ModifyUser = user.FullName;
                dto.ModifyTime = DateTime.Now;
                result = BaseInfoProvider.UpdatePayment(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 导出付款条款
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportPayment(PaymentSearchDTO dto)
        {
            string result = null;

            List<PaymentResultDTO> pp = null;
            pp = BaseInfoProvider.GetPaymentList(dto);

            string strTemplateFile = Server.MapPath(@"~/TempLate/PaymentTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            pp.ForEach(g =>
            {
                Models.Model.Excel.ExcelPayment er = new Models.Model.Excel.ExcelPayment();
                er.状态 = g.PayStatusStr;
                er.付款条款 = g.PayName;
                er.OracleName = g.OracleName;
                er.开始日期 = g.PayStartTime.HasValue ? g.PayStartTime.Value.ToString("yyyy-MM-dd") : null;
                er.结束日期 = g.PayEndTime.HasValue ? g.PayEndTime.Value.ToString("yyyy-MM-dd") : null;
                ratelist.Add(er);
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        public FileContentResult DownloadPayment(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("付款条款" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
        #endregion

        #region 关账日
        /// <summary>
        /// 得到所有关账日信息信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetAccountDateList()
        {
            List<AccountDateResultDTO> result = null;

            result = BaseInfoProvider.GetAccountDateList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条关账日信息信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetOneAccountDate(int id)
        {
            ResultData<AccountDateResultDTO> result = new ResultData<AccountDateResultDTO>();

            try
            {
                result.Object = BaseInfoProvider.GetOneAccountDate(id);
                result.SubmitResult = true;
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增关账日信息信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddAccountDate(AccountDateOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            try
            {
                dto.CreateUser = user.FullName;
                dto.CreateTime = DateTime.Now;
                result = BaseInfoProvider.AddAccountDate(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改关账日信息信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateAccountDate(AccountDateOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];

            try
            {
                dto.ModifyUser = user.FullName;
                dto.ModifyTime = DateTime.Now;
                result = BaseInfoProvider.UpdateAccountDate(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 取得模块信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetModule()
        {
            List<StructureDTO> result = null;

            result = GlobalStaticData.StructureInfo.Where(p => p.ParentStructureID == null).ToList();
            result.Insert(0, new StructureDTO { StructureName = "全部" });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 取得所有模块信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetAllModule()
        {
            List<StructureDTO> result = null;

            result = GlobalStaticData.StructureInfo.Where(p => p.ParentStructureID == null).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 取得搜索框模块信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetSearchModule()
        {
            List<StructureDTO> result = null;

            result = GlobalStaticData.StructureInfo.Where(p => p.ParentStructureID == null).ToList();
            result.Insert(0, new StructureDTO { StructureName = "请选择" });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ImportAccountDate()
        {
            bool result = false;

            return Json(result);
        }
        /// <summary>
        /// 导出关账日信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportAccountDate()
        {
            string result = null;

            List<AccountDateResultDTO> pp = null;
            pp = BaseInfoProvider.GetAccountDateList();

            string strTemplateFile = Server.MapPath(@"~/TempLate/AccountDateTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            pp.ForEach(g =>
            {
                Models.Model.Excel.ExcelAccountDate er = new Models.Model.Excel.ExcelAccountDate();
                er.关帐日名称 = g.AccountDateName;
                er.年份 = g.AccountDateYear;
                er.送货地址 = g.AccountDatePlace;
                er.一月 = g.MonthDate == null ? string.Empty : g.MonthDate.Value.ToString("yyyy-MM-dd");
                er.二月 = g.FebDate == null ? string.Empty : g.FebDate.Value.ToString("yyyy-MM-dd");
                er.三月 = g.MarchDate == null ? string.Empty : g.MarchDate.Value.ToString("yyyy-MM-dd");
                er.四月 = g.AprilDate == null ? string.Empty : g.AprilDate.Value.ToString("yyyy-MM-dd");
                er.五月 = g.MayDate == null ? string.Empty : g.MayDate.Value.ToString("yyyy-MM-dd");
                er.六月 = g.JuneDate == null ? string.Empty : g.JuneDate.Value.ToString("yyyy-MM-dd");
                er.七月 = g.JulyDate == null ? string.Empty : g.JulyDate.Value.ToString("yyyy-MM-dd");
                er.八月 = g.AugustDate == null ? string.Empty : g.AugustDate.Value.ToString("yyyy-MM-dd");
                er.九月 = g.SepDate == null ? string.Empty : g.SepDate.Value.ToString("yyyy-MM-dd");
                er.十月 = g.OctDate == null ? string.Empty : g.OctDate.Value.ToString("yyyy-MM-dd");
                er.十一月 = g.NovDate == null ? string.Empty : g.NovDate.Value.ToString("yyyy-MM-dd");
                er.十二月 = g.DecDate == null ? string.Empty : g.DecDate.Value.ToString("yyyy-MM-dd");
                er.所属模块 = g.AccountDateBelongModel;

                ratelist.Add(er);
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        /// <summary>
        /// 关帐日导入，17/06/08  戴锐
        /// </summary>
        /// <returns></returns>
        public ActionResult CloseDataFile()
        {
            string strErrorPath = null;
            HttpFileCollectionBase httfiles = Request.Files;
            if (httfiles.Count > 0)
            {
                HttpPostedFileBase httpfile = httfiles[0];
                try
                {
                    List<string[]> arrstrmapplst = new List<string[]>
                    {
                        new string[]{"关账日名称","AccountDateName"},
                        new string[]{"年份","AccountDateYear"},
                        new string[]{"送货地址","AccountDatePlace"},
                        new string[]{"所属模块","AccountDateBelongModelstr"},
                        new string[]{"一月","MonthDate"},
                        new string[]{"二月","FebDate"},
                        new string[]{"三月","MarchDate"},
                        new string[]{"四月","AprilDate"},
                        new string[]{"五月","MayDate"},
                        new string[]{"六月","JuneDate"},
                        new string[]{"七月","JulyDate"},
                        new string[]{"八月","AugustDate"},
                        new string[]{"九月","SepDate"},
                        new string[]{"十月","OctDate"},
                        new string[]{"十一月","NovDate"},
                        new string[]{"十二月","DecDate"},
                        new string[]{"检测情况","CheckInfo"}
                    };
                    string strGenarateDir = Server.MapPath(@"~/TempFile");
                    string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
                    string strExportFile = strGenarateDir + "\\" + strGenarateFile;
                    List<ExclCloseDataDTO> rplst = ExcelHelper.Import<ExclCloseDataDTO>(httpfile.InputStream, "Sheet1", arrstrmapplst, CheckCloseDataInfo, strExportFile);
                    if (rplst == null)
                    {
                        strErrorPath = strGenarateFile;
                    }
                    else
                    {
                        var boolD = BaseInfoProvider.ImportColseData(rplst);
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

        private bool CheckCloseDataInfo(object obj)
        {
            string strimporter = ((UserLoginDTO)Session["UserLoginInfo"]).FullName;
            List<ExclCloseDataDTO> exceldto = (List<ExclCloseDataDTO>)obj;
            List<string> AccountDatePlaceList = new List<string> { "BCCE", "BCHK", "BCIT" };
            List<string> AccountDateBelongModelstr = null;
            AccountDateBelongModelstr = GlobalStaticData.StructureInfo.Where(p => p.ParentStructureID == null).Select(m => m.StructureName).ToList();
            AccountDateBelongModelstr.Insert(0, "全部");
            bool result = true;

            foreach (var p in exceldto)
            {
                StringBuilder sb = new StringBuilder();

                if (String.IsNullOrEmpty(p.AccountDateName)) // 检测名称
                {
                    sb.Append("关账日名称不可为空！");
                }

                if (String.IsNullOrEmpty(p.AccountDateYear)) // 检测年份
                {
                    sb.Append("年份不可为空！");
                }
                else if (Convert.ToInt32(p.AccountDateYear) > 2028 && Convert.ToInt32(p.AccountDateYear) < 2000)
                {
                    sb.Append("请填写正确的年份，年份为2000年~2028年");
                }

                if (String.IsNullOrEmpty(p.AccountDatePlace)) // 检测送货地址
                {
                    sb.Append("送货地址不可为空！");
                }
                else
                {
                    if (!AccountDatePlaceList.Contains(p.AccountDatePlace))
                    {
                        sb.Append("送货地址不存在！");
                    }
                }
                if (String.IsNullOrEmpty(p.AccountDateBelongModelstr)) // 检测模块
                {
                    sb.Append("模块不可为空！");
                }
                else
                {
                    if (!AccountDateBelongModelstr.Contains(p.AccountDateBelongModelstr))
                    {
                        sb.Append("模块不存在！");
                    }
                }
                p.Importer = strimporter;
                //判断1~12月数据是否正确在Dto层判断，如果填写的不正确的日期格式，填写的那条数据则会强制转换为空。
                if (sb.Length > 0)
                {
                    result = false;
                    p.CheckInfo = sb.ToString();
                }
            }

            return result;
        }

        public FileContentResult DownloadAccountDate(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("关账日" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
        #endregion
    }
}