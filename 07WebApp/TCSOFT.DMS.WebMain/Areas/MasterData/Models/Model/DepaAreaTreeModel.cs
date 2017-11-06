using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Model
{
    public class DepaAreaTreeModel
    {
        public int? id { get; set; }
        public string text { get; set; }
        public List<DepaAreaTreeModel> children { get; set; }
    }
}