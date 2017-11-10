using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO.Register
{
    public class RegisterResultDTO
    {
        public Guid RegisterID { get; set; }
        public int? ProductTypeID { get; set; }
        public int? ProductLineID { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductLineName { get; set; }
        public string ProductNo { get; set; }
        public string Title { get; set; }
        public DateTime? ValidDate { get; set; }
        public string Publisher { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDownload { get; set; }
        public IEnumerable<RegisterAttachmentDTO> Attachments { get; set; }
    }
}
