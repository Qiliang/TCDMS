using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO.Bcce
{
    public class BcceAddDTO : DocumentDTO
    {
        public string Title { get; set; }
        public int? ProductLineID { get; set; }
        public string ProductLineName { get; set; }
        public int? ProductTypeID { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductNo { get; set; }
        public DateTime? ValidDate { get; set; }
        public List<BcceAttachmentDTO> AttachmentIDs { get; set; }
    }
}
