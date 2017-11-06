using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.MasterData.DTO.Common;

namespace TCSOFT.DMS.MasterData.DTO.Area
{
    /// <summary>
    /// 大小区操作
    /// </summary>
    public class AreaOperateDTO : OperateDTO
    {
        /// <summary>
        /// 大小区ID
        /// </summary>
        public int? AreaID { get; set; }
        /// <summary>
        /// 大小区PID
        /// </summary>
        public int? AreaPID { get; set; }
        /// <summary>
        /// 大小区名称
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 大小区缩写
        /// </summary>
        public string AreaShortName { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DepartID { get; set; }
        /// <summary>
        /// 行政区划ID
        /// </summary>
        public int? RegionID { get; set; }

        /// <summary>
        /// 大小区关联行政区划ID
        /// </summary>
        public int? AreaRegionID { get; set; }
        /// <summary>
        /// 新增省份ID列表
        /// </summary>
        public List<int> RegionIDList { get; set; }
    }
}
