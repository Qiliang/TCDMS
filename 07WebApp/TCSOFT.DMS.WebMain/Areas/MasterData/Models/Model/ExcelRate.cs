using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model
{
    using Common;
    public class ExcelRate
    {
        public short? 年份 { get; set; }
        public string 汇率编码 { get; set; }
        public string 货币 { get; set; }
        public string 更新时间 { get; set; }
        public string 预算汇率 { get; set; }
        public string 一月 { get; set; }
        public string 二月 { get; set; }
        public string 三月 { get; set; }
        public string 四月 { get; set; }
        public string 五月 { get; set; }
        public string 六月 { get; set; }
        public string 七月 { get; set; }
        public string 八月 { get; set; }
        public string 九月 { get; set; }
        public string 十月 { get; set; }
        public string 十一月 { get; set; }
        public string 十二月 { get; set; }
    }
}