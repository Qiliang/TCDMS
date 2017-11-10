using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Document.DTO.Lss
{
    public class LssUpdateDTO:LssAddDTO
    {
        public Guid LssID { get; set; }
        public List<Guid> DeleteAttachmentIDs { get; set; }
    }
}
