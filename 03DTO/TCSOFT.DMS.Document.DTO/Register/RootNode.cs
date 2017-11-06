using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO.Register
{
    public class RootNode
    {
        public int id { get { return 0; } }
        public string text { get { return "全部"; } }
        public List<DepartNode> children { get; set; }
    }
}
