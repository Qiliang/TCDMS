using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO.Bcce
{
    public class BcceUpdateDTO : BcceAddDTO
    {
        public Guid BcceID { get; set; }
        public List<Guid> DeleteAttachmentIDs { get; set; }
    }
}
