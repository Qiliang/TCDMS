using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.MasterData.DTO.Common;

namespace TCSOFT.DMS.MasterData.DTO.Area
{
    /// <summary>
    /// 大小区显示
    /// </summary>
    public class AreaResultDTO
    {
        /// <summary>
        /// 虚拟ID
        /// </summary>
        public int? FictitiousID { get; set; }
        /// <summary>
        /// ckid
        /// </summary>
        public bool Ckid { get; set; }
        /// <summary>
        /// 大小区ID
        /// </summary>
        public int? AreaID { get; set; }
        /// <summary>
        /// 大小区PID
        /// </summary>
        public int? AreaPID { get; set; }
        /// <summary>
        /// 名称
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
        /// 省ID
        /// </summary>
        public int? RegionID { get; set; }
        public List<AreaResultDTO> children { get; set; }
    }
}
