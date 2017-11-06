using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Excel
{
    public class ExcelRepair
    {
        public string 状态 { get; set; }
        public string 货号 { get; set; }
        public string 产品名称 { get; set; }
        public string 产品类型 { get; set; }
        public string 产品小类 { get; set; }
        public string 产品线 { get; set; }
        public string 是否3C产品 { get; set; }
        public string 中文描述及备注 { get; set; }
    }
}