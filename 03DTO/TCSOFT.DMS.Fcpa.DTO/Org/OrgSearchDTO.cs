using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.Fcpa.DTO.Org
{
    public class OrgSearchDTO : QueryDTO
    {
        public string DistributorName { get; set; }
        public string Status { get; set; }
    }
}
