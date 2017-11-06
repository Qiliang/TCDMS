using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO.Register
{
    public class RegisterSearchDTO:QueryDTO
    {
        public string Search { get; set; }
        public DateTime? PublishDateFrom { get; set; }
        public DateTime? PublishDateTo { get; set; }
        public int? ProductTypeID { get; set; }
        public int? ProductLineID { get; set; }
    }
}
