using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO.Lss
{
    public class TagDTO
    {
        public int id { get; set; }       
        public string text { get; set; }               
        public List<TagDTO> children { get; set; }
    }
}
