using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO.Lss
{
    public class LssResultDTO
    {
        public Guid LssID { get; set; }
        public int? TagID { get; set; }     
        public string TagName { get; set; }     
        public string Title { get; set; }
        public DateTime? ValidDate { get; set; }
        public DateTime? EffectDate { get; set; }
        public string Publisher { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDownload { get; set; }
        public bool IsFavorite { get; set; }
        public IEnumerable<LssAttachmentDTO> Attachments { get; set; }
    }
}
