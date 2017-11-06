using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Excel
{
    public class ExcelCustomerInfo
    {
        public string 状态 { get; set; }
        public string 省份 { get; set; }
        public string 城市 { get; set; }

        public string 客户类型 { get; set; }

        public string 新增时间 { get; set; }
        public string Oracle号 { get; set; }
        public string OracleName { get; set; }

        public string 经销商提交客户名称 { get; set; }
        public string 携手网编号 { get; set; }

        public string 经销商名称 { get; set; }
        public string 审批人 { get; set; }
        public string 最后修改人 { get; set; }
    }
}