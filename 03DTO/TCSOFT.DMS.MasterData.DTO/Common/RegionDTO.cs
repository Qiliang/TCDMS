using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Common
{
    
    public class RegionOperateDTO:OperateDTO
    {
        /// <summary>
        /// 行政区划ID
        /// </summary>
        public int? RegionID { get; set; }
        /// <summary>
        /// 行政区划PID
        /// </summary>
        public int? RegionPID { get; set; }
        /// <summary>
        /// 行政区划编号
        /// </summary>
        public string RegionCode { get; set; }
        /// <summary>
        /// 行政区划名称
        /// </summary>
        public string RegionName { get; set; }
        /// <summary>
        /// 行政区划等级
        /// </summary>
        public int? RegionLevel { get; set; }
    }
    public class RegionResultDTO
    {
        /// <summary>
        /// 行政区划ID
        /// </summary>
        public int? RegionID { get; set; }
        /// <summary>
        /// 行政区划PID
        /// </summary>
        public int? RegionPID { get; set; }
        /// <summary>
        /// 行政区划编号
        /// </summary>
        public string RegionCode { get; set; }
        /// <summary>
        /// 行政区划名称
        /// </summary>
        public string RegionName { get; set; }
        /// <summary>
        /// 行政区划等级
        /// </summary>
        public int? RegionLevel { get; set; }
        /// <summary>
        /// 下级行政区划
        /// </summary>
        public List<RegionResultDTO> children { get; set; }
    }
    public class RegionSearchDTO
    {
        /// <summary>
        /// 行政区划ID
        /// </summary>
        public int? RegionID { get; set; }
        /// <summary>
        /// 行政区划PID
        /// </summary>
        public int? RegionPID { get; set; }
        /// <summary>
        /// 搜索条件
        /// </summary>
        public string SearchText { get; set; }
    }
}
