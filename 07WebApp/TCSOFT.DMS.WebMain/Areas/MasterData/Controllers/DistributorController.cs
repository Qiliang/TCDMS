using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Controllers
{
    using DMS.MasterData.DTO;
    using DMS.MasterData.DTO.Distributor.Distributor;
    using DMS.MasterData.DTO.Distributor.DistributorAnnounceAuthority;
    using DMS.MasterData.DTO.Distributor.DistributorAuthority;
    using DMS.MasterData.DTO.Distributor.DistributorServiceType;
    using DMS.MasterData.DTO.Distributor.DistributorType;
    using DMS.WebMain.Areas.MasterData.Models.Model.Distributor;
    using DMS.WebMain.Areas.MasterData.Models.Provider;
    using DMS.WebMain.Filter;
    using DMS.WebMain.Models.Model;
    using DMS.MasterData.DTO.Product.ProductLine;
    using DMS.WebMain.Areas.MasterData.Models.Model.Product;
    using System.IO;
    using TCSOFT.DMS.MasterData.DTO.Product.OKCPriceInfo;
    using TCSOFT.DMS.WebMain.Common;
    using TCSOFT.DMS.MasterData.DTO.Area;
    using TCSOFT.DMS.MasterData.DTO.Distributor.DistributorPriceAuthority;
    using TCSOFT.DMS.MasterData.DTO.ImportExcel;
    using System.Text;
    using TCSOFT.DMS.MasterData.DTO.Payment;
    using TCSOFT.DMS.MasterData.DTO.Transport;
    public class DistributorController : BaseController
    {
        // GET: MasterData/Distributor
        [AuthorityFilter(AuthorityID = "095004001")]
        public ActionResult DistributorType()
        {
            ViewBag.CrruentAuthority = GetAuthority("095004001");
            return View();
        }
        [AuthorityFilter(AuthorityID = "095004002")]
        public ActionResult DistributorServiceType()
        {
            ViewBag.CrruentAuthority = GetAuthority("095004002");
            return View();
        }
        [AuthorityFilter(AuthorityID = "095004004")]
        public ActionResult DistributorManagement()
        {
            ViewBag.CrruentAuthority = GetAuthority("095004004");
            return View();
        }
        public ActionResult DistributorChangeName()
        {
            return View();
        }
        [AuthorityFilter(AuthorityID = "095004005")]
        public ActionResult DistributorAuthority()
        {
            ViewBag.CrruentAuthority = GetAuthority("095004005");
            return View();
        }
        [AuthorityFilter(AuthorityID = "095004006")]
        public ActionResult DistributorAnnouncementAuthority()
        {
            ViewBag.CrruentAuthority = GetAuthority("095004006");
            return View();
        }
        [AuthorityFilter(AuthorityID = "095004007")]
        public ActionResult DistributorPriceAuthority()
        {
            ViewBag.CrruentAuthority = GetAuthority("095004007");
            return View();
        }
        #region 经销商管理
        /// <summary>
        /// 得到所有经销商信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDistributorList(DistributorSearchDTO dto)
        {
            ResultData<List<DistributorModel>> result = null;
            string strSaveDir = this.Server.MapPath("~/Attachments");
            IsExists(strSaveDir);
            result = DistributorProvider.GetDistributorList(dto, strSaveDir);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条经销商信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetOneDistributor(DistributorSearchDTO dto)
        {
            ResultData<DistributorModel> result = new ResultData<DistributorModel>();
            dto.page = 1;
            dto.rows = 1;
            try
            {
                result = DistributorProvider.GetOneDistributor(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 经销商新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddDistributor(DistributorOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.DistributorID = Guid.NewGuid();
            dto.IsActive = true;
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            try
            {
                result = DistributorProvider.AddDistributor(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 经销商修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateDistributor(DistributorOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.UpType = 1;
            try
            {
                result = DistributorProvider.UpdateDistributor(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 经销商删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteDistributor(DistributorOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;

            try
            {
                result = DistributorProvider.DeleteDistributor(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 停启用经销商
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult StartOrStopDistributor(DistributorOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.UpType = 2;
            try
            {
                if (dto.IsActive == true)
                {
                    dto.NoActiveTime = null;
                }
                else
                {
                    dto.NoActiveTime = DateTime.Now;
                }
                result = DistributorProvider.StartOrStopDistributor(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 经销商更名
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ChangeNameDistributor(DistributorChangeNameModel dto)
        {
            ResultData<object> result = new ResultData<object>();

            try
            {
                result = DistributorProvider.ChangeNameDistributor(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 导出经销商信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportDistributor(DistributorSearchDTO dto)
        {
            string result = null;

            List<DistributorModel> pp = null;
            dto.page = 1;
            dto.rows = 10000000;
            pp = DistributorProvider.GetDistributorList(dto).Object;

            string strTemplateFile = Server.MapPath(@"~/TempLate/DistributorTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            pp.ForEach(g =>
            {
                Models.Model.Excel.ExcelDistributor er = new Models.Model.Excel.ExcelDistributor();
                er.状态 = g.IsActivestr;
                er.经销商编号 = g.DistributorCode;
                er.经销商名称 = g.DistributorName;
                er.经销商类别 = g.DistributorTypeName;
                er.经销商服务类型 = g.DistributorServiceTypeName;
                er.注册省份 = g.RegionName;
                er.发票地址编号 = g.InvoiceCode;
                er.送货地址编号 = g.DeliverCode;
                er.CSR用户名试剂 = g.CSRNameReagent;
                er.CSR用户名维修D部 = g.CSRNameD;
                er.CSR用户名维修B部 = g.CSRNameB;
                er.办事处 = g.Office;
                er.停用时间 = g.NoActiveTime == null ? string.Empty : g.NoActiveTime.Value.ToString("yyyy-MM-dd");

                ratelist.Add(er);
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        public FileContentResult DownloadDistributor(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("经销商信息" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
        //导入
        public ActionResult ImportDistributor()
        {
            string strErrorPath = null;

            HttpFileCollectionBase httfiles = Request.Files;
            if (httfiles.Count > 0)
            {
                HttpPostedFileBase httpfile = httfiles[0];
                try
                {
                    List<string[]> arrstrmapplst = new List<string[]> { 
                        new string[]{"状态","IsActiveStr"},
                        new string[]{"经销商编号","DistributorCode"},
                        new string[]{"经销商名称","DistributorName"},
                        new string[]{"经销商类别","DistributorTypeName"},
                        new string[]{"经销商服务类型","DistributorServiceTypeName"},
                        new string[]{"注册省份","RegionName"},
                        new string[]{"发票地址编号","InvoiceCode"},
                        new string[]{"送货地址编号","DeliverCode"},
                        new string[]{"CSR用户名(试剂)","CSRNameReagent"},
                        new string[]{"CSR用户名(维修D部)","CSRNameD"},
                        new string[]{"CSR用户名(维修B部) ","CSRNameB"},
                        new string[]{"办事处","Office"},
                        new string[]{"检测情况","CheckInfo"}
                    };
                    string strGenarateDir = Server.MapPath(@"~/TempFile");
                    string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
                    string strExportFile = strGenarateDir + "\\" + strGenarateFile;
                    List<ExcelDistributorDTO> rplst = ExcelHelper.Import<ExcelDistributorDTO>(httpfile.InputStream, "Sheet1", arrstrmapplst, CheckDistributorInfo, strExportFile);
                    if (rplst == null)
                    {
                        strErrorPath = strGenarateFile;
                    }
                    else
                    {
                        var boolD = DistributorProvider.ImportDistributor(rplst);
                        if (!boolD.SubmitResult)
                        {
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
        private bool CheckDistributorInfo(object obj)
        {
            DistributorSearchDTO dto = new DistributorSearchDTO();
            dto.page = 1;
            dto.rows = 1000000000;
            var distributorlist = DistributorProvider.GetDistributorList(dto);//所有经销商
            DistributorTypeSearchDTO typesearchDTO = new DistributorTypeSearchDTO();
            var distributortypelist = DistributorProvider.GetDistributorTypeList(typesearchDTO);
            DistributorServiceTypeSearchDTO servicesearchDTO = new DistributorServiceTypeSearchDTO();
            var distributorservicetypelist = DistributorProvider.GetDistributorServiceTypeList(servicesearchDTO);
            var ProvinceRegionList = AreaRegionProvider.GetProvinceRegionList();
            string strimporter = ((UserLoginDTO)Session["UserLoginInfo"]).FullName;

            List<ExcelDistributorDTO> exceldto = (List<ExcelDistributorDTO>)obj;
            bool result = true;

            foreach (var p in exceldto)
            {

                StringBuilder sb = new StringBuilder();

                if (String.IsNullOrEmpty(p.IsActiveStr))
                {
                    sb.Append("状态不可为空!");
                }
                if (String.IsNullOrEmpty(p.DistributorCode))
                {
                    sb.Append("经销商编号不可为空!");
                }

                if (string.IsNullOrEmpty(p.DistributorName))
                {
                    sb.Append("经销商名称不可为空!");
                }
                else
                {
                    var exist = distributorlist.Object.Where(m => m.DistributorName == p.DistributorName).FirstOrDefault();
                    if (exist != null)
                    {
                        p.DistributorID = exist.DistributorID;
                        p.UpLogic = 2;
                    }
                    else
                    {
                        p.UpLogic = 1;
                    }
                }
                if (string.IsNullOrEmpty(p.DistributorTypeName))
                {
                    sb.Append("经销商类别不可为空!");
                }
                else
                {
                    var exist = distributortypelist.Where(m => m.DistributorTypeName == p.DistributorTypeName).FirstOrDefault();
                    if (exist != null)
                    {
                        p.DistributorTypeID = exist.DistributorTypeID;
                    }
                    else
                    {
                        sb.Append("经销商类别不存在!");
                    }

                }
                if (string.IsNullOrEmpty(p.DistributorServiceTypeName))
                {
                    sb.Append("经销商服务类型不可为空!");
                }
                else
                {
                    var exist = distributorservicetypelist.Where(m => m.DistributorServiceTypeName == p.DistributorServiceTypeName).FirstOrDefault();
                    if (exist != null)
                    {
                        p.DistributorServiceTypeID = exist.DistributorServiceTypeID;
                    }
                    else
                    {
                        sb.Append("经销商服务类型不存在!");
                    }

                }
                if (string.IsNullOrEmpty(p.RegionName))
                {
                    sb.Append("注册省份不可为空!");
                }
                else
                {
                    var exist = ProvinceRegionList.Where(m => m.RegionName == p.RegionName).FirstOrDefault();
                    if (exist != null)
                    {
                        p.RegionID = exist.RegionID;
                    }
                    else
                    {
                        sb.Append("注册省份不存在!");
                    }
                }
                if (string.IsNullOrEmpty(p.InvoiceCode))
                {
                    sb.Append("发票地址编号不可为空!");
                }
                if (string.IsNullOrEmpty(p.DeliverCode))
                {
                    sb.Append("送货地址编号不可为空!");
                }
                p.Importer = strimporter;
                if (sb.Length > 0)
                {
                    result = false;
                    p.CheckInfo = sb.ToString();
                }
            }

            return result;
        }


        #region 附件
        /// <summary>
        /// 上次附件
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UploadAttachments(Guid? DistributorID)
        {
            ResultData<object> result = new ResultData<object>();

            try
            {
                HttpPostedFileBase Filedata = Request.Files[0];

                string FilePath = null;
                string extName = Path.GetExtension(Filedata.FileName); // 文件扩展名
                var arrfilename = Filedata.FileName.Split('\\');

                string strSaveDir = this.Server.MapPath("~/Attachments");
                IsExists(strSaveDir);
                FilePath = strSaveDir + "\\" + DistributorID.Value.ToString("N") + extName;
                Filedata.SaveAs(FilePath);
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
        public ActionResult DownloadAttachments(Guid? DistributorID)
        {
            string strSaveDir = this.Server.MapPath("~/Attachments");
            string File = string.Empty;
            byte[] FileByte = null;
            foreach (string file in System.IO.Directory.GetFiles(strSaveDir, DistributorID.Value.ToString("N") + ".*", System.IO.SearchOption.AllDirectories))
            {
                File = file;
            }

            string Extension = Path.GetExtension(File);
            using (FileStream fsRead = new FileStream(File, FileMode.Open))
            {
                int fsLen = (int)fsRead.Length;
                byte[] heByte = new byte[fsLen];
                int r = fsRead.Read(heByte, 0, heByte.Length);
                FileByte = heByte;

                fsRead.Flush();
            }
            FileResult FCR = new FileContentResult(FileByte, Extension);
            FCR.FileDownloadName = DistributorID + Extension;

            return FCR;
        }
        private void IsExists(string strSaveDir)
        {
            if (!System.IO.Directory.Exists(strSaveDir))
            {
                System.IO.Directory.CreateDirectory(strSaveDir);
            }
        }
        #endregion
        #endregion

        #region 经销商类别
        /// <summary>
        /// 得到所有经销商类别
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDistributorTypeList(DistributorTypeSearchDTO dto)
        {
            List<DistributorTypeResultDTO> result = null;

            result = DistributorProvider.GetDistributorTypeList(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到所有经销商类别(查询使用带请选择)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetSearchDistributorTypeList(DistributorTypeSearchDTO dto)
        {
            List<DistributorTypeResultDTO> result = null;

            result = DistributorProvider.GetDistributorTypeList(dto);

            result.Insert(0, new DistributorTypeResultDTO { DistributorTypeID = -1, DistributorTypeName = "请选择" });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条经销商类别信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetDistributorType(DistributorTypeSearchDTO dto)
        {
            ResultData<DistributorTypeResultDTO> result = new ResultData<DistributorTypeResultDTO>();

            try
            {
                result = DistributorProvider.GetDistributorType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 经销商类别新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddDistributorType(DistributorTypeOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            try
            {
                result = DistributorProvider.AddDistributorType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 经销商类别修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateDistributorType(DistributorTypeOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            try
            {
                result = DistributorProvider.UpdateDistributorType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 经销商类别删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteDistributorType(DistributorTypeOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            try
            {
                result = DistributorProvider.DeleteDistributorType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 经销商服务类型
        /// <summary>
        /// 得到所有经销商服务类型
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDistributorServiceTypeList(DistributorServiceTypeSearchDTO dto)
        {
            List<DistributorServiceTypeResultDTO> result = null;

            result = DistributorProvider.GetDistributorServiceTypeList(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到所有经销商类别(查询使用带请选择)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetSearchDistributorServiceTypeList(DistributorServiceTypeSearchDTO dto)
        {
            List<DistributorServiceTypeResultDTO> result = null;

            result = DistributorProvider.GetDistributorServiceTypeList(dto);

            result.Insert(0, new DistributorServiceTypeResultDTO { DistributorServiceTypeID = -1, DistributorServiceTypeName = "请选择" });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条经销商服务类型信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetDistributorServiceType(DistributorServiceTypeSearchDTO dto)
        {
            ResultData<DistributorServiceTypeResultDTO> result = new ResultData<DistributorServiceTypeResultDTO>();

            try
            {
                result = DistributorProvider.GetDistributorServiceType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 经销商服务类型新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddDistributorServiceType(DistributorServiceTypeOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            try
            {
                result = DistributorProvider.AddDistributorServiceType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 经销商服务类型修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateDistributorServiceType(DistributorServiceTypeOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            try
            {
                result = DistributorProvider.UpdateDistributorServiceType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 经销商服务类型删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteDistributorServiceType(DistributorServiceTypeOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            try
            {
                result = DistributorProvider.DeleteDistributorServiceType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 经销商授权
        /// <summary>
        /// 得到所有经销商信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDistributor(DistributorSearchDTO dto)
        {
            ResultData<List<DistributorModel>> result = null;

            result = DistributorProvider.GetDistributorList(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 经销商授权信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="ProductLineID"></param>
        /// <returns></returns>
        public ActionResult GetOneDistributorAuthority(DistributorAuthoritySearchDTO dto)
        {
            ResultData<DistributorAuthorityResultDTO> result = new ResultData<DistributorAuthorityResultDTO>();
            try
            {
                result.Object = DistributorProvider.GetOneDistributorAuthority(dto);
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
        /// 得到经销商授权付款条款
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDistributorAuthorityPay(DistributorAuthoritySearchDTO dto)
        {
            List<DistributorPaymentResultDTO> result = null;

            result = DistributorProvider.GetDistributorAuthorityPay(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到经销商授权运输方式
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDistributorAuthorityTransport(DistributorAuthoritySearchDTO dto)
        {
            List<DistributorTransportResultDTO> result = null;

            result = DistributorProvider.GetDistributorAuthorityTransport(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到经销商授权产品线
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDistributorAuthorityProductLine(DistributorAuthoritySearchDTO dto)
        {
            ResultData<List<DistributorProductLineResultDTO>> result = null;

            result = DistributorProvider.GetDistributorAuthorityProductLine(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到经销商授权产品线区域
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDistributorAuthorityRegion(DistributorAuthoritySearchDTO dto)
        {
            ResultData<List<DistributorRegionResultDTO>> result = null;

            result = DistributorProvider.GetDistributorAuthorityRegion(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 大小区显示/小区省份显示
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetArea(AreaSearchDTO dto)
        {
            List<AreaResultDTO> result = null;

            result = DistributorProvider.GetArea(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 授权经销商付款条款
        /// </summary>
        /// <returns></returns>
        public ActionResult DistributorPayAuthority(DistributorAuthorityModel dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            dto.AddType = 1;
            try
            {
                result = DistributorProvider.DistributorPayAuthority(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 授权经销商运输方式
        /// </summary>
        /// <returns></returns>
        public ActionResult DistributorTransportAuthority(DistributorAuthorityModel dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            dto.AddType = 2;
            try
            {
                result = DistributorProvider.DistributorTransportAuthority(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 授权经销商产品线
        /// </summary>
        /// <returns></returns>
        public ActionResult DistributorProductLineAuthority(DistributorAuthorityModel dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            dto.AddType = 3;
            try
            {
                result = DistributorProvider.DistributorProductLineAuthority(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 授权经销商授权产品线区域
        /// </summary>
        /// <returns></returns>
        public ActionResult DistributorProductLineRegionAuthority(DistributorAuthorityModel dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            dto.AddType = 4;
            try
            {
                result = DistributorProvider.DistributorProductLineRegionAuthority(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改经销商订货权限
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdataDistributorAuthority(DistributorAuthorityOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.UpType = 1;
            try
            {
                result = DistributorProvider.UpdataDistributorAuthority(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除经销商付款条款
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteDistributorPayAuthority(DistributorAuthorityModel dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.DelType = 1;
            try
            {
                result = DistributorProvider.DeleteDistributorAuthority(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除经销商运输方式
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteDistributorTransportAuthority(DistributorAuthorityModel dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.DelType = 2;
            try
            {
                result = DistributorProvider.DeleteDistributorAuthority(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除经销商产品线
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteDistributorProductLineAuthority(DistributorAuthorityModel dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.DelType = 3;
            try
            {
                result = DistributorProvider.DeleteDistributorAuthority(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除经销商授权产品线区域
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteDistributorProductLineRegionAuthority(DistributorAuthorityModel dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.DelType = 4;
            try
            {
                result = DistributorProvider.DeleteDistributorAuthority(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 导出经销商授权
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportDistributorAuthority(DistributorSearchDTO dto)
        {
            string result = null;

            dto.page = 1;
            dto.rows = 10000000;
            var pp = DistributorProvider.GetDistributorList(dto).Object;
            DistributorAuthoritySearchDTO sdto = new DistributorAuthoritySearchDTO();
            var aa = DistributorProvider.GetDistributorAuthorityPay(sdto);
            var ss = DistributorProvider.GetDistributorAuthorityTransport(sdto);
            sdto.page = 1;
            sdto.rows = 10000000;
            var dd = DistributorProvider.GetDistributorAuthorityProductLine(sdto).Object;
            var ff = DistributorProvider.GetDistributorAuthorityRegion(sdto).Object;

            string strTemplateFile = Server.MapPath(@"~/TempLate/DistributorAuthorityTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            pp.ForEach(g =>
            {
                var a = aa.Where(p => p.DistributorID == g.DistributorID).ToList();
                var s = ss.Where(p => p.DistributorID == g.DistributorID).ToList(); ;
                var d = dd.Where(p => p.DistributorID == g.DistributorID).ToList(); ;
                Models.Model.Excel.ExcelDistributorAuthority er = new Models.Model.Excel.ExcelDistributorAuthority();
                er.经销商名称 = g.DistributorName;
                a.ForEach(pf =>
                {
                    er.付款条款 += pf.PayName + ",";
                });
                d.ForEach(prof =>
                {
                    er.部门 += prof.DepartName + ",";
                    er.产品线 += prof.ProductLineName + ",";
                    var f = ff.Where(p => p.DistributorProductLineID == prof.DistributorProductLineID).ToList();
                    f.ForEach(rf =>
                    {
                        er.负责区域 += GlobalStaticData.RegionList.Where(p => p.RegionID == rf.RegionID).Select(se => se.RegionName).FirstOrDefault() + ",";
                    });
                });
                er.订货权限 = g.IsOrderGoods == true ? "是" : "";
                ratelist.Add(er);
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        public FileContentResult DownloadDistributorAuthority(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("经销商授权" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
        //导入
        public ActionResult ImportDistributorAuthority()
        {
            string strErrorPath = null;

            HttpFileCollectionBase httfiles = Request.Files;
            if (httfiles.Count > 0)
            {
                HttpPostedFileBase httpfile = httfiles[0];
                try
                {
                    List<string[]> arrstrmapplst = new List<string[]> { 
                        new string[]{"经销商名称","DistributorName"},
                        new string[]{"产品线","ProductLineNamestr"},
                        new string[]{"负责区域","RegionNamestr"},
                        new string[]{"付款条款","PayNamestr"},
                        new string[]{"运输方式","TransportNamestr"},
                        new string[]{"订货权限","IsOrderGoodsstr"},
                        new string[]{"检测情况","CheckInfo"}
                    };
                    string strGenarateDir = Server.MapPath(@"~/TempFile");
                    string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
                    string strExportFile = strGenarateDir + "\\" + strGenarateFile;
                    List<ExcelDistributorAuthorityDTO> rplst = ExcelHelper.Import<ExcelDistributorAuthorityDTO>(httpfile.InputStream, "Sheet1", arrstrmapplst, CheckDistrAuthInfo, strExportFile);
                    if (rplst == null)
                    {
                        strErrorPath = strGenarateFile;
                    }
                    else
                    {
                        var boolD = DistributorProvider.ImportDistributorAuthority(rplst);
                        if (!boolD.SubmitResult)
                        {
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

        private bool CheckDistrAuthInfo(object obj)
        {
            bool result = true;
            DistributorAuthoritySearchDTO dto = new DistributorAuthoritySearchDTO();
            string strimporter = ((UserLoginDTO)Session["UserLoginInfo"]).FullName;
            dto.page = 1;
            dto.rows = 10;
            var DistrAuth = DistributorProvider.GetDistributorAuthority(dto);
            //取得付款条款所有
            PaymentSearchDTO dtopay = new PaymentSearchDTO();
            var DisPay = BaseInfoProvider.GetPaymentList(dtopay);
            //取得产品线所有
            ProductLineSearchDTO dtoLine = new ProductLineSearchDTO();
            var DisLine = ProductManagementProvider.GetProductLine(dtoLine);
            //取得所有运输方式
            TransportSearchDTO dtoTran = new TransportSearchDTO();
            var DisTran = BaseInfoProvider.GetTransportList(dtoTran);
            //取得区域

            List<ExcelDistributorAuthorityDTO> excelDisAuth = (List<ExcelDistributorAuthorityDTO>)obj;
            foreach (var p in excelDisAuth)
            {
                StringBuilder sb = new StringBuilder();
                if (string.IsNullOrEmpty(p.DistributorName))
                {


                }
                else
                {
                    var DistrAuthNmae = DistrAuth.Where(m => m.DistributorName == p.DistributorName).Select(m => m.DistributorName).FirstOrDefault();
                    if (DistrAuthNmae != null)
                    {
                        p.DistributorName = DistrAuthNmae;
                    }
                    else
                    {
                        sb.Append("经销商名称不存在！ ");
                    }
                }
                //经销商多选List判断有无此数据。
                if (string.IsNullOrEmpty(p.PayNamestr))
                {

                }
                else
                {
                    foreach (var pay in p.PayNamelist)
                    {
                        var exist = DisPay.Where(m => m.PayName == pay).FirstOrDefault();
                        if (exist == null)
                        {
                            sb.Append("付款条款为 " + pay + " 的数据，不存在！");
                        }
                        else
                        {

                        }
                    }
                }
                if (string.IsNullOrEmpty(p.ProductLineNamestr))
                {

                }
                else
                {
                    foreach (var line in p.ProductLineNamelist)
                    {
                        var exist = DisLine.Where(m => m.ProductLineName == line).FirstOrDefault();
                        if (exist == null)
                        {
                            sb.Append("产品线为 " + line + " 的数据，不存在！");
                        }
                        else
                        {

                        }
                    }
                }
                if (string.IsNullOrEmpty(p.TransportNamestr))
                {

                }
                else
                {
                    foreach (var Tran in p.TransportNamelist)
                    {
                        var exist = DisTran.Where(m => m.TransportName == Tran).FirstOrDefault();
                        if (exist == null)
                        {
                            sb.Append("运输方式为 " + Tran + " 的数据，不存在！");
                        }
                        else
                        {

                        }
                    }
                }
                if (string.IsNullOrEmpty(p.IsOrderGoodsstr))
                {

                }
                else if (p.IsOrderGoodsstr.Trim() == "是")
                {

                }
                else if (p.IsOrderGoodsstr.Trim() == "否")
                {

                }
                else
                {
                    sb.Append("请填写正确的订货权限，‘是’或者‘否’或者为空，您填写的订货权限‘" + p.IsOrderGoodsstr + "’无效！");
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

        #region 经销商公告授权
        /// <summary>
        /// 得到经销商公告授权
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetDistributorAnnounceAuthorityList(DistributorAnnounceAuthoritySearchDTO dto)
        {
            ResultData<List<DistributorAnnounceAuthorityModel>> result = new ResultData<List<DistributorAnnounceAuthorityModel>>();

            result = DistributorProvider.GetDistributorAnnounceAuthorityList(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增经销商公告授权
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddDistributorAnnounceAuthority(DistributorAnnounceAuthorityOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            try
            {
                result = DistributorProvider.AddDistributorAnnounceAuthority(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到所有产品线信息用于经销商公告授权
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetProductLineDis(ProductLineSearchDTO dto, List<int> plineID)
        {
            List<ProductLineResultModel> result = null;

            result = ProductManagementProvider.GetProductLine(dto);
            if (plineID != null) 
            {
                foreach (var i in result) 
                {
                    var ss = plineID.Where(w => w == i.ProductLineID).FirstOrDefault();
                    if (ss != 0)
                    {
                        i.Ischeck = true;
                    }
                    else 
                    {
                        i.Ischeck = false;
                    }
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 导出经销商公告授权
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportDistributorADAuthority(DistributorAnnounceAuthoritySearchDTO dto)
        {
            string result = null;
            dto.page = 1;
            dto.rows = 10000000;
            List<DistributorAnnounceAuthorityModel> pp = null;
            pp = DistributorProvider.GetDistributorAnnounceAuthorityList(dto).Object;

            string strTemplateFile = Server.MapPath(@"~/TempLate/DistributorADAuthorityTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            pp.ForEach(g =>
            {
                Models.Model.Excel.ExcelDistributorADAuthority er = new Models.Model.Excel.ExcelDistributorADAuthority();
                er.经销商名称 = g.DistributorName;
                er.经销商类别 = g.DistributorTypeName;
                er.经销商服务类型 = g.DistributorServiceTypeName;
                er.注册省份 = g.RegionName;
                er.产品线 = g.ProductLineNames;
                ratelist.Add(er);
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        public FileContentResult DownloadDistributorADAuthority(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("经销商公告授权" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
        public ActionResult ImportDistributorADAuthority()
        {
            string strErrorPath = null;

            HttpFileCollectionBase httfiles = Request.Files;
            if (httfiles.Count > 0)
            {
                HttpPostedFileBase httpfile = httfiles[0];
                try
                {
                    List<string[]> arrstrmapplst = new List<string[]> { 
                        new string[]{"经销商名称","DistributorName"},
                        new string[]{"经销商类别","DistributorTypeName"},
                        new string[]{"经销商服务类型","DistributorServiceTypeName"},
                        new string[]{"注册省份","RegionName"},
                        new string[]{"产品线","ProductLineName"},
                        new string[]{"检测情况","CheckInfo"}
                    };
                    string strGenarateDir = Server.MapPath(@"~/TempFile");
                    string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
                    string strExportFile = strGenarateDir + "\\" + strGenarateFile;
                    List<ExcelDistributorADAuthorityDTO> rplst = ExcelHelper.Import<ExcelDistributorADAuthorityDTO>(httpfile.InputStream, "Sheet1", arrstrmapplst, CheckDisAnnAuthlInfo, strExportFile);
                    if (rplst == null)
                    {
                        strErrorPath = strGenarateFile;

                    }
                    else
                    {
                        var boolD = DistributorProvider.ImportDistributorAnnounceAuthority(rplst);
                        if (!boolD.SubmitResult)
                        {
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
        private bool CheckDisAnnAuthlInfo(object obj)
        {
            string strimporter = ((UserLoginDTO)Session["UserLoginInfo"]).FullName;
            bool result = true;
            DistributorAnnounceAuthoritySearchDTO dto = new DistributorAnnounceAuthoritySearchDTO();
            dto.page = 1;
            dto.rows = 10;
            var DisAnnAuth = DistributorProvider.GetDistributorAnnounceAuthorityList(dto);
            List<ExcelDistributorADAuthorityDTO> exceldto = (List<ExcelDistributorADAuthorityDTO>)obj;
            //取得所有经销商类别
            DistributorTypeSearchDTO dsiType = new DistributorTypeSearchDTO();
            var DisType = DistributorProvider.GetDistributorTypeList(dsiType);
            //取得所有经销商服务类型
            DistributorServiceTypeSearchDTO disserv = new DistributorServiceTypeSearchDTO();
            var DisSer = DistributorProvider.GetDistributorServiceTypeList(disserv);
            //取得所有经销商名称
            DistributorSearchDTO dis = new DistributorSearchDTO();
            dis.rows = 100000000;
            dis.page = 1;
            var DisName = DistributorProvider.GetDistributorList(dis);
            //取得产品线所有
            ProductLineSearchDTO dtoLine = new ProductLineSearchDTO();
            var DisLine = ProductManagementProvider.GetProductLine(dtoLine);
            //取得经销商公告授权所有
            DistributorAnnounceAuthoritySearchDTO DisLineOne = new DistributorAnnounceAuthoritySearchDTO();
            var GetDisLineOne = DistributorProvider.GetDistributorAnnounceAuthorityList(DisLineOne);

            foreach (var p in exceldto)
            {
                p.ProductLineIDList = new List<int>();
                StringBuilder sb = new StringBuilder();
                if (string.IsNullOrEmpty(p.DistributorName))
                {
                    sb.Append("经销商名称不可为空！ ");
                }
                else
                {
                    var Disq = DisName.Object.Where(m => m.DistributorName == p.DistributorName).FirstOrDefault();
                    if (Disq == null)
                    {
                        sb.Append("经销商名称为 " + p.DistributorName + " 的数据，不存在！");
                    }
                    else
                    {
                        p.DistributorID = Disq.DistributorID;
                    }
                }
                if (string.IsNullOrEmpty(p.DistributorTypeName))
                {
                    sb.Append("经销商类别名称不可为空！ ");
                }
                else
                {

                    var exist = DisType.Where(m => m.DistributorTypeName == p.DistributorTypeName).FirstOrDefault();
                    if (exist == null)
                    {
                        sb.Append("经销商类别名称为 " + p.DistributorTypeName + " 的数据，不存在！");
                    }
                    else
                    {

                    }

                }
                if (string.IsNullOrEmpty(p.DistributorServiceTypeName))
                {
                    sb.Append("经销商服务类型名称不可为空！ ");
                }
                else
                {

                    var exist = DisSer.Where(m => m.DistributorServiceTypeName == p.DistributorServiceTypeName).FirstOrDefault();
                    if (exist == null)
                    {
                        sb.Append("经销商服务类型名称为 " + p.DistributorServiceTypeName + " 的数据，不存在！");
                    }
                    else
                    {

                    }

                }
                if (string.IsNullOrEmpty(p.ProductLineName))
                {
                    sb.Append("产品线不可为空！ ");
                }
                else
                {
                    foreach (var line in p.ProductLineNameList)
                    {
                        var exist = DisLine.Where(m => m.ProductLineName == line).FirstOrDefault();
                        if (exist == null)
                        {
                            sb.Append("产品线为 " + line + " 的数据，不存在！");
                        }
                        else
                        {
                            p.ProductLineIDList.Add(exist.ProductLineID);
                        }
                    }
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

        #region 经销商价格授权
        /// <summary>
        /// 得到经销商信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetIsActiveDistributorList(DistributorSearchDTO dto)
        {
            ResultData<List<DistributorResultDTO>> result = null;

            result = ProductManagementProvider.GetDistributorList(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 查询经销商的OKC信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDistributorOKC(DistributorPriceAuthoritySearchDTO dto)
        {
            ResultData<List<DistributorOKCProduct>> result = null;

            result = DistributorProvider.GetDisOKCList(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增经销商OKC
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddOKCDepAndCus(OKCPriceInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            dto.AddType = 3;
            try
            {
                result = ProductManagementProvider.AddOKC(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 查询经销商的OKC信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetOKCList(OKCPriceInfoSearchDTO dto)
        {
            ResultData<List<OKCPriceInfoResultDTO>> result = null;
            dto.page = 1;
            dto.rows = 10000000;
            result = ProductManagementProvider.GetOKCList(dto);

            return Json(result.Object, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}