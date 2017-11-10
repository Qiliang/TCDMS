using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO.Bcce
{
    public class BcceSearchDTO : QueryDTO
    {
        public string Search { get; set; }
        public DateTime? PublishDateFrom { get; set; }
        public DateTime? PublishDateTo { get; set; }
        public int? ProductTypeID { get; set; }
        public int? ProductLineID { get; set; }
    }
}
