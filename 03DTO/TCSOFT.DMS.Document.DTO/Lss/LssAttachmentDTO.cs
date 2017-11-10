using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO.Lss
{
    public class LssAttachmentDTO
    {
        public Guid AttachmentID { get; set; }
        public string AttachmentName { get; set; }
        public int? AttachmentSize { get; set; }
    }
}
