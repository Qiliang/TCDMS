using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Excel
{
    public class ExcelProductSpecial
    {
        public string 状态 { get; set; }
        public string 货号 { get; set; }
        public string 产品名称 { get; set; }
        public string 产品线 { get; set; }
        public decimal? OKC价格不含税 { get; set; }
        public string OKC号 { get; set; }
        public string 起始日期 { get; set; }
        public string 结束日期 { get; set; }
        public string 经销商 { get; set; }
        public string 最终客户 { get; set; }
    }
}