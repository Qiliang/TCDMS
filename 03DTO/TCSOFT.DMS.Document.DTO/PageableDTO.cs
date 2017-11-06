using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO
{
    public class PageableDTO<T>
    {
        
        public int total { get; set; }      
      
        public List<T> rows { get; set; }
    }
}
