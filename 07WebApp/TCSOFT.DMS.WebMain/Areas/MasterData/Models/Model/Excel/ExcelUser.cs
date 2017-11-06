using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Excel
{
    public class ExcelUser
    {
        public string 状态 { get; set; }
        public string 用户编号 { get; set; }
        public string 用户名称 { get; set; }
        public string 手机号 { get; set; }
        public string 邮箱 { get; set; }
        public string 角色 { get; set; }
        public string 经销商 { get; set; }
        public string 到期日 { get; set; }
        public string 停用日期 { get; set; }
        public string 权限 { get; set; }
    }
}