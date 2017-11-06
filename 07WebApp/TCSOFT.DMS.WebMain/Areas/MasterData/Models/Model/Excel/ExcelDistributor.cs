using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Excel
{
    public class ExcelDistributor
    {
        public string 状态 { get; set; }
        public string 经销商编号 { get; set; }
        public string 经销商名称 { get; set; }
        public string 经销商类别 { get; set; }
        public string 经销商服务类型 { get; set; }
        public string 注册省份 { get; set; }
        public string 发票地址编号 { get; set; }
        public string 送货地址编号 { get; set; }
        public string CSR用户名试剂 { get; set; }
        public string CSR用户名维修D部 { get; set; }
        public string CSR用户名维修B部 { get; set; }
        public string 办事处 { get; set; }
        public string 停用时间 { get; set; }
    }
}