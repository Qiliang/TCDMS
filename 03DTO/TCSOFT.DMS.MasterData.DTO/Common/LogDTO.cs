using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Common
{
    public class LogDTO
    {
        /// <summary>
        /// 日志流水号
        /// </summary>
        public long LogIndex { get; set; }
        /// <summary>
        /// 所属模块
        /// </summary>
        public string BelongModel { get; set; }
        /// <summary>
        /// 所属功能
        /// </summary>
        public string BelongFunc { get; set; }
        /// <summary>
        /// 日志明细
        /// </summary>
        public string LogDetails { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime? LogDate { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string OpratorName { get; set; }
    }
    public class LogSearchDTO:PagingDTO
    {
        /// <summary>
        /// 模糊查询
        /// </summary>
        public string SearchText { get; set; }
        /// <summary>
        /// 所属模块
        /// </summary>
        public string BelongModel { get; set; }
        /// <summary>
        /// 年
        /// </summary>
        public int? Year { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        public int? Month { get; set; }
    }
}
