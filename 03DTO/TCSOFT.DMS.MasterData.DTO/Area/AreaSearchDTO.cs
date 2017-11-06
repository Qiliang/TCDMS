using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Area
{
    /// <summary>
    /// 大小区查询
    /// </summary>
    public class AreaSearchDTO
    {
        /// <summary>
        /// 模糊查询
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// 大小区ID
        /// </summary>
        public int? AreaID { get; set; }
        /// <summary>
        /// 大小区PID
        /// </summary>
        public int? AreaPID { get; set; }
        /// <summary>
        /// 大小区关联行政区划ID
        /// </summary>
        public int? AreaRegionID { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DepartID { get; set; }
    }
}
