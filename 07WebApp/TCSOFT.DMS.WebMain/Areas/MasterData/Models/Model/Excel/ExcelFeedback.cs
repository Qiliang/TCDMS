using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model.Excel
{
    using Common;
    public class ExcelFeedback
    {
        //状态，附件，反馈日期，反馈人，反馈系统，反馈模块，反馈内容，经销商，部门，反馈人手机，反馈人邮箱
        public string 状态 { get; set; }
        public string 附件 { get; set; }
        public string 反馈日期 { get; set; }
        public string 反馈人 { get; set; }
        public string 反馈系统 { get; set; }
        public string 反馈模块 { get; set; }
        public string 反馈内容 { get; set; }
        public string 经销商 { get; set; }
        public string 部门 { get; set; }
        public string 反馈人手机 { get; set; }
        public string 反馈人邮箱 { get; set; }
    }
}