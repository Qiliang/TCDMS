using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.Document.Models.Model
{
    public class ExcelHeaderModel
    {
        public string Header { get; set; }
        public string PropertyName { get; set; }
        public int Width { get; set; }
        public int ForColor { get; set; }
        public int BackgroupColor { get; set; }
    }
}