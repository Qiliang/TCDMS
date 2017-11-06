using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO.Register
{
    public class ProductLineNode
    {
      
        public int id { get; set; }
        public int ProductLineID { get; set; }      
        public string text { get; set; }
        public int DepartID { get; set; }
        public string DepartName { get; set; }
    }
}
