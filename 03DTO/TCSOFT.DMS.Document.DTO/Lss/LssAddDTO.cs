using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO.Lss
{
    public class LssAddDTO:DocumentDTO
    {
        public string Title { get; set; }
        public int? TagID { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ValidDate { get; set; }
        public List<LssAttachmentDTO> AttachmentIDs { get; set; }
    }
}
