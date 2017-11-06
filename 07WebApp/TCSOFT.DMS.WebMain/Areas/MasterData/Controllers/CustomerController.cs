using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TCSOFT.DMS.MasterData.DTO;
using TCSOFT.DMS.MasterData.DTO.Area;
using TCSOFT.DMS.MasterData.DTO.Customer;
using TCSOFT.DMS.MasterData.DTO.CustomerAudit;
using TCSOFT.DMS.MasterData.DTO.ImportExcel;
using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model;
using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider;
using TCSOFT.DMS.WebMain.Common;
using TCSOFT.DMS.WebMain.Filter;
using TCSOFT.DMS.WebMain.Models.Model;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: MasterData/Customer
        [AuthorityFilter(AuthorityID = "095005001")]
        public ActionResult Customer()
        {
            ViewBag.CrruentAuthority = GetAuthority("095005001");

            return View();
        }
        [AuthorityFilter(AuthorityID = "095005002")]
        public ActionResult CustomerAudit()
        {
            ViewBag.CrruentAuthority = GetAuthority("095005002");

            return View();
        }
        #region 客户信息
        /// <summary>
        /// 得到客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetCustomerList(CustomerSearchDTO dto)
        {
            ResultData<List<CustomerInfoModel>> result = new ResultData<List<CustomerInfoModel>>();

            result = CustomerProvider.GetCustomerList(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到相似客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetSimilarCustomerList(CustomerSearchDTO dto)
        {
            dto.QueryType = 1;
            ResultData<List<CustomerInfoModel>> result = new ResultData<List<CustomerInfoModel>>();

            result = CustomerProvider.GetCustomerList(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条客户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetCustomer(CustomerSearchDTO dto)
        {
            dto.page = 1;
            dto.rows=10;
            ResultData<CustomerInfoModel> result = new ResultData<CustomerInfoModel>();

            try
            {
                result = CustomerProvider.GetCustomer(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddCustomer(CustomerOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CustomerID = Guid.NewGuid();
            dto.IsActive = true;
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            try
            {
                result = CustomerProvider.AddCustomer(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateCustomer(CustomerOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.UpType = 1;
            try
            {
                result = CustomerProvider.UpdateCustomer(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteCustomer(CustomerOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            try
            {
                result = CustomerProvider.DeleteCustomer(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 停启用客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ChangeStatusCustomer(CustomerOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.NoActiveTime = DateTime.Now;
            dto.UpType = 2;
            try
            {
                result = CustomerProvider.ChangeStatusCustomer(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 导出客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportCustomer(CustomerSearchDTO dto)
        {
            dto.page = 1;
            dto.rows = 10000000;
            string result = null;

            List<CustomerInfoModel> pp = null;
            pp = CustomerProvider.GetCustomerList(dto).Object;

            string strTemplateFile = Server.MapPath(@"~/TempLate/CustomerInfoTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            pp.ForEach(g =>
            {
                Models.Model.Excel.ExcelCustomerInfo er = new Models.Model.Excel.ExcelCustomerInfo();
                er.状态 = g.Status;
                er.省份 = g.Province;
                er.城市 = g.City;
                er.新增时间 = g.CreateTime.HasValue ? g.CreateTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
                er.Oracle号 = g.OracleNO;
                er.OracleName = g.OracleName;
                er.经销商提交客户名称 = g.CustomerName;
                er.携手网编号 = g.XSWNO;
                er.经销商名称 = g.DistributorName;
                er.审批人 = g.Auditor;
                er.最后修改人 = g.ModifyUser;
                ratelist.Add(er);
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        public FileContentResult DownloadCustomer(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("客户信息" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
        public ActionResult ImportCustomer()
        {
            string strErrorPath = null;
            HttpFileCollectionBase httfiles = Request.Files;
            if (httfiles.Count > 0)
            {
                HttpPostedFileBase httpfile = httfiles[0];
                try
                {
                    List<string[]> arrstrmapplst = new List<string[]> { 
                        new string[]{"省份","Province"},
                        new string[]{"城市","City"},
                        new string[]{"客户类型","CustomerType"},
                        new string[]{"Oracle号","OracleNO"},
                        new string[]{"Oracle Name","OracleName"},
                        new string[]{"经销商提交客户名称","CustomerName"},
                        new string[]{"携手网编号","XSWNO"},
                        new string[]{"经销商名称","DistributorName"},
                        new string[]{"检测情况","CheckInfo"}
                    };
                    string strGenarateDir = Server.MapPath(@"~/TempFile");
                    string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
                    string strExportFile = strGenarateDir + "\\" + strGenarateFile;
                    List<ExcelCustomerInfoDTO> rplst = ExcelHelper.Import<ExcelCustomerInfoDTO>(httpfile.InputStream, "Sheet1", arrstrmapplst, CheckCustomer, strExportFile);
                    if (rplst == null)
                    {
                        strErrorPath = strGenarateFile;
                    }
                    else
                    {
                        var boolD = CustomerProvider.ImportCustomer(rplst);
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
        private bool CheckCustomer(object obj)
        {
            bool result = true;
            CustomerSearchDTO dto = new CustomerSearchDTO();
            dto.rows = 100000000;
            string strimporter = ((UserLoginDTO)Session["UserLoginInfo"]).FullName;
            dto.page=1;
            var CustomerList = CustomerProvider.GetCustomerList(dto);
            var ProvinceRegionList = AreaRegionProvider.GetProvinceRegionList();
            List<ExcelCustomerInfoDTO> exceldto = (List<ExcelCustomerInfoDTO>)obj;
            foreach (var p in exceldto)
            {
                StringBuilder sb = new StringBuilder();
                if (String.IsNullOrEmpty(p.CustomerName))
                {
                    sb.Append("客户名称不能为空");
                }
                else
                {
                    var CustomerID = CustomerList.Object.Where(m => m.CustomerName == p.CustomerName).Select(m => m.CustomerID).FirstOrDefault();
                    if (CustomerID != null)
                    {
                        p.CustomerID = CustomerID;
                        p.UpLogic = 2;
                    }
                    else
                    {
                        p.UpLogic = 1;
                    }
                }
                if (string.IsNullOrEmpty(p.XSWNO))
                {
                    sb.Append("携手网编号不可为空！");
                }
                if (string.IsNullOrEmpty(p.Province))
                {
                    sb.Append("省份不能为空！");
                }
                else
                {
                    var exist = ProvinceRegionList.Where(m => m.RegionName == p.Province).FirstOrDefault();
                    if (exist != null)
                    {
                        p.Province = exist.RegionName;
                    }
                    else
                    {
                        sb.Append("注册省份不存在!");
                    }
                }
                if (string.IsNullOrEmpty(p.City))
                {
                    sb.Append("城市不能为空！");
                }
                else
                {
                    var nextArea = GlobalStaticData.RegionList.Where(m => m.RegionName == p.City).FirstOrDefault();
                    if (nextArea == null)
                    {
                        sb.Append("注册城市" + p.City + "不存在!");
                    }
                    else
                    { 
                    
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

        #region 客户审核
        /// <summary>
        /// 得到客户审核信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetCustomerAuditList(CustomerAuditSearchDTO dto)
        {
            dto.Status = 0;
            ResultData<List<CustomerAuditModel>> result = new ResultData<List<CustomerAuditModel>>();

            result = CustomerProvider.GetCustomerAuditList(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 客户审核成功
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult CustomerAuditSuccess(CustomerAuditOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.Auditor = user.FullName;
            dto.AuditTime = DateTime.Now;
            dto.Status = 2;
            
            try
            {
                result = CustomerProvider.CustomerAuditSuccess(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 客户审核失败
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult CustomerAuditFail(CustomerAuditOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.Auditor = user.FullName;
            dto.AuditTime = DateTime.Now;
            dto.Status = 1;

            try
            {
                result = CustomerProvider.CustomerAuditSuccess(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}