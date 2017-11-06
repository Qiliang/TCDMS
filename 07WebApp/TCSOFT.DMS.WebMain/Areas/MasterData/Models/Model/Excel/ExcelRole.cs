using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Excel
{
    public class ExcelRole
    {
        public string 角色名称 { get; set; }
        public string 角色类别 { get; set; }
        public string 一级模块权限 { get; set; }
        public string 二级模块权限 { get; set; }
        public string 三级模块权限 { get; set; }
        public string 功能权限 { get; set; }
    }
}