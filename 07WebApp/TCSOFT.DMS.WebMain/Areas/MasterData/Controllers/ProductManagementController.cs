using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Controllers
{
    using Common;
    using TCSOFT.DMS.MasterData.DTO;
    using TCSOFT.DMS.MasterData.DTO.ImportExcel;
    using TCSOFT.DMS.MasterData.DTO.Customer;
    using TCSOFT.DMS.MasterData.DTO.Distributor.Distributor;
    using TCSOFT.DMS.MasterData.DTO.Product.InstrumentType;
    using TCSOFT.DMS.MasterData.DTO.Product.OKCPriceInfo;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductInfo;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductLine;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductModel;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductPriceInfo;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductSmallType;
    using TCSOFT.DMS.MasterData.DTO.Product.ProductType;
    using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model;
    using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Product;
    using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider;
    using TCSOFT.DMS.WebMain.Models.Model;
    using WebMain.Filter;
    using System.Text;
    public class ProductManagementController : BaseController
    {
        // GET: MasterData/ProductManagement
        [AuthorityFilter(AuthorityID = "095003005")]
        public ActionResult ProductType()
        {
            ViewBag.CrruentAuthority = GetAuthority("095003005");

            return View();
        }
        [AuthorityFilter(AuthorityID = "095003002")]
        public ActionResult InstrumentType()
        {
            ViewBag.CrruentAuthority = GetAuthority("095003002");

            return View();
        }
        [AuthorityFilter(AuthorityID = "095003003")]
        public ActionResult InstrumentModel()
        {
            ViewBag.CrruentAuthority = GetAuthority("095003003");

            return View();
        }
        [AuthorityFilter(AuthorityID = "095003001")]
        public ActionResult ProductLine()
        {
            ViewBag.CrruentAuthority = GetAuthority("095003001");

            return View();
        }
        [AuthorityFilter(AuthorityID = "095003004")]
        public ActionResult ProductSmallclass()
        {
            ViewBag.CrruentAuthority = GetAuthority("095003004");

            return View();
        }
        [AuthorityFilter(AuthorityID = "095003006")]
        public ActionResult ReagentProductList()
        {
            ViewBag.CrruentAuthority = GetAuthority("095003006");

            return View();
        }
        [AuthorityFilter(AuthorityID = "095003007")]
        public ActionResult RepairProductList()
        {
            ViewBag.CrruentAuthority = GetAuthority("095003007");

            return View();
        }
        [AuthorityFilter(AuthorityID = "095003008")]
        public ActionResult ReagentProductPrice()
        {
            ViewBag.CrruentAuthority = GetAuthority("095003008");

            return View();
        }
        [AuthorityFilter(AuthorityID = "095003010")]
        public ActionResult RepairProductPrice()
        {
            ViewBag.CrruentAuthority = GetAuthority("095003010");

            return View();
        }
        [AuthorityFilter(AuthorityID = "095003009")]
        public ActionResult ProductSpecial()
        {
            ViewBag.CrruentAuthority = GetAuthority("095003009");

            return View();
        }

        #region 产品线
        /// <summary>
        /// 得到所有产品线信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetProductLine(ProductLineSearchDTO dto)
        {
            List<ProductLineResultModel> result = null;

            result = ProductManagementProvider.GetProductLine(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到所有产品线信息(查询使用带请选择)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetSearchProductLine(ProductLineSearchDTO dto)
        {
            List<ProductLineResultModel> result = null;

            result = ProductManagementProvider.GetProductLine(dto);

            result.Insert(0, new ProductLineResultModel { ProductLineID = -1, ProductLineName = "请选择" });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条产品线信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetOneProductLine(int id)
        {
            ResultData<ProductLineResultDTO> result = new ResultData<ProductLineResultDTO>();

            try
            {
                result = ProductManagementProvider.GetOneProductLine(id);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 产品线新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddProductLine(ProductLineOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.IsActive = true;
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            try
            {
                result = ProductManagementProvider.AddProductLine(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 产品线修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateProductLine(ProductLineOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.UpType = 1;
            try
            {
                result = ProductManagementProvider.UpdateProductLine(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 产品线删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteProductLine(ProductLineOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            try
            {
                result = ProductManagementProvider.DeleteProductLine(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 停启用产品线
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ChangeStatusProductLine(ProductLineOperateDTO dto)
        {

            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.IsActive = !dto.IsActive;
            dto.UpType = 2;
            try
            {
                result = ProductManagementProvider.UpdateProductLine(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 仪器类型
        /// <summary>
        /// 得到仪器类型
        /// </summary>
        /// <returns></returns>
        public ActionResult GetInstrumentTypeList()
        {
            List<InstrumentTypeResultDTO> result = null;

            result = ProductManagementProvider.GetInstrumentTypeList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条仪器类型
        /// </summary>
        /// <returns></returns>
        public ActionResult GetInstrumentType(int id)
        {
            ResultData<InstrumentTypeResultDTO> result = new ResultData<InstrumentTypeResultDTO>();

            try
            {
                result = ProductManagementProvider.GetInstrumentType(id);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增仪器类型
        /// </summary>
        /// <returns></returns>
        public ActionResult AddInstrumentType(InstrumentTypeOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            try
            {
                result = ProductManagementProvider.AddInstrumentType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改仪器类型
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateInstrumentType(InstrumentTypeOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            try
            {
                result = ProductManagementProvider.UpdateInstrumentType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除仪器类型
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteInstrumentType(InstrumentTypeSearchDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            try
            {
                result = ProductManagementProvider.DeleteInstrumentType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 产品型号(仪器型号)
        /// <summary>
        /// 得到所有产品型号信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetProductModel(ProductModelSearchDTO dto)
        {

            List<ProductModelResultModel> result = null;

            result = ProductManagementProvider.GetProductModel(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条产品型号信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetOneProductModel(int id)
        {
            ResultData<ProductModelResultModel> result = new ResultData<ProductModelResultModel>();

            try
            {
                result = ProductManagementProvider.GetOneProductModel(id);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 产品型号新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddProductModel(ProductModelOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.IsActive = true;
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            try
            {
                result = ProductManagementProvider.AddProductModel(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 产品型号修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateProductModel(ProductModelOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.UpType = 1;
            try
            {
                result = ProductManagementProvider.UpdateProductModel(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 产品型号删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteProductModel(ProductModelOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            try
            {
                result = ProductManagementProvider.DeleteProductModel(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 停启用产品型号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ChangeStatusProductModel(ProductModelOperateDTO dto)
        {

            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.IsActive = !dto.IsActive;
            dto.UpType = 2;
            try
            {
                result = ProductManagementProvider.UpdateProductModel(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 导出仪器型号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportProductModel(ProductModelSearchDTO dto)
        {
            string result = null;

            List<ProductModelResultModel> pp = null;
            pp = ProductManagementProvider.GetProductModel(dto);

            string strTemplateFile = Server.MapPath(@"~/TempLate/InstrumentModelTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            pp.ForEach(g =>
            {
                Models.Model.Excel.ExcelInstrumentModel er = new Models.Model.Excel.ExcelInstrumentModel();
                er.状态 = g.Status;
                er.仪器型号 = g.ProductModelName;
                er.产品线 = g.ProductLineName;
                ratelist.Add(er);
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        public FileContentResult DownloadProductModel(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("仪器型号" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
        public ActionResult ImportProductModel()
        {
            string strErrorPath = null;
            HttpFileCollectionBase httfiles = Request.Files;
            if (httfiles.Count > 0)
            {
                HttpPostedFileBase httpfile = httfiles[0];
                try
                {
                    List<string[]> arrstrmapplst = new List<string[]> { 
                        new string[]{"仪器型号","ProductModelName"},
                        new string[]{"产品线","ProductLineName"},
                        new string[]{"检测情况","CheckInfo"}
                    };
                    string strGenarateDir = Server.MapPath(@"~/TempFile");
                    string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
                    string strExportFile = strGenarateDir + "\\" + strGenarateFile;
                    List<ExcelInstrumentModelDTO> rplst = ExcelHelper.Import<ExcelInstrumentModelDTO>(httpfile.InputStream, "Sheet1", arrstrmapplst, CheckProductModelInfo, strExportFile);
                    if (rplst == null)
                    {
                        strErrorPath = strGenarateFile;
                    }
                    else
                    {
                        var boolD = ProductManagementProvider.ImportProductModel(rplst);
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
        private bool CheckProductModelInfo(object obj)
        {
            string strimporter = ((UserLoginDTO)Session["UserLoginInfo"]).FullName;
            var productlinelist = ProductManagementProvider.GetProductLineBaseInfo();//产品线
            ProductModelSearchDTO dto = new ProductModelSearchDTO();
            var productmodel = ProductManagementProvider.GetProductModel(dto);//仪器型号
            List<ExcelInstrumentModelDTO> exceldto = (List<ExcelInstrumentModelDTO>)obj;

            bool result = true;

            foreach (var p in exceldto)
            {
                StringBuilder sb = new StringBuilder();

                // 检测仪器型号不可为空
                if (String.IsNullOrEmpty(p.ProductModelName))
                {
                    sb.Append("检测仪器型号不可为空!");
                }
                // 检测产品线不可为空
                if (String.IsNullOrEmpty(p.ProductLineName))
                {
                    sb.Append("产品线不可为空!");
                }
                else
                {
                    // 检测产品线是否存在
                    var productlineid = productlinelist.Where(m => m.ProductLineName == p.ProductLineName).Select(m => m.ProductLineID).FirstOrDefault();
                    if (productlineid == null)
                    {
                        sb.Append("产品线不存在");
                    }
                    else
                    {
                        p.ProductLineID = productlineid;
                    }
                }

                //检查仪器型号+产品线唯一性
                var productmodelid = productmodel.Where(q => q.ProductLineID == p.ProductLineID && q.ProductModelName == p.ProductLineName).FirstOrDefault();
                if (productmodelid != null)
                {
                    sb.Append("数据库中已存在此条数据！");
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

        #endregion

        #region 产品小类
        /// <summary>
        /// 得到所有产品小类信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetProductSmallType(ProductSmallTypeSearchDTO dto)
        {
            List<ProductSmallTypeResultModel> result = null;

            result = ProductManagementProvider.GetProductSmallType(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条产品小类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetOneProductSmallType(int id)
        {
            ResultData<ProductSmallTypeResultModel> result = new ResultData<ProductSmallTypeResultModel>();

            try
            {
                result = ProductManagementProvider.GetOneProductSmallType(id);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 产品小类新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddProductSmallType(ProductSmallTypeOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.IsActive = true;
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            try
            {
                result = ProductManagementProvider.AddProductSmallType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 产品小类修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateProductSmallType(ProductSmallTypeOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.UpType = 1;
            try
            {
                result = ProductManagementProvider.UpdateProductSmallType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 产品小类删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteProductSmallType(ProductSmallTypeOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            try
            {
                result = ProductManagementProvider.DeleteProductSmallType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 停启用产品小类
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ChangeStatusProductSmallType(ProductSmallTypeOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.IsActive = !dto.IsActive;
            dto.UpType = 2;
            try
            {
                result = ProductManagementProvider.UpdateProductSmallType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 导出产品小类
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportProductSmallType(ProductSmallTypeSearchDTO dto)
        {
            string result = null;

            List<ProductSmallTypeResultModel> pp = null;
            pp = ProductManagementProvider.GetProductSmallType(dto);

            string strTemplateFile = Server.MapPath(@"~/TempLate/ProductSmallClassTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            pp.ForEach(g =>
            {
                Models.Model.Excel.ExcelProductSmallClass er = new Models.Model.Excel.ExcelProductSmallClass();
                er.状态 = g.Status;
                er.产品小类 = g.ProductSmallTypeName;
                er.产品线 = g.ProductLineName;
                ratelist.Add(er);
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        public FileContentResult DownloadProductSmallType(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("产品小类" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
        public ActionResult ImportProductSmallType()
        {
            string strErrorPath = null;
            HttpFileCollectionBase httfiles = Request.Files;
            if (httfiles.Count > 0)
            {
                HttpPostedFileBase httpfile = httfiles[0];
                try
                {
                    List<string[]> arrstrmapplst = new List<string[]> { 
                        new string[]{"产品小类","ProductSmallTypeName"},
                        new string[]{"产品线","ProductLineName"},
                        new string[]{"检测情况","CheckInfo"}

                    };
                    string strGenarateDir = Server.MapPath(@"~/TempFile");
                    string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
                    string strExportFile = strGenarateDir + "\\" + strGenarateFile;
                    List<ExcelProductSmallClassDTO> rplst = ExcelHelper.Import<ExcelProductSmallClassDTO>(httpfile.InputStream, "Sheet1", arrstrmapplst, CheckProductSmallTypeInfo, strExportFile);
                    if (rplst == null)
                    {
                        strErrorPath = strGenarateFile;
                    }
                    else
                    {
                        var boolD = ProductManagementProvider.ImportProductSmallType(rplst);
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
        private bool CheckProductSmallTypeInfo(object obj)
        {
            string strimporter = ((UserLoginDTO)Session["UserLoginInfo"]).FullName;
            var productlinelist = ProductManagementProvider.GetProductLineBaseInfo();//产品线
            ProductSmallTypeSearchDTO dto = new ProductSmallTypeSearchDTO();
            var productsmalltype = ProductManagementProvider.GetProductSmallType(dto);//产品小类
            List<ExcelProductSmallClassDTO> exceldto = (List<ExcelProductSmallClassDTO>)obj;
            bool result = true;

            foreach (var p in exceldto)
            {
                StringBuilder sb = new StringBuilder();
                // 产品小类不可为空
                if (String.IsNullOrEmpty(p.ProductSmallTypeName))
                {
                    sb.Append("产品小类不可为空!");
                }

                // 检测产品线不可为空
                if (String.IsNullOrEmpty(p.ProductLineName))
                {
                    sb.Append("产品线不可为空!");
                }
                else
                {
                    // 检测产品线是否存在
                    var productlineid = productlinelist.Where(m => m.ProductLineName == p.ProductLineName).Select(m => m.ProductLineID).FirstOrDefault();
                    if (productlineid == null)
                    {
                        sb.Append("产品线不存在");
                    }
                    else
                    {
                        p.ProductLineID = productlineid;
                    }
                }

                //检查产品小类+产品线唯一性
                var productmodelid = productsmalltype.Where(q => q.ProductLineID == p.ProductLineID && q.ProductSmallTypeName == p.ProductSmallTypeName).FirstOrDefault();
                if (productmodelid != null)
                {
                    sb.Append("数据库中已存在此条数据！");
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

        #endregion

        #region 产品类型
        /// <summary>
        /// 得到产品类型
        /// </summary>
        /// <returns></returns>
        public ActionResult GetProductTypeList(ProductTypeSearchDTO dto)
        {
            List<ProductTypeResultDTO> result = null;

            result = ProductManagementProvider.GetProductTypeList(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条产品类型
        /// </summary>
        /// <returns></returns>
        public ActionResult GetProductType(int id)
        {
            ResultData<ProductTypeResultDTO> result = new ResultData<ProductTypeResultDTO>();

            try
            {
                result = ProductManagementProvider.GetProductType(id);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增产品类型
        /// </summary>
        /// <returns></returns>
        public ActionResult AddProductType(ProductTypeOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            try
            {
                result = ProductManagementProvider.AddProductType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改产品类型
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateProductType(ProductTypeOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            try
            {
                result = ProductManagementProvider.UpdateProductType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet); ;
        }
        /// <summary>
        /// 删除产品类型
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteProductType(ProductTypeSearchDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            try
            {
                result = ProductManagementProvider.DeleteProductType(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 试剂产品清单
        /// <summary>
        /// 得到试剂产品清单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetReagentInfo(ProductInfoSearchDTO dto)
        {
            ResultData<List<ProductInfoModel>> result = null;

            result = ProductManagementProvider.GetReagentInfo(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条试剂产品清单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetOneReagentInfo(ProductInfoSearchDTO dto)
        {
            ResultData<ProductInfoModel> result = new ResultData<ProductInfoModel>();
            dto.page = 1;
            dto.rows = 1;
            try
            {
                result = ProductManagementProvider.GetOneReagentInfo(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 试剂产品新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddReagentInfo(ProductInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.IsActive = true;
            dto.IsMaintenance = false;
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            dto.ProductID = Guid.NewGuid();
            try
            {
                result = ProductManagementProvider.AddReagentInfo(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 试剂产品修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateReagentInfo(ProductInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.UpType = 1;
            try
            {
                result = ProductManagementProvider.UpdateReagentInfo(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 试剂产品删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteReagentInfo(ProductInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;

            try
            {
                result = ProductManagementProvider.DeleteReagentInfo(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 停启用试剂产品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult StartOrStopReagentInfo(ProductInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.UpType = 2;
            try
            {
                result = ProductManagementProvider.StartOrStopReagentInfo(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 导出试剂产品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportReagent(ProductInfoSearchDTO dto)
        {
            string result = null;

            List<ProductInfoModel> pp = null;
            dto.page = 1;
            dto.rows = 10000000;
            pp = ProductManagementProvider.GetReagentInfo(dto).Object;

            string strTemplateFile = Server.MapPath(@"~/TempLate/ReagentTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            pp.ForEach(g =>
            {
                Models.Model.Excel.ExcelReagent er = new Models.Model.Excel.ExcelReagent();
                er.状态 = g.IsActivestr;
                er.货号 = g.ArtNo;
                er.产品名称 = g.ProductName;
                er.规格 = g.ReagentSize;
                er.产品类型 = g.ProductTypeName;
                er.产品线 = g.ProductLineName;
                er.项目 = g.ReagentProject;
                er.测试数 = g.ReagentTest;
                er.描述 = g.RemarkDes;
                ratelist.Add(er);
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        public FileContentResult DownloadReagent(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("试剂产品" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }

        public ActionResult ImportReagentProduct()
        {
            string strErrorPath = null;

            HttpFileCollectionBase httfiles = Request.Files;
            if (httfiles.Count > 0)
            {
                HttpPostedFileBase httpfile = httfiles[0];
                try
                {
                    List<string[]> arrstrmapplst = new List<string[]> { 
                        new string[]{"货号","ArtNo"},
                        new string[]{"产品名称","ProductName"},
                        new string[]{"规格","ReagentSize"},
                        new string[]{"产品类型","ProductTypeName"},
                        new string[]{"产品线","ProductLineName"},
                        new string[]{"项目","ReagentProject"},
                        new string[]{"测试数","ReagentTest"},
                        new string[]{"描述","RemarkDes"},
                        new string[]{"检测情况","CheckInfo"}
                    };
                    string strGenarateDir = Server.MapPath(@"~/TempFile");
                    string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
                    string strExportFile = strGenarateDir + "\\" + strGenarateFile;
                    List<ExcelReagentProductDTO> rplst = ExcelHelper.Import<ExcelReagentProductDTO>(httpfile.InputStream, "Sheet1", arrstrmapplst, CheckReagentProductInfo, strExportFile);
                    if (rplst == null)
                    {
                        strErrorPath = strGenarateFile;
                    }
                    else
                    {
                        var boolD = ProductManagementProvider.ImportReagentProduct(rplst);
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
        private bool CheckReagentProductInfo(object obj)
        {
            var producttypelist = ProductManagementProvider.GetProductTypeBaseInfo();//产品类型 
            var productlinelist = ProductManagementProvider.GetProductLineBaseInfo();//产品线
            var productslist = ProductManagementProvider.GetProductBaseInfo();//所有产品
            List<ExcelReagentProductDTO> exceldto = (List<ExcelReagentProductDTO>)obj;
            string strimporter = ((UserLoginDTO)Session["UserLoginInfo"]).FullName;
            bool result = true;

            foreach (var p in exceldto)
            {

                StringBuilder sb = new StringBuilder();
                // 货号不可为空
                if (String.IsNullOrEmpty(p.ArtNo))
                {
                    sb.Append("货号不可为空!");
                }

                //检测产品名称
                if (string.IsNullOrEmpty(p.ProductName))
                {
                    sb.Append("产品名称不可为空!");
                }

                // 检测产品线不可为空
                if (String.IsNullOrEmpty(p.ProductLineName))
                {
                    sb.Append("产品线不可为空!");
                }
                else
                {
                    // 检测产品线是否存在
                    var productlineid = productlinelist.Where(m => m.ProductLineName == p.ProductLineName).Select(m => m.ProductLineID).FirstOrDefault();
                    if (productlineid == null)
                    {
                        sb.Append("产品线不存在");
                    }
                    else
                    {
                        p.ProductLineID = productlineid;
                    }
                }

                // 检测类型不可为空
                if (String.IsNullOrEmpty(p.ProductTypeName))
                {
                    sb.Append("产品类型不可为空!");
                }
                else
                {
                    // 检测产品类型是否存在
                    var producttypeid = producttypelist.Where(m => m.ProductTypeName == p.ProductTypeName).Select(m => m.ProductTypeID).FirstOrDefault();
                    if (producttypeid == null)
                    {
                        sb.Append("产品类型不存在!");
                    }
                    else
                    {
                        p.ProductTypeID = producttypeid;
                    }
                }
                if (string.IsNullOrEmpty(p.ReagentSize))
                {
                    sb.Append("规格不可为空!");
                }
                if (string.IsNullOrEmpty(p.ReagentProject))
                {
                    sb.Append("项目不可为空!");
                }
                if (string.IsNullOrEmpty(p.ReagentTest))
                {
                    sb.Append("项目数不可为空!");
                }
                if (p.ProductLineID != null && !string.IsNullOrEmpty(p.ArtNo))
                {
                    var exist = productslist.Where(m => m.IsMaintenance == false && m.ArtNo == p.ArtNo && m.ProductLineID == p.ProductLineID).FirstOrDefault();
                    if (exist != null)
                    {
                        p.ProductID = exist.ProductID;
                        p.UpLogic = 2;
                    }
                    else
                    {
                        p.UpLogic = 1;
                    }

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
        #endregion

        #region 试剂产品价格
        /// <summary>
        /// 得到试剂产品价格
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetReagentPriceList(ProductPriceInfoSearchDTO dto)
        {
            ResultData<List<ProductPriceModel>> result = null;

            result = ProductManagementProvider.GetReagentPriceList(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 试剂产品价格修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateReagentPrice(ProductPriceInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;

            try
            {
                result = ProductManagementProvider.UpdateReagentPrice(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 试剂产品价格删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteReagentPrice(ProductPriceInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();

            try
            {
                result = ProductManagementProvider.DeleteReagentPrice(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 导出试剂产品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportReagentPrice(ProductPriceInfoSearchDTO dto)
        {
            string result = null;

            List<ProductPriceModel> pp = null;
            dto.page = 1;
            dto.rows = 10000000;
            pp = ProductManagementProvider.GetReagentPriceList(dto).Object;

            string strTemplateFile = Server.MapPath(@"~/TempLate/ReagentPriceTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            pp.ForEach(g =>
            {
                Models.Model.Excel.ExcelReagentPrice er = new Models.Model.Excel.ExcelReagentPrice();
                er.状态 = g.DNPPriceEnd != null && g.DNPPriceEnd > DateTime.Now ? "启用" : "停用";
                er.货号 = g.ArtNo;
                er.产品名称 = g.ProductName;
                er.DNP价格不含税 = g.DNPPrice;
                er.起始日期 = g.DNPPriceStart != null ? g.DNPPriceStart.Value.ToString("yyyy-MM-dd") : null;
                er.结束日期 = g.DNPPriceEnd != null ? g.DNPPriceEnd.Value.ToString("yyyy-MM-dd") : null;
                ratelist.Add(er);
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        public FileContentResult DownloadReagentPrice(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("试剂产品价格" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
        /// <summary>
        /// 导入试剂产品价格
        /// </summary>
        /// <returns></returns>
        public ActionResult LeadReagentPrice()
        {
            string strErrorPath = null;
            HttpFileCollectionBase httfiles = Request.Files;
            if (httfiles.Count > 0)
            {
                HttpPostedFileBase httpfile = httfiles[0];
                try
                {
                    List<string[]> arrstrmapplst = new List<string[]> { 
                        new string[]{"货号","ArtNo"},
                        new string[]{"价格（不含税）","DNPPrice"},
                        new string[]{"起始日期","DNPPriceStart"},
                        new string[]{"结束日期","DNPPriceEnd"},
                        new string[]{"检测情况","CheckInfo"}
                    };
                    string strGenarateDir = Server.MapPath(@"~/TempFile");
                    string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
                    string strExportFile = strGenarateDir + "\\" + strGenarateFile;
                    List<ExcelReagentPriceDTO> rplst = ExcelHelper.Import<ExcelReagentPriceDTO>(httpfile.InputStream, "Sheet1", arrstrmapplst, CheckReagentPriceInfo, strExportFile);
                    if (rplst == null)
                    {
                        strErrorPath = strGenarateFile;
                    }
                    else
                    {
                        var boolD = ProductManagementProvider.ImportReagentPrice(rplst);
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
        private bool CheckReagentPriceInfo(object obj)
        {
            var productslist = ProductManagementProvider.GetProductBaseInfo();//所有产品
            List<ExcelReagentPriceDTO> exceldto = (List<ExcelReagentPriceDTO>)obj;
            string strimporter = ((UserLoginDTO)Session["UserLoginInfo"]).FullName;
            bool result = true;

            foreach (var p in exceldto)
            {

                StringBuilder sb = new StringBuilder();
                // 货号不可为空
                if (String.IsNullOrEmpty(p.ArtNo))
                {
                    sb.Append("货号不可为空!");
                }
                else
                {
                    var exist = productslist.Where(m => m.IsMaintenance == false && m.ArtNo == p.ArtNo).FirstOrDefault();
                    if (exist == null)
                    {
                        sb.Append("货号不存在!");
                    }
                    else
                    {
                        p.ProductID = exist.ProductID;
                    }
                }

                if (string.IsNullOrEmpty(p.DNPPrice))
                {
                    sb.Append("价格不可为空!");

                }
                else
                {
                    decimal i = 0;
                    if (!decimal.TryParse(p.DNPPrice, out i))
                    {
                        sb.Append("价格格式填写错误!");
                    }

                }
                if (string.IsNullOrEmpty(p.DNPPriceStart))
                {
                    sb.Append("开始时间不可为空!");
                }
                if (string.IsNullOrEmpty(p.DNPPriceEnd))
                {
                    sb.Append("结束时间不可为空!");
                }
                if (Convert.ToDateTime(p.DNPPriceEnd) < Convert.ToDateTime(p.DNPPriceStart))
                {
                    sb.Append("结束时间不可小于开始日期!");
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
        #endregion

        #region OKC价格（产品特价）
        /// <summary>
        /// 得到OKC协议
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetOKCList(OKCPriceInfoSearchDTO dto)
        {
            ResultData<List<OKCPriceInfoResultDTO>> result = null;

            result = ProductManagementProvider.GetOKCList(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条OKC信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetOneOKC(OKCPriceInfoSearchDTO dto)
        {
            ResultData<OKCPriceInfoResultDTO> result = new ResultData<OKCPriceInfoResultDTO>();
            dto.page = 1;
            dto.rows = 1;
            try
            {
                result = ProductManagementProvider.GetOneOKC(dto);
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
        /// 查询okc中的产品
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetOKCProduct(OKCPriceInfoSearchDTO dto)
        {
            ResultData<List<OKCProductResult>> result = new ResultData<List<OKCProductResult>>();

            result = ProductManagementProvider.GetOKCProduct(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 查询okc中的经销商
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetOKCDistributor(OKCPriceInfoSearchDTO dto)
        {
            ResultData<List<OKCDistributorResult>> result = new ResultData<List<OKCDistributorResult>>();

            result = ProductManagementProvider.GetOKCDistributor(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增OKC号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddOKC(OKCPriceInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            dto.AddType = 1;
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
        /// 新增OKC产品特价
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddOKCProduct(OKCPriceInfoModel dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            dto.AddType = 2;
            try
            {
                result = ProductManagementProvider.AddOKCProduct(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增OKC经销商及最终客户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddOKCDepAndCus(OKCPriceInfoModel dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            dto.AddType = 3;
            try
            {
                result = ProductManagementProvider.AddOKCDepAndCus(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改OKC号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateOKC(OKCPriceInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.UpType = 1;
            try
            {
                result = ProductManagementProvider.UpdateOKC(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除OKC号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteOKC(OKCPriceInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            dto.DelType = 1;
            try
            {
                result = ProductManagementProvider.DeleteOKC(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除OKC产品特价
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteOKCProduct(OKCPriceInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            dto.DelType = 2;
            try
            {
                result = ProductManagementProvider.DeleteOKC(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除OKC经销商及最终客户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteOKCDepAndCus(OKCPriceInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.DelType = 3;
            try
            {
                result = ProductManagementProvider.DeleteOKC(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult OKCInfoInsert(OKCPriceInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.UpType = 2;
            try
            {
                result = ProductManagementProvider.UpdateOKC(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到试剂产品清单信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetIsActiveReagentInfo(ProductInfoSearchDTO dto)
        {
            ResultData<List<ProductInfoModel>> result = null;

            result = ProductManagementProvider.GetIsActiveReagentInfo(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
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
        /// 得到启用的客户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetIsActiveCustomerList(CustomerSearchDTO dto)
        {
            ResultData<List<CustomerInfoModel>> result = null;
            dto.page = 1;
            dto.rows = 10000000;
            result = ProductManagementProvider.GetIsActiveCustomerList(dto);

            return Json(result.Object, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 导出试剂产品特价
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportReagentSpecial(OKCPriceInfoSearchDTO dto)
        {
            string result = null;
            dto.page = 1;
            dto.rows = 10000000;
            var pp = ProductManagementProvider.GetOKCList(dto).Object;
            dto = new OKCPriceInfoSearchDTO();
            dto.page = 1;
            dto.rows = 10000000;
            var aa = ProductManagementProvider.GetOKCProduct(dto).Object;
            var ss = ProductManagementProvider.GetOKCDistributor(dto).Object;

            string strTemplateFile = Server.MapPath(@"~/TempLate/ProductSpecialTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            pp.ForEach(g =>
            {
                var a = aa.Where(p => p.OKCID == g.OKCID).ToList();
                var s = ss.Where(p => p.OKCID == g.OKCID).ToList();
                if (a.Count() == 0)
                {
                    Models.Model.Excel.ExcelProductSpecial er = new Models.Model.Excel.ExcelProductSpecial();
                    er.状态 = g.OKCEnd > DateTime.Now ? "启用" : "停用";
                    er.货号 = "";
                    er.产品名称 = "";
                    er.产品线 = "";
                    er.OKC价格不含税 = null;
                    er.OKC号 = g.OKCNO;
                    er.起始日期 = g.OKCStart.Value.ToString("yyyy-MM-dd");
                    er.结束日期 = g.OKCEnd.Value.ToString("yyyy-MM-dd");
                    er.经销商 = "";
                    er.最终客户 = "";
                    ratelist.Add(er);
                }
                a.ForEach(okcg =>
                {
                    if (s.Count() == 0)
                    {
                        Models.Model.Excel.ExcelProductSpecial er = new Models.Model.Excel.ExcelProductSpecial();
                        er.状态 = g.OKCEnd < DateTime.Now ? "停用" : "启用";
                        er.货号 = okcg.ArtNo;
                        er.产品名称 = okcg.ProductName;
                        er.产品线 = okcg.ProductLineName;
                        er.OKC价格不含税 = okcg.ProductOKCPrice;
                        er.OKC号 = g.OKCNO;
                        er.起始日期 = g.OKCStart.Value.ToString("yyyy-MM-dd");
                        er.结束日期 = g.OKCEnd.Value.ToString("yyyy-MM-dd");
                        er.经销商 = "";
                        er.最终客户 = "";
                        ratelist.Add(er);
                    }
                    s.ForEach(depg =>
                    {
                        Models.Model.Excel.ExcelProductSpecial er = new Models.Model.Excel.ExcelProductSpecial();
                        er.状态 = g.OKCEnd < DateTime.Now ? "停用" : "启用";
                        er.货号 = okcg.ArtNo;
                        er.产品名称 = okcg.ProductName;
                        er.产品线 = okcg.ProductLineName;
                        er.OKC价格不含税 = okcg.ProductOKCPrice;
                        er.OKC号 = g.OKCNO;
                        er.起始日期 = g.OKCStart.Value.ToString("yyyy-MM-dd");
                        er.结束日期 = g.OKCEnd.Value.ToString("yyyy-MM-dd");
                        er.经销商 = depg.DistributorName;
                        er.最终客户 = depg.CustomerName;
                        ratelist.Add(er);
                    });
                });
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        public FileContentResult DownloadReagentSpecial(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("试剂产品特价" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
        //导入
        public ActionResult ImportReagentSpecial(int? OKCID)
        {
            string strErrorPath = null;
            HttpFileCollectionBase httfiles = Request.Files;
            if (httfiles.Count > 0)
            {
                HttpPostedFileBase httpfile = httfiles[0];
                try
                {
                    List<string[]> arrstrmapplst = new List<string[]> { 
                        new string[]{"货号","ArtNo"},
                        new string[]{"OKC价格（不含税）","ProductOKCPrice"},
                        new string[]{"检测情况","CheckInfo"}
                    };
                    string strGenarateDir = Server.MapPath(@"~/TempFile");
                    string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
                    string strExportFile = strGenarateDir + "\\" + strGenarateFile;
                    List<ExcelProductSpecialDTO> rplst = ExcelHelper.Import<ExcelProductSpecialDTO>(httpfile.InputStream, "Sheet1", arrstrmapplst, CheckReagentSpecialInfo, strExportFile);
                    if (rplst == null)
                    {
                        strErrorPath = strGenarateFile;
                    }
                    else
                    {
                        foreach (var p in rplst)
                        {
                            p.OKCID = OKCID;
                        }
                        var boolD = ProductManagementProvider.ImportReagentSpecial(rplst);
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
        private bool CheckReagentSpecialInfo(object obj)
        {
            var productslist = ProductManagementProvider.GetProductBaseInfo();//所有产品
            List<ExcelProductSpecialDTO> exceldto = (List<ExcelProductSpecialDTO>)obj;
            string strimporter = ((UserLoginDTO)Session["UserLoginInfo"]).FullName;
            bool result = true;

            foreach (var p in exceldto)
            {
                StringBuilder sb = new StringBuilder();
                // 货号不可为空
                if (String.IsNullOrEmpty(p.ArtNo))
                {
                    sb.Append("货号不可为空!");
                }
                else
                {
                    var exist = productslist.Where(m => m.IsMaintenance == false && m.ArtNo == p.ArtNo).FirstOrDefault();
                    if (exist != null)
                    {
                        p.ProductID = exist.ProductID;
                    }
                    else
                    {
                        sb.Append("货号不存在");
                    }
                }

                //检测OKC价格
                if (string.IsNullOrEmpty(p.ProductOKCPrice))
                {
                    sb.Append("OKC价格不可为空!");
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
        #endregion

        #region 维修产品清单
        /// <summary>
        /// 得到维修产品清单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetMaintenanceInfoList(ProductInfoSearchDTO dto)
        {
            ResultData<List<ProductInfoModel>> result = new ResultData<List<ProductInfoModel>>();

            result = ProductManagementProvider.GetMaintenanceInfoList(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条维修产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetMaintenanceInfo(ProductInfoSearchDTO dto)
        {
            ResultData<ProductInfoModel> result = new ResultData<ProductInfoModel>();
            dto.page = 1;
            dto.rows = 10;
            try
            {
                result = ProductManagementProvider.GetMaintenanceInfo(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 维修产品清单新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddMaintenanceInfo(ProductInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.IsMaintenance = true;
            dto.ProductID = Guid.NewGuid();
            dto.IsActive = true;
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            try
            {
                result = ProductManagementProvider.AddMaintenanceInfo(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 维修产品清单修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateMaintenanceInfo(ProductInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.UpType = 1;
            try
            {
                result = ProductManagementProvider.UpdateMaintenanceInfo(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 维修产品清单删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteMaintenanceInfo(ProductInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            try
            {
                result = ProductManagementProvider.DeleteMaintenanceInfo(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 停启用维修产品清单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ChangeStatusMaintenanceInfo(ProductInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            dto.UpType = 2;
            try
            {
                result = ProductManagementProvider.ChangeStatusMaintenanceInfo(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 导出维修产品清单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportRepair(ProductInfoSearchDTO dto)
        {
            string result = null;
            dto.page = 1;
            dto.rows = 10000000;
            List<ProductInfoModel> pp = null;
            pp = ProductManagementProvider.GetMaintenanceInfoList(dto).Object;

            string strTemplateFile = Server.MapPath(@"~/TempLate/RepairTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            pp.ForEach(g =>
            {
                Models.Model.Excel.ExcelRepair er = new Models.Model.Excel.ExcelRepair();
                er.状态 = g.IsActivestr;
                er.货号 = g.ArtNo;
                er.产品名称 = g.ProductName;
                er.产品类型 = g.ProductTypeName;
                er.产品小类 = g.ProductSmallTypeName;
                er.产品线 = g.ProductLineName;
                er.是否3C产品 = g.Is3CStr;
                er.中文描述及备注 = g.RemarkDes;
                ratelist.Add(er);
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        public FileContentResult DownloadRepair(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("维修产品" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
        public ActionResult ImportRepairProduct()
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
                        new string[]{"货号","ArtNo"},
                        new string[]{"产品名称","ProductName"},
                        new string[]{"产品类型","ProductTypeName"},
                        new string[]{"产品小类","ProductSmallTypeName"},
                        new string[]{"产品线","ProductLineName"},
                        new string[]{"3C产品","Is3CStr"},
                        new string[]{"中文描述及备注","RemarkDes"},
                        new string[]{"检测情况","CheckInfo"}
                    };
                    string strGenarateDir = Server.MapPath(@"~/TempFile");
                    string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
                    string strExportFile = strGenarateDir + "\\" + strGenarateFile;
                    List<ExcelRepairProductDTO> rplst = ExcelHelper.Import<ExcelRepairProductDTO>(httpfile.InputStream, "Sheet1", arrstrmapplst, CheckRepairProductInfo, strExportFile);
                    if (rplst == null)
                    {
                        strErrorPath = strGenarateFile;
                    }
                    else
                    {
                        var boolD = ProductManagementProvider.ImportRepairProduct(rplst);
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
        private bool CheckRepairProductInfo(object obj)
        {

            var producttypelist = ProductManagementProvider.GetProductTypeBaseInfo();//产品类型 
            var productlinelist = ProductManagementProvider.GetProductLineBaseInfo();//产品线
            var productslist = ProductManagementProvider.GetProductBaseInfo();//所有产品
            var productsmalltypelist = ProductManagementProvider.GetProductSmallTypeBaseInfo();//产品小类
            List<ExcelRepairProductDTO> exceldto = (List<ExcelRepairProductDTO>)obj;
            string strimporter = ((UserLoginDTO)Session["UserLoginInfo"]).FullName;
            bool result = true;

            foreach (var p in exceldto)
            {

                StringBuilder sb = new StringBuilder();
                // 货号不可为空
                if (String.IsNullOrEmpty(p.ArtNo))
                {
                    sb.Append("货号不可为空!");
                }

                //检测产品名称
                if (string.IsNullOrEmpty(p.ProductName))
                {
                    sb.Append("产品名称不可为空!");
                }

                // 检测产品线不可为空
                if (String.IsNullOrEmpty(p.ProductLineName))
                {
                    sb.Append("产品线不可为空!");
                }
                else
                {
                    // 检测产品线是否存在
                    var productlineid = productlinelist.Where(m => m.ProductLineName == p.ProductLineName).Select(m => m.ProductLineID).FirstOrDefault();
                    if (productlineid == null)
                    {
                        sb.Append("产品线不存在");
                    }
                    else
                    {
                        p.ProductLineID = productlineid;
                    }
                }

                // 检测类型不可为空
                if (String.IsNullOrEmpty(p.ProductTypeName))
                {
                    sb.Append("产品类型不可为空!");
                }
                else
                {
                    // 检测产品类型是否存在
                    var producttypeid = producttypelist.Where(m => m.ProductTypeName == p.ProductTypeName).Select(m => m.ProductTypeID).FirstOrDefault();
                    if (producttypeid == null)
                    {
                        sb.Append("产品类型不存在!");
                    }
                    else
                    {
                        p.ProductTypeID = producttypeid;
                    }
                }
                if (string.IsNullOrEmpty(p.ProductSmallTypeName))
                {
                    sb.Append("产品小类不可为空!");
                }
                else
                {
                    // 检测产品小类是否存在
                    var productsmalltypeid = productsmalltypelist.Where(m => m.ProductSmallTypeName == p.ProductSmallTypeName).Select(m => m.ProductSmallTypeID).FirstOrDefault();
                    if (productsmalltypeid == null)
                    {
                        sb.Append("产品小类不存在!");
                    }
                    else
                    {
                        p.ProductSmallTypeID = productsmalltypeid;
                    }
                }

                if (p.ProductLineID != null && !string.IsNullOrEmpty(p.ArtNo))
                {
                    var exist = productslist.Where(m => m.IsMaintenance == true && m.ArtNo == p.ArtNo && m.ProductLineID == p.ProductLineID).FirstOrDefault();
                    if (exist != null)
                    {
                        p.ProductID = exist.ProductID;
                        p.UpLogic = 2;
                    }
                    else
                    {
                        p.UpLogic = 1;
                    }

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
        #endregion

        #region 维修产品价格
        /// <summary>
        /// 得到维修产品价格
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetMaintenancePriceList(ProductPriceInfoSearchDTO dto)
        {
            ResultData<List<ProductPriceModel>> result = new ResultData<List<ProductPriceModel>>();

            result = ProductManagementProvider.GetMaintenancePriceList(dto);

            return Json(new { total = result.Count, rows = result.Object }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到一条维修产品价格
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetMaintenancePrice(ProductPriceInfoSearchDTO dto)
        {
            ResultData<ProductPriceModel> result = new ResultData<ProductPriceModel>();

            try
            {
                result = ProductManagementProvider.GetMaintenancePrice(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 维修产品价格修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateMaintenancePrice(ProductPriceInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            try
            {
                result = ProductManagementProvider.UpdateMaintenancePrice(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 维修产品价格删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteMaintenancePrice(ProductPriceInfoOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();

            try
            {
                result = ProductManagementProvider.DeleteMaintenancePrice(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 导出维修产品价格
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult ExportRepairPrice(ProductPriceInfoSearchDTO dto)
        {
            string result = null;
            dto.page = 1;
            dto.rows = 10000000;
            List<ProductPriceModel> pp = null;
            pp = ProductManagementProvider.GetMaintenancePriceList(dto).Object;

            string strTemplateFile = Server.MapPath(@"~/TempLate/RepairPriceTemplate.xlsx");
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
            string strExportFile = strGenarateDir + "\\" + strGenarateFile;
            List<object> ratelist = new List<object>();
            pp.ForEach(g =>
            {
                Models.Model.Excel.ExcelRepairPrice er = new Models.Model.Excel.ExcelRepairPrice();
                er.状态 = ((g.ProductPriceID == null) || (g.DNPPriceStart.HasValue && g.DNPPriceStart.Value.Date > DateTime.Now) || (g.DNPPriceEnd.HasValue && g.DNPPriceEnd.Value.Date.AddDays(1) < DateTime.Now)) ? "停用" : "启用";
                er.货号 = g.ArtNo;
                er.产品名称 = g.ProductName;
                er.DNP价格含税 = g.DNPPrice;
                er.产品线 = g.ProductLineName;
                er.起始日期 = g.DNPPriceStart.HasValue ? g.DNPPriceStart.Value.ToString("yyyy-MM-dd") : null;
                er.结束日期 = g.DNPPriceEnd.HasValue ? g.DNPPriceEnd.Value.ToString("yyyy-MM-dd") : null;
                ratelist.Add(er);
            });

            if (Common.ExcelHelper.Export(strTemplateFile, strGenarateDir, strGenarateFile, ratelist, "Sheet1"))
            {
                result = strGenarateFile;
            }

            return Json(result);
        }
        public FileContentResult DownloadRepairPrice(string filename)
        {
            FileContentResult fileresult = null;
            string strGenarateDir = Server.MapPath(@"~/TempFile");
            string strExportFile = strGenarateDir + "\\" + filename;
            fileresult = File(System.IO.File.ReadAllBytes(strExportFile), "application/vnd.ms-excel", Url.Encode("维修产品价格" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            System.IO.File.Delete(strExportFile);

            return fileresult;
        }
        public ActionResult ImportRepairPrice()
        {
            string strErrorPath = null;
            HttpFileCollectionBase httfiles = Request.Files;
            if (httfiles.Count > 0)
            {
                HttpPostedFileBase httpfile = httfiles[0];
                try
                {
                    List<string[]> arrstrmapplst = new List<string[]> { 
                        new string[]{"货号","ArtNo"},
                        new string[]{"价格（含税）","DNPPriceStr"},
                        new string[]{"起始日期","DNPPriceStartStr"},
                        new string[]{"结束日期","DNPPriceEndStr"},
                        new string[]{"检测情况","CheckInfo"}
                    };
                    string strGenarateDir = Server.MapPath(@"~/TempFile");
                    string strGenarateFile = Guid.NewGuid().ToString("N") + ".xlsx";
                    string strExportFile = strGenarateDir + "\\" + strGenarateFile;
                    List<ExcelRepairPriceDTO> rplst = ExcelHelper.Import<ExcelRepairPriceDTO>(httpfile.InputStream, "Sheet1", arrstrmapplst, CheckRepairPriceInfo, strExportFile);
                    if (rplst == null)
                    {
                        strErrorPath = strGenarateFile;
                    }
                    else
                    {
                        var boolD = ProductManagementProvider.ImportRepairPrice(rplst);
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
        private bool CheckRepairPriceInfo(object obj)
        {
            var productslist = ProductManagementProvider.GetProductBaseInfo();//所有产品
            List<ExcelRepairPriceDTO> exceldto = (List<ExcelRepairPriceDTO>)obj;
            string strimporter = ((UserLoginDTO)Session["UserLoginInfo"]).FullName;
            bool result = true;

            foreach (var p in exceldto)
            {

                StringBuilder sb = new StringBuilder();
                // 货号不可为空
                if (String.IsNullOrEmpty(p.ArtNo))
                {
                    sb.Append("货号不可为空!");
                }
                else
                {
                    var exist = productslist.Where(m => m.IsMaintenance == true && m.ArtNo == p.ArtNo).FirstOrDefault();
                    if (exist == null)
                    {
                        sb.Append("货号不存在!");
                    }
                    else
                    {
                        p.ProductID = exist.ProductID;
                    }
                }

                if (string.IsNullOrEmpty(p.DNPPriceStr))
                {
                    sb.Append("价格不可为空!");
                }
                if (string.IsNullOrEmpty(p.DNPPriceStartStr))
                {
                    sb.Append("开始时间不可为空!");
                }
                if (string.IsNullOrEmpty(p.DNPPriceEndStr))
                {
                    sb.Append("结束时间不可为空!");
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
        #endregion
    }
}