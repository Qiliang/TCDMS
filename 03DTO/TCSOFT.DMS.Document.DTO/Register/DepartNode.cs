using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO.Register
{
    public class DepartNode
    {
        public int id { get; set; }
        public string text { get; set; }
        public List<ProductLineNode> children { get; set; }
    }
}
