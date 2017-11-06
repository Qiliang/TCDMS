using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider
{
    using DMS.MasterData.DTO.Area;
    using WebMain.Models.Provider;
    using WebMain.Common;
    using DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using TCSOFT.DMS.WebMain.Models.Model;
    using TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model;
    public class AreaRegionProvider : BaseProvider
    {
        
        #region 大小区
        /// <summary>
        /// 大小区显示/小区省份显示
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<AreaResultDTO> GetArea(AreaSearchDTO dto)
        {
            List<AreaResultDTO> arealist = null;

            arealist = GetAPI<List<AreaResultDTO>>(WebConfiger.MasterDataServicesUrl + "Area?AreaSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return arealist;
        }
        /// <summary>
        /// 大小区显示一条/小区省份显示一条
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static AreaResultDTO GetOneArea(AreaSearchDTO dto)
        {
            AreaResultDTO area = null;

            var pp = GetAPI<List<AreaResultDTO>>(WebConfiger.MasterDataServicesUrl + "Area?AreaSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            if (dto.AreaRegionID == null)
            {
                if (dto.AreaPID == null)
                {
                    //大区
                    area = pp.Where(p => p.AreaID == dto.AreaID).FirstOrDefault();
                }
                else 
                {
                    //小区
                    var qq = pp.Where(p => p.AreaID == dto.AreaPID).FirstOrDefault();
                    area = qq.children.Where(q => q.AreaID == dto.AreaID).FirstOrDefault();
                }
            }
            else
            {
                //省
                foreach (var p in pp) 
                {
                    var qq = p.children.Where(q => q.AreaID == dto.AreaPID).FirstOrDefault();
                    if (qq != null)
                    {
                        area = qq.children.Where(q => q.AreaID == dto.AreaRegionID).FirstOrDefault();
                    }
                }
            }

            return area;
        }
        /// <summary>
        /// 大小区新增/小区省份新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddArea(AreaOperateDTO dto)
        {
            ResultData<object> blResult = new ResultData<object>();

            blResult = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Area", dto);

            return blResult;
        }
        /// <summary>
        /// 大小区修改/小区省份修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdateArea(AreaOperateDTO dto)
        {
            ResultData<object> blResult = new ResultData<object>();

            blResult = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Area", dto);

            return blResult;
        }
        /// <summary>
        /// 大小区删除/小区省份删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> DeleteArea(AreaOperateDTO dto)
        {
            ResultData<object> blResult = new ResultData<object>();

            blResult = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Area?AreaOperateDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));

            return blResult;
        }
        /// <summary>
        /// 部门大区显示
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<DepaAreaTreeModel> GetDepArea(int? DepartID)
        {
            List<DepaAreaTreeModel> result = new List<DepaAreaTreeModel>();

            if (DepartID != null)
            {
                List<AreaResultDTO> resultarea = GetAPI<List<AreaResultDTO>>(WebConfiger.MasterDataServicesUrl + "Area");
                List<DepartmentResultDTO> resultdepa = GetAPI<List<DepartmentResultDTO>>(WebConfiger.MasterDataServicesUrl + "Department?i=" + 1);
                var pp = resultdepa.Where(p => p.DepartID == DepartID).FirstOrDefault();
                int i = 0;
                FictitiousDepaArea(result, ref i, pp, resultdepa, resultarea);
            }

            return result;
        }
        public static void FictitiousDepaArea(List<DepaAreaTreeModel> result, ref int i, DepartmentResultDTO resultdepa, List<DepartmentResultDTO> resultdepas, List<AreaResultDTO> resultarea)
        {
            i--;
            DepaAreaTreeModel depareas = new DepaAreaTreeModel();
            depareas.id = i;
            depareas.text = resultdepa.DepartName;
            depareas.children = new List<DepaAreaTreeModel>();
            var ss=resultarea.Where(p => p.DepartID == resultdepa.DepartID).Select(s => new DepaAreaTreeModel
            {
                id = s.AreaID,
                text = s.AreaName
            }).ToList();
            depareas.children.AddRange(ss);
            result.Add(depareas);

            var ww = resultdepas.Where(q => q.DepartParentID == resultdepa.DepartID).ToList();
            foreach (var w in ww)
            {
                FictitiousDepaArea(depareas.children, ref i, w, resultdepas, resultarea);
            }
        }
        public static List<AreaResultDTO> GetDepAreaByDepartID(int? id)
        {
            
            List<AreaResultDTO> arealist = null;
            AreaSearchDTO dto = new AreaSearchDTO();
            arealist = GetAPI<List<AreaResultDTO>>(WebConfiger.MasterDataServicesUrl + "Area?AreaSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
            arealist=arealist.Where(m => m.DepartID == id).ToList();
            foreach (var area in arealist)
            {
                area.children = null;
            }

            return arealist;
        }

        #endregion
        #region 行政区划
        /// <summary>
        /// 得到所有行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<RegionResultDTO> GetRegionList()
        {
            List<RegionResultDTO>  result = GetAPI<List<RegionResultDTO>>(WebConfiger.MasterDataServicesUrl + "Region");
            
            return result;
        }
        /// <summary>
        /// 得到第一级行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<RegionResultDTO> GetFirstLevelRegionList(RegionSearchDTO dto)
        {
            List<RegionResultDTO> result = new List<RegionResultDTO>();

            if (GlobalStaticData.RegionList.Count > 0)
            {
                var root = GlobalStaticData.RegionList.Where(p => p.RegionLevel == 0).FirstOrDefault();
                if(root!=null)
                {
                    var first = GlobalStaticData.RegionList.Where(p => p.RegionLevel == 1).OrderBy(m => m.RegionID).ToList();
                    root.children = first;
                }
               
                result.Add(root);
            }

            return result;
        }
        /// <summary>
        /// 获取省
        /// </summary>
        /// <returns></returns>
        public static List<RegionResultDTO> GetProvinceRegionList()
        {
            List<RegionResultDTO> result = new List<RegionResultDTO>();

            if (GlobalStaticData.RegionList.Count>0)
            {
                result = GlobalStaticData.RegionList.Where(p => p.RegionLevel == 1).OrderBy(m => m.RegionID).ToList();
            }

            return result;
        }
        /// <summary>
        /// 得到下级行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<RegionResultDTO> GetNextLevelRegionList(RegionSearchDTO dto)
        {
            List<RegionResultDTO> result = new List<RegionResultDTO>();

            if (GlobalStaticData.RegionList.Count>0)
            {
                result = GlobalStaticData.RegionList.Where(p => p.RegionPID == dto.RegionID).ToList();
            }

            return result;
        }
        /// <summary>
        /// 得到一个行政区划信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static RegionResultDTO GetRegion(RegionSearchDTO dto)
        {
            RegionResultDTO result = null;

            if (GlobalStaticData.RegionList.Count > 0)
            {
                result = GlobalStaticData.RegionList.Where(p => p.RegionID == dto.RegionID).FirstOrDefault();
            }

            return result;
        }
        /// <summary>
        /// 新增行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> AddRegion(RegionOperateDTO dto)
        {
            var result = new ResultData<object>();

            try
            {
                result = PostAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Region", dto);
                GlobalStaticData.RegionList = GetAPI<List<RegionResultDTO>>(WebConfiger.MasterDataServicesUrl + "Region");
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }

            

            return result;
        }
        /// <summary>
        /// 修改行政区划信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> UpdateRegion(RegionOperateDTO dto)
        {
            var result = new ResultData<object>();

            try
            {
                result = PutAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Region", dto);
                GlobalStaticData.RegionList = GetAPI<List<RegionResultDTO>>(WebConfiger.MasterDataServicesUrl + "Region");
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }

            return result;
        }
        /// <summary>
        /// 删除行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ResultData<object> DeleteRegion(RegionSearchDTO dto)
        {
            var result = new ResultData<object>();

            try
            {
                result = DeleteAPI<ResultData<object>>(WebConfiger.MasterDataServicesUrl + "Region?RegionSearchDTO=" + TransformHelper.ConvertDTOTOBase64JsonString(dto));
                GlobalStaticData.RegionList = GetAPI<List<RegionResultDTO>>(WebConfiger.MasterDataServicesUrl + "Region");
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }

            return result;
        }
        #endregion
    }
}