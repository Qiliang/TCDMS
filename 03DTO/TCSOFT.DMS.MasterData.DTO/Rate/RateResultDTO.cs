using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.MasterData.DTO.Common;

namespace TCSOFT.DMS.MasterData.DTO.RateDTO
{
    public class RateResultDTO
    {
        /// <summary>
        /// 汇率ID
        /// </summary>
        public int? RateID { get; set; }
        /// <summary>
        /// 货币
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 汇率编码
        /// </summary>
        public string RateCode { get; set; }
        /// <summary>
        /// 汇率年份
        /// </summary>
        public short? RateYear { get; set; }
        /// <summary>
        /// 预算汇率
        /// </summary>
        public decimal? RateBudget { get; set; }
        /// <summary>
        /// 一月汇率
        /// </summary>
        public decimal? MonthRate { get; set; }
        /// <summary>
        /// 二月汇率
        /// </summary>
        public decimal? FebRate { get; set; }
        /// <summary>
        /// 三月汇率
        /// </summary>
        public decimal? MarchRate { get; set; }
        /// <summary>
        /// 四月汇率
        /// </summary>
        public decimal? AprilRate { get; set; }
        /// <summary>
        /// 五月汇率
        /// </summary>
        public decimal? MayRate { get; set; }
        /// <summary>
        /// 六月汇率
        /// </summary>
        public decimal? JuneRate { get; set; }
        /// <summary>
        /// 七月汇率
        /// </summary>
        public decimal? JulyRate { get; set; }
        /// <summary>
        /// 八月汇率
        /// </summary>
        public decimal? AugustRate { get; set; }
        /// <summary>
        /// 九月汇率
        /// </summary>
        public decimal? SepRate { get; set; }
        /// <summary>
        /// 十月汇率
        /// </summary>
        public decimal? OctRate { get; set; }
        /// <summary>
        /// 十一月汇率
        /// </summary>
        public decimal? NovRate { get; set; }
        /// <summary>
        /// 十二月汇率
        /// </summary>
        public decimal? DecRate { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }
        public string ModifyTimeDesc
        {
            get
            {
                string strResult = String.Empty;
                if (ModifyTime != null)
                {
                    strResult = ModifyTime.Value.ToString("yyyy-MM-dd");
                }

                return strResult;
            }
            set
            {
                DateTime dtResult = DateTime.MinValue;
                if (DateTime.TryParse(value, out dtResult))
                {
                    ModifyTime = dtResult;
                }
            }
        }
    }
}
