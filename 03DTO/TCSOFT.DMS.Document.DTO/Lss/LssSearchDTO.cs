using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO.Lss
{
    public class LssSearchDTO:QueryDTO
    {
        public string Search { get; set; }
        public DateTime? PublishDateFrom { get; set; }
        public DateTime? PublishDateTo { get; set; }
        public DateTime? UpdateDateFrom { get; set; }
        public DateTime? UpdateDateTo { get; set; }
        
        public int? TagID { get; set; }    
    }
}
