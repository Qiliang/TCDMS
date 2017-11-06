using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.AccountDate
{
    using DTO.Common;
    public class AccountDateOperateDTO:OperateDTO
    {
        /// <summary>
        /// 关账日ID
        /// </summary>
        public int? AccountDateID { get; set; }
        /// <summary>
        /// 关账日名称
        /// </summary>
        public string AccountDateName { get; set; }
        /// <summary>
        /// 关账日年份
        /// </summary>
        public short? AccountDateYear { get; set; }
        /// <summary>
        /// 关账日送货地点
        /// </summary>
        public string AccountDatePlace { get; set; }
        /// <summary>
        /// 关账日所属模块
        /// </summary>
        public string AccountDateBelongModel { get; set; }
        /// <summary>
        /// 一月日期
        /// </summary>
        public DateTime? MonthDate { get; set; }
        /// <summary>
        /// 二月日期
        /// </summary>
        public DateTime? FebDate { get; set; }
        /// <summary>
        /// 三月日期
        /// </summary>
        public DateTime? MarchDate { get; set; }
        /// <summary>
        /// 四月日期
        /// </summary>
        public DateTime? AprilDate { get; set; }
        /// <summary>
        /// 五月日期
        /// </summary>
        public DateTime? MayDate { get; set; }
        /// <summary>
        /// 六月日期
        /// </summary>
        public DateTime? JuneDate { get; set; }
        /// <summary>
        /// 七月日期
        /// </summary>
        public DateTime? JulyDate { get; set; }
        /// <summary>
        /// 八月日期
        /// </summary>
        public DateTime? AugustDate { get; set; }
        /// <summary>
        /// 九月日期
        /// </summary>
        public DateTime? SepDate { get; set; }
        /// <summary>
        /// 十月日期
        /// </summary>
        public DateTime? OctDate { get; set; }
        /// <summary>
        /// 十一月日期
        /// </summary>
        public DateTime? NovDate { get; set; }
        /// <summary>
        /// 十二月日期
        /// </summary>
        public DateTime? DecDate { get; set; }
    }
}
