using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCSOFT.DMS.MasterData.DTO.Area;
using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider;
using TCSOFT.DMS.WebMain.Models.Model;
using TCSOFT.DMS.MasterData.DTO.Common;
using TCSOFT.DMS.MasterData.DTO;
using TCSOFT.DMS.WebMain.Filter;
using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Controllers
{
    public class AreaRegionController : BaseController
    {
        // GET: MasterData/AreaRegion
       [AuthorityFilter(AuthorityID = "095001001")]
        public ActionResult Region()
        {
            ViewBag.CrruentAuthority = GetAuthority("095001001");

            return View();
        }
        [AuthorityFilter(AuthorityID = "095001002")]
        public ActionResult Area()
        {
            ViewBag.CrruentAuthority = GetAuthority("095001002");

            return View();
        }
        #region 行政区划
        /// <summary>
        /// 得到所有省
        /// </summary>
        /// <returns></returns>
        public ActionResult GetProvinceRegionList()
        {
            List<RegionResultDTO> result = new List<RegionResultDTO>();

            result = AreaRegionProvider.GetProvinceRegionList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到搜索框所有省（带请选择）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetSearchProvinceRegionList()
        {
            List<RegionResultDTO> result = new List<RegionResultDTO>();

            result = AreaRegionProvider.GetProvinceRegionList();
            result.Insert(0, new RegionResultDTO { RegionID = -1, RegionName = "请选择" });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到下级行政区划(带请选择)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetSearchNextLevelRegionList(RegionSearchDTO dto)
        {
            var result = AreaRegionProvider.GetNextLevelRegionList(dto);
            result.Insert(0, new RegionResultDTO { RegionID = -1, RegionName = "请选择" });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 得到下级行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetFirstLevelRegionList(RegionSearchDTO dto)
        {
            var result = AreaRegionProvider.GetFirstLevelRegionList(dto);
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// 得到下级行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetNextLevelRegionList(RegionSearchDTO dto)
        {
            var result = AreaRegionProvider.GetNextLevelRegionList(dto);
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// 得到一个行政区划信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetRegion(RegionSearchDTO dto)
        {
            var result = AreaRegionProvider.GetRegion(dto);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddRegion(RegionOperateDTO dto)
        {
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;
            var result = AreaRegionProvider.AddRegion(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改行政区划信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateRegion(RegionOperateDTO dto)
        {
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;
            var result = AreaRegionProvider.UpdateRegion(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteRegion(RegionSearchDTO dto)
        {
            var result = AreaRegionProvider.DeleteRegion(dto);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 大区小区
        /// <summary>
        /// 大小区显示/小区省份显示
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetArea(AreaSearchDTO dto)
        {
            List<AreaResultDTO> result = null;

            result = AreaRegionProvider.GetArea(dto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 大小区显示一条/小区省份显示一条
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetOneArea(AreaSearchDTO dto)
        {
            ResultData<AreaResultDTO> result = new ResultData<AreaResultDTO>();
            try
            {
                result.Object = AreaRegionProvider.GetOneArea(dto);
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
        /// 大小区新增/小区省份新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult AddArea(AreaOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.CreateUser = user.FullName;
            dto.CreateTime = DateTime.Now;

            try 
            {
                result = AreaRegionProvider.AddArea(dto);
            }
            catch (Exception ex) 
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 大小区修改/小区省份修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult UpdateArea(AreaOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;
            dto.ModifyTime = DateTime.Now;

            try
            {
                result = AreaRegionProvider.UpdateArea(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 大小区删除/小区省份删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult DeleteArea(AreaOperateDTO dto)
        {
            ResultData<object> result = new ResultData<object>();
            UserLoginDTO user = (UserLoginDTO)Session["UserLoginInfo"];
            dto.ModifyUser = user.FullName;

            try
            {
                result = AreaRegionProvider.DeleteArea(dto);
            }
            catch (Exception ex)
            {
                result.SubmitResult = false;
                result.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 部门大区显示
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetDepArea(int? DepartID)
        {
            List<DepaAreaTreeModel> result = null;

            result = AreaRegionProvider.GetDepArea(DepartID);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 根据部门得到大区
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult GetDepAreaByDepartID(int? DepartID)
        {
            List<AreaResultDTO> result = null;

            result = AreaRegionProvider.GetDepAreaByDepartID(DepartID);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}