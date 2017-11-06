using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Fcpa.DTO.Alerm
{
    public class AlermSearchDTO : QueryDTO
    {
        public string UserCode { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool? Domain1 { get; set; }
        public bool? Domain2 { get; set; }
        public string Role { get; set; }
        public string RelDistributor { get; set; }
        public DateTime? AlarmTimeFrom { get; set; }
        public DateTime? AlarmTimeTo { get; set; }
    }
}
