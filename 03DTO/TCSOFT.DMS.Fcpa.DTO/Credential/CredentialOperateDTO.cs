using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Fcpa.DTO.Credential
{
    public class CredentialOperateDTO : FcpaDTO
    {
        public Guid ID { get; set; }
        public string DistributorID { get; set; }
        public string Certificate { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool OffWork { get; set; }
        public DateTime? OffWorkDate { get; set; }
        public bool Domain1 { get; set; }
        public bool Domain2 { get; set; }
        public string Remark { get; set; }
    }
}
