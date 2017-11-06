using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TCSOFT.DMS.MasterData.IServices
{
    using DTO.Area;
    using DTO.Common;
    public interface IRegionServices
    {
        #region 行政区划
        /// <summary>
        /// 所有行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<RegionResultDTO> GetRegionList();
        /// <summary>
        /// 新增行政区区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool AddRegion(RegionOperateDTO dto);
        /// <summary>
        /// 修改行政区内容
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool UpdateRegion(RegionOperateDTO dto);
        /// <summary>
        /// 删除行政区划
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DeleteRegion(RegionSearchDTO dto);
        #endregion
        #region 大小区
        /// <summary>
        /// 大小区显示
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<AreaResultDTO> GetAreaTree(AreaSearchDTO dto);
        /// <summary>
        /// 大小区新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool AddArea(AreaOperateDTO dto);
        /// <summary>
        /// 大小区修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool UpdateArea(AreaOperateDTO dto);
        /// <summary>
        /// 大小区删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DeleteArea(AreaOperateDTO dto);
        /// <summary>
        /// 小区省份新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool AddAreaRegion(AreaOperateDTO dto);
        /// <summary>
        /// 小区省份修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool UpdateAreaRegion(AreaOperateDTO dto);
        /// <summary>
        /// 小区省份删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool DeleteAreaRegion(AreaOperateDTO dto);
        /// <summary>
        /// 大区
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        List<AreaResultDTO> GetArea();
        #endregion
    }
}
