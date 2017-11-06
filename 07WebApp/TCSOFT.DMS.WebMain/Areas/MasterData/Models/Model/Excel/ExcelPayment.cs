using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Excel
{
    public class ExcelPayment
    {
        public string 状态 { get; set; }
        public string 付款条款 { get; set; }
        public string OracleName { get; set; }
        public string 开始日期 { get; set; }

        public string 结束日期 { get; set; }
    }
}